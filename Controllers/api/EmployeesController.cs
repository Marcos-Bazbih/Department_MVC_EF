using Department_MVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Department_MVC_EF.Controllers.api
{
    public class EmployeesController : ApiController
    {
        static DepartmentContext departmentContext = new DepartmentContext();

        // GET: api/Employees
        public IHttpActionResult Get()
        {
            return Ok(departmentContext.Employees.ToList());
        }


        // GET: api/Employees/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok(await departmentContext.Employees.FindAsync(id));
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: api/Employees
        public async Task<IHttpActionResult> Post([FromBody] Employee value)
        {
            try
            {
                departmentContext.Employees.Add(value);
                await departmentContext.SaveChangesAsync();
                return Ok($"{value.Name} Added successfully");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT: api/Employees/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Employee value)
        {
            try
            {
                Employee updateEmp = await departmentContext.Employees.FindAsync(id);
                if (updateEmp != null)
                {
                    updateEmp.Name = value.Name;
                    updateEmp.Position = value.Position;
                    updateEmp.Seniority = value.Seniority;

                    await departmentContext.SaveChangesAsync();
                    return Ok($"{updateEmp.Name} updated successfully");
                }
                return Ok("No employee found");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/Employees/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                departmentContext.Employees.Remove(await departmentContext.Employees.FindAsync(id));
                await departmentContext.SaveChangesAsync();
                return Ok("Employee deleted");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
