using FlamingSoftHR.Server.Models;
using FlamingSoftHR.Shared.Models.Request;
using FlamingSoftHR.Shared.Models.Response;
using FlamingSoftHR.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlamingSoftHR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //To get all records from db
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Department>> oResponse = new Response<List<Department>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.Departments.ToList();
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
            Response<Department> oResponse = new Response<Department>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.Departments.Find(Id);
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
        public IActionResult Add(DepartmentRequest model)
        {
            Response<List<Department>> oResponse = new Response<List<Department>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    Department oDepartment = new Department();
                    oDepartment.Description = model.Description;
                    db.Departments.Add(oDepartment);
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
        public IActionResult Edit(DepartmentRequest model)
        {
            Response<List<Department>> oResponse = new Response<List<Department>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    Department oDepartment = db.Departments.Find(model.Id);
                    oDepartment.Description = model.Description;
                    db.Entry(oDepartment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Response<Department> oResponse = new Response<Department>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    Department oDepartment = db.Departments.Find(Id);
                    db.Remove(oDepartment);
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
