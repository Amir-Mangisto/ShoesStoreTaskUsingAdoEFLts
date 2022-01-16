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
    public class KidsShoesController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-IGIOI52;Initial Catalog=ShoeStoreDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        KidsShoesDataContext kidsShoesDataContext = new KidsShoesDataContext(connectionString);
        // GET: api/KidsShoes
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(kidsShoesDataContext.KidsShoes.ToList());
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

        // GET: api/KidsShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                KidsShoe kidsShoe = kidsShoesDataContext.KidsShoes.First(kidsShoes => kidsShoes.Id == id);
                if (kidsShoe.Company == null) return NotFound();
                else
                {
                    return Ok(kidsShoe);
                }

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

        // POST: api/KidsShoes
        public IHttpActionResult Post([FromBody] KidsShoe userKidsShoe)
        {
            try
            {
                kidsShoesDataContext.KidsShoes.InsertOnSubmit(userKidsShoe);
                kidsShoesDataContext.SubmitChanges();
                return Ok("Kids Shoes was Added");
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

        // PUT: api/KidsShoes/5
        public IHttpActionResult Put(int id, [FromBody] KidsShoe updaeKidsShoe)
        {
            try
            {
                KidsShoe kidsShoe = kidsShoesDataContext.KidsShoes.First(item => item.Id == id);
                kidsShoe.Company = updaeKidsShoe.Company;
                kidsShoe.Matirial = updaeKidsShoe.Matirial;
                kidsShoe.InStore = updaeKidsShoe.InStore;
                kidsShoe.Size = updaeKidsShoe.Size;
                kidsShoe.Price = updaeKidsShoe.Price;
                kidsShoesDataContext.SubmitChanges();
                return Ok("kids Shoe was Update");
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

        // DELETE: api/KidsShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                kidsShoesDataContext.KidsShoes.DeleteOnSubmit(kidsShoesDataContext.KidsShoes.First(item => item.Id == id));
                kidsShoesDataContext.SubmitChanges();
                return Ok("kids Shoe was Deleted");
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
