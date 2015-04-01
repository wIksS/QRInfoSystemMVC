namespace QRInfoSystem.Web.Controllers
{
    using QRInfoSystem.Data;
    using QRInfoSystem.Infrastructure;
    using QRInfoSystem.Models;
    using QRInfoSystem.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class SheduleController : BaseController
    {
        public SheduleController(IQRInfoSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetShedules(int id, string code)
        {
            var isLogged = User.Identity.IsAuthenticated;
            if (isLogged && code == "admin")
            {
                var newShedules = Data.Shedules
                                        .All()
                                        .Where(s => s.TeacherId == id)
                                        .Select(s => new SheduleViewModel()
                                        {
                                            EndDate = s.EndDate,
                                            StartDate = s.StartDate,
                                            RoomName = s.Room.Model,
                                            TeacherId = s.TeacherId,
                                            Id = s.Id,
                                            Message = s.Message
                                        })
                                        .ToList();

                return Ok(newShedules);
            }
            if (code != "frompc")
            {
                Guid guidCode = Guid.Parse(code);
                var qrcode = Data.QRCodes.All().FirstOrDefault(q => q.Code == guidCode);
                if (qrcode == null)
                {
                    return NotFound();
                }
            }

            var shedules = Data.Shedules
                                .All()
                                .Where(s => s.TeacherId == id)
                                        .Select(s => new SheduleViewModel()
                                        {
                                            EndDate = s.EndDate,
                                            StartDate = s.StartDate,
                                            RoomName = s.Room.Model,
                                            TeacherId = s.TeacherId,
                                            Id = s.Id,
                                            Message = s.Message
                                        })
                                .ToList();

            return Ok(shedules);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddShedule(SheduleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Teacher teacher = Data.Teachers.Find(model.TeacherId);
            if (teacher == null)
            {
                return NotFound();
            }

            var room = Data.Rooms.Find(model.RoomName);
            if (room == null)
            {
                room = new Room(model.RoomName);
                Data.Rooms.Add(room);
                Data.Rooms.SaveChanges();
            }

            var shedule = new Shedule()
                {
                    EndDate = model.EndDate,
                    Id = model.Id,
                    StartDate = model.StartDate,
                    TeacherId = model.TeacherId,
                    Message = model.Message
                }; 
            shedule.Room = room;

            if (shedule.StartDate >= shedule.EndDate)
            {
                return BadRequest("Start date must be before end date");
            }

            Data.Shedules.Add(shedule);
            Data.Shedules.SaveChanges();
            //   teacher.Shedules.Add(shedule);
            Data.Teachers.SaveChanges();

            var emailsToSend = teacher.SubscribedUsers.Select(u => u.Email).ToList();
            EmailSender.Send(emailsToSend,
                String.Format("{0}'s schedule has been changed go to <b>{1}</b> to see the new schedule", teacher.FirstName + teacher.LastName, Constants.Url + "/#/teachers/" + teacher.Id),
                String.Format("{0}'s schedule has been updated", teacher.FirstName + teacher.LastName));

            return Ok(shedule);
        }
    }
}
