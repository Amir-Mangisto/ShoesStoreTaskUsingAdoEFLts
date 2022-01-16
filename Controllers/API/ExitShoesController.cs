using ShoesStoreTaskUsingAdoEFLts.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoesStoreTaskUsingAdoEFLts.Controllers.API
{
    public class ExitShoesController : ApiController
    {
        ShoeStoreContext shoeStoreContext=new ShoeStoreContext();
        // GET: api/ExitShoes
        public IHttpActionResult Get()
        {
            try
            {
                return Json(shoeStoreContext.ExitShoes.ToList());
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // GET: api/ExitShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                ExitShoes shoesId = shoeStoreContext.ExitShoes.Find(id);
                return Ok(shoesId);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // POST: api/ExitShoes
        [HttpPost]
        public IHttpActionResult Post([FromBody] ExitShoes userExitShoe)
        {
            try
            {
                shoeStoreContext.ExitShoes.Add(userExitShoe);
                shoeStoreContext.SaveChanges();
                return Ok("Shoe was Added");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/ExitShoes/5
        public IHttpActionResult Put(int id, [FromBody] ExitShoes userExitShoe)
        {
            try
            {
                ExitShoes shoesToUpdate = shoeStoreContext.ExitShoes.First(shoes=>shoes.Id == id);
                if (shoesToUpdate == null) return NotFound();
                shoesToUpdate.ComapnyName=userExitShoe.ComapnyName;
                shoesToUpdate.Gender=userExitShoe.Gender;
                shoesToUpdate.HasHeel=userExitShoe.HasHeel;
                shoesToUpdate.InStore=userExitShoe.InStore;
                shoesToUpdate.Size=userExitShoe.Size;
                shoesToUpdate.Price=userExitShoe.Price;
                shoeStoreContext.SaveChanges();
                return Ok("Shoes has Been Update");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // DELETE: api/ExitShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                ExitShoes shoesToDelete = shoeStoreContext.ExitShoes.First(shoes => shoes.Id == id);
                shoeStoreContext.ExitShoes.Remove(shoesToDelete);
                shoeStoreContext.SaveChanges();
                return Ok("Shoes has Been Deleted");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
