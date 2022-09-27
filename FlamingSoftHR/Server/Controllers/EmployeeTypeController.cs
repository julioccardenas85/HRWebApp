using FlamingSoftHR.Server.Models;
using FlamingSoftHR.Shared.Models.Request;
using FlamingSoftHR.Shared.Models.Response;
using FlamingSoftHR.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlamingSoftHR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        //To get all records from db
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<EmployeeType>> oResponse = new Response<List<EmployeeType>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.EmployeeTypes.ToList();
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
            Response<EmployeeType> oResponse = new Response<EmployeeType>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.EmployeeTypes.Find(Id);
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
        public IActionResult Add(EmployeeTypeRequest model)
        {
            Response<List<EmployeeType>> oResponse = new Response<List<EmployeeType>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    EmployeeType oEmployeeType = new EmployeeType();
                    oEmployeeType.Description = model.Description;
                    db.EmployeeTypes.Add(oEmployeeType);
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
        public IActionResult Edit(EmployeeTypeRequest model)
        {
            Response<List<EmployeeType>> oResponse = new Response<List<EmployeeType>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    EmployeeType oEmployeeType = db.EmployeeTypes.Find(model.Id);
                    oEmployeeType.Description = model.Description;
                    db.Entry(oEmployeeType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Response<EmployeeType> oResponse = new Response<EmployeeType>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    EmployeeType oEmployeeType = db.EmployeeTypes.Find(Id);
                    db.Remove(oEmployeeType);
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
