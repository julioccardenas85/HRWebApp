using FlamingSoftHR.Server.Models;
using FlamingSoftHR.Shared.Models.Request;
using FlamingSoftHR.Shared.Models.Response;
using FlamingSoftHR.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlamingSoftHR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggedTimeTypeController : ControllerBase
    {
        //To get all records from db
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<LoggedTimeType>> oResponse = new Response<List<LoggedTimeType>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.LoggedTimeTypes.ToList();
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
            Response<LoggedTimeType> oResponse = new Response<LoggedTimeType>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.LoggedTimeTypes.Find(Id);
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
        public IActionResult Add(LoggedTimeTypeRequest model)
        {
            Response<List<LoggedTimeType>> oResponse = new Response<List<LoggedTimeType>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    LoggedTimeType oLoggedTimeType = new LoggedTimeType();
                    oLoggedTimeType.Description = model.Description;
                    db.LoggedTimeTypes.Add(oLoggedTimeType);
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
        public IActionResult Edit(LoggedTimeTypeRequest model)
        {
            Response<List<LoggedTimeType>> oResponse = new Response<List<LoggedTimeType>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    LoggedTimeType oLoggedTimeType = db.LoggedTimeTypes.Find(model.Id);
                    oLoggedTimeType.Description = model.Description;
                    db.Entry(oLoggedTimeType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Response<LoggedTimeType> oResponse = new Response<LoggedTimeType>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    LoggedTimeType oLoggedTimeType = db.LoggedTimeTypes.Find(Id);
                    db.Remove(oLoggedTimeType);
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
