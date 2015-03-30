using Excel;
using QRInfoSystem.Data;
using QRInfoSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRInfoSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExcelController : Controller
    {
        public ExcelController(IQRInfoSystemData data)
        {
            this.Data = data;
        }

        private IQRInfoSystemData Data { get; set; }
        // GET: Excel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult UploadExcel(HttpPostedFileBase file, int? teacherId, DateTime startDate, DateTime endDate)
        {
            var teacher = Data.Teachers.Find(teacherId);

            if (teacher == null || startDate >= endDate)
            {
                return RedirectPermanent("/#/Error");
            }

            var extension = Path.GetExtension(file.FileName);
            IExcelDataReader excelReader;
            if (extension == ".xsl")
            {
                excelReader = ExcelReaderFactory.CreateBinaryReader(file.InputStream);
            }
            else if (extension == ".xlsx")
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
            }
            else
            {
                return RedirectPermanent("/#/Error");
            }

            excelReader.IsFirstRowAsColumnNames = true;
            DataSet data = excelReader.AsDataSet();
            DataTable table = data.Tables[0];

            string[] daysOfWeek = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            Dictionary<string, List<Shedule>> days = new Dictionary<string, List<Shedule>>();
            days.Add("Monday", new List<Shedule>());
            days.Add("Tuesday", new List<Shedule>());
            days.Add("Wednesday", new List<Shedule>());
            days.Add("Thursday", new List<Shedule>());
            days.Add("Friday", new List<Shedule>());
            days.Add("Saturday", new List<Shedule>());
            days.Add("Sunday", new List<Shedule>());

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Rows[i].ItemArray.Count(); j++)
                {
                    int currentDay = j / 4;
                    int currentItemId = j % 4;
                    var currentItem = table.Rows[i].ItemArray[j];
                    if (string.IsNullOrEmpty(currentItem.ToString()))
                    {
                        continue;
                    }
                    if (currentItemId == 0)
                    {
                        days[daysOfWeek[currentDay]].Add(new Shedule());
                        var currentShedule = days[daysOfWeek[currentDay]];
                        var room = Data.Rooms.Find(currentItem.ToString());
                        if (room == null)
                        {
                            room = new Room(currentItem.ToString());
                            this.Data.Rooms.Add(room);
                            this.Data.Rooms.SaveChanges();
                        }
                        currentShedule[currentShedule.Count - 1].Room = room;
                    }
                    if (currentItemId == 1)
                    {
                        var currentShedule = days[daysOfWeek[currentDay]];
                        currentShedule[currentShedule.Count - 1].Message = currentItem.ToString();
                    }
                    if (currentItemId == 2)
                    {
                        var currentShedule = days[daysOfWeek[currentDay]];
                        currentShedule[currentShedule.Count - 1].StartDate = DateTime.Parse(currentItem.ToString());
                    }
                    if (currentItemId == 3)
                    {
                        var currentShedule = days[daysOfWeek[currentDay]];
                        currentShedule[currentShedule.Count - 1].EndDate = DateTime.Parse(currentItem.ToString());
                    }
                }
            }

            var currentDate = startDate;

            for (int i = 0; i < i+1; i++)
            {
                if (currentDate >= endDate)
                {
                    break;
                }

                var weeklyShedules = days[currentDate.DayOfWeek.ToString()];
                for (int j = 0; j < weeklyShedules.Count; j++)
                {
                    var currentShedule = new Shedule()
                    {
                        TeacherId = teacher.Id,
                        Teacher = teacher,
                        Room = weeklyShedules[j].Room,
                        StartDate = new DateTime(currentDate.Year,currentDate.Month,currentDate.Day,weeklyShedules[j].StartDate.Hour,weeklyShedules[j].StartDate.Minute,weeklyShedules[j].StartDate.Second),
                        EndDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, weeklyShedules[j].EndDate.Hour, weeklyShedules[j].EndDate.Minute, weeklyShedules[j].EndDate.Second),
                        Message = weeklyShedules[j].Message                        
                    };

                    teacher.Shedules.Add(currentShedule);
                }

                currentDate = currentDate.AddDays(1);
            }

            this.Data.Teachers.SaveChanges();

            return RedirectPermanent("/#/Excel/" + teacherId);
        }
    }
}