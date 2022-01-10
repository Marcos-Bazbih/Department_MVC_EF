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
    public class ManagersController : ApiController
    {
        static DepartmentContext departmentContext = new DepartmentContext();

        // GET: api/Managers
        public IHttpActionResult Get()
        {
            return Ok(departmentContext.managers.ToList());
        }

        // GET: api/Managers/5
        public async Task <IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok(await departmentContext.managers.FindAsync(id));
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

        // POST: api/Managers
        public async Task<IHttpActionResult> Post([FromBody] Manager value)
        {
            try
            {
                departmentContext.managers.Add(value);
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

        // PUT: api/Managers/5
        public IHttpActionResult Put(int id, [FromBody] Manager value)
        {
            try
            {
                Manager updateManager = departmentContext.managers.First(manager => manager.Id == id);
                if (updateManager != null)
                {
                    updateManager.Name = value.Name;
                    updateManager.Seniority = value.Seniority;
                    updateManager.NumberOfEmployees = value.NumberOfEmployees;

                    departmentContext.SaveChanges();
                    return Ok($"{updateManager.Name} updated successfully");
                }
                return Ok("No manager found");
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

        // DELETE: api/Managers/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                departmentContext.managers.Remove(departmentContext.managers.First(manager => manager.Id == id));
                departmentContext.SaveChanges();
                return Ok("Manager deleted");
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
