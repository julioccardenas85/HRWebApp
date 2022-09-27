using FlamingSoftHR.Server.Models;
using FlamingSoftHR.Shared.Models.Request;
using FlamingSoftHR.Shared.Models.Response;
using FlamingSoftHR.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlamingSoftHR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {   
        //To get all records from db
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Employee>> oResponse = new Response<List<Employee>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.Employees.ToList();
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
            Response<Employee> oResponse = new Response<Employee>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    var lst = db.Employees.Find(Id);
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
        public IActionResult Add(EmployeeRequest model)
        {
            Response<List<Employee>> oResponse = new Response<List<Employee>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    Employee oEmployee = new Employee();
                    oEmployee.UserId = model.UserId;
                    oEmployee.FirstName = model.FirstName;
                    oEmployee.MiddleName = model.MiddleName;
                    oEmployee.LastName = model.LastName;
                    oEmployee.DepartmentId = model.DepartmentId;
                    oEmployee.EmployeeTypeId = model.EmployeeTypeId;
                    db.Employees.Add(oEmployee);
                    db.SaveChanges();
                    oResponse.Success=1;
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
        public IActionResult Edit(EmployeeRequest model)
        {
            Response<List<Employee>> oResponse = new Response<List<Employee>>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    Employee oEmployee = db.Employees.Find(model.Id);
                    oEmployee.UserId = model.UserId;
                    oEmployee.FirstName = model.FirstName;
                    oEmployee.MiddleName = model.MiddleName;
                    oEmployee.LastName = model.LastName;
                    oEmployee.DepartmentId = model.DepartmentId;
                    oEmployee.EmployeeTypeId = model.EmployeeTypeId;
                    db.Entry(oEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Response<Employee> oResponse = new Response<Employee>();
            try
            {
                using (FlamingSoftHRContext db = new FlamingSoftHRContext())
                {
                    Employee oEmployee = db.Employees.Find(Id);
                    db.Remove(oEmployee);
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
