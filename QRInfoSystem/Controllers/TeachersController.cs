namespace QRInfoSystem.Web.Controllers
{
    using QRInfoSystem.Data;
    using QRInfoSystem.Models;
    using System.Web.Http;
    using System.Web.Http.Description;
    using QRInfoSystem.Web.ViewModels;
    using System.Linq;
    public class TeachersController : BaseController
    {
        public TeachersController(IQRInfoSystemData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateTeacher(TeacherViewModel teacher)
        {
            if(!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTeacher = new Teacher()
                {
                    Email = teacher.Email,
                    FirstName = teacher.FirstName,
                    Id = teacher.Id,
                    LastName = teacher.LastName,
                    Phone = teacher.Phone,
                    Title = teacher.Title
                };        

            this.data.Teachers.Add(newTeacher);
            this.data.Teachers.SaveChanges();

            return Ok(newTeacher);
        }

        // GET: api/Teachers
        [HttpGet]
        public IHttpActionResult GetTeachers()
        {
            var teachers = data.Teachers
                                    .All()    
                                    .ToList();

            return Ok(teachers);
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            data.Teachers.Delete(id);
            data.Teachers.SaveChanges();

            return Ok();
        }

        // GET: api/Teachers/5
        [ResponseType(typeof(Teacher))]
        public IHttpActionResult GetTeacher(int id)
        {
            Teacher teacher = data.Teachers.Find(id);
           // Guid quidCode = Guid.Parse(code);
         //   var qrcode = data.QRCodes.All().FirstOrDefault(q => q.Code == quidCode);
            if (teacher == null)
            {
                return NotFound();
            }

            var mappedTeacher = new TeacherViewModel()
            {
                Email = teacher.Email,
                FirstName = teacher.FirstName,
                Id = teacher.Id,
                LastName = teacher.LastName,
                Phone = teacher.Phone,
                Title = teacher.Title
            };

            return Ok(mappedTeacher);
        }
    
    }
}