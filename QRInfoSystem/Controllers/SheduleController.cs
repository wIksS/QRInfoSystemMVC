namespace QRInfoSystem.Web.Controllers
{
    using QRInfoSystem.Data;
    using QRInfoSystem.Models;
    using QRInfoSystem.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    public class SheduleController : BaseController
    {
        public SheduleController(IQRInfoSystemData data)
            :base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetShedules(int id,string code)
        {
            var isLogged = User.Identity.IsAuthenticated;
            if (isLogged && code =="admin") {
                var newShedules = data.Shedules
                                        .All()
                                        .Where(s => s.TeacherId == id)
                                        .Project()
                                        .To<SheduleViewModel>()
                                        .ToList();

                return Ok(newShedules);
            }
            if(code != "frompc"){
                Guid guidCode = Guid.Parse(code);
                var qrcode = data.QRCodes.All().FirstOrDefault(q => q.Code == guidCode);
                if (qrcode == null)
                {
                    return NotFound();
                }
            }

            var shedules = data.Shedules
                                .All()
                                .Where(s => s.TeacherId == id)
                                .Project()
                                .To<SheduleViewModel>()
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

            Teacher teacher = data.Teachers.Find(model.TeacherId);
            if (teacher == null)
            {
                return NotFound();
            }

            var room = data.Rooms.Find(model.RoomName);
            if (room == null)
            {
                room = new Room();
                room.Model = model.RoomName;
                data.Rooms.Add(room);
                data.Rooms.SaveChanges();
            }

            var shedule = Mapper.Map<Shedule>(model);
            shedule.Room = room;

            if (shedule.StartDate >= shedule.EndDate)
            {
                return BadRequest("Start date must be before end date");
            }
          
            data.Shedules.Add(shedule);
            data.Shedules.SaveChanges();
         //   teacher.Shedules.Add(shedule);
            data.Teachers.SaveChanges();

            return Ok(shedule);
        }
    }
}
