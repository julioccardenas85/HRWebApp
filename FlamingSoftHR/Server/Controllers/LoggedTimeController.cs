using FlamingSoftHR.Server.Models;
using FlamingSoftHR.Shared.Models.Request;
using FlamingSoftHR.Shared.Models.Response;
using FlamingSoftHR.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlamingSoftHR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggedTimeController : ControllerBase
    {
        //To get all records from db
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<LoggedTime>> oResponse = new Response<List<LoggedTime>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.LoggedTimes.ToList();
                    oResponse.Success = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }
            return Ok(oResponse);
        }

        //To get one record from db
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Response<LoggedTime> oResponse = new Response<LoggedTime>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.LoggedTimes.Find(Id);
                    oResponse.Success = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }
            return Ok(oResponse);
        }

        //To add a new record to db
        [HttpPost]
        public IActionResult Add(LoggedTimeRequest model)
        {
            Response<List<LoggedTime>> oResponse = new Response<List<LoggedTime>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    LoggedTime oLoggedTime = new LoggedTime();
                    oLoggedTime.DateLogged = model.DateLogged;
                    oLoggedTime.Hours = model.Hours;
                    oLoggedTime.LogType = model.LogType;
                    oLoggedTime.EmployeeId = model.EmployeeId;
                    db.LoggedTimes.Add(oLoggedTime);
                    db.SaveChanges();
                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }
            return Ok(oResponse);
        }

        //To edit a record from db
        [HttpPut]
        public IActionResult Edit(LoggedTimeRequest model)
        {
            Response<List<LoggedTime>> oResponse = new Response<List<LoggedTime>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    LoggedTime oLoggedTime = db.LoggedTimes.Find(model.Id);
                    oLoggedTime.DateLogged = model.DateLogged;
                    oLoggedTime.Hours = model.Hours;
                    oLoggedTime.LogType = model.LogType;
                    oLoggedTime.EmployeeId = model.EmployeeId;
                    db.Entry(oLoggedTime).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }
            return Ok(oResponse);
        }

        //To delete a record in db
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Response<LoggedTime> oResponse = new Response<LoggedTime>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    LoggedTime oLoggedTime = db.LoggedTimes.Find(Id);
                    db.Remove(oLoggedTime);
                    db.SaveChanges();
                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
                throw;
            }
            return Ok(oResponse);
        }
    }
}
