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
    public class AdoSportShoesController : ApiController
    {
        static string stringConnection = "Data Source=DESKTOP-IGIOI52;Initial Catalog=ShoeStoreDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";

        // GET: api/AdoSportShoes
        public IHttpActionResult Get()
        {
            try
            {
                List<SportShoe> sportShoeList = new List<SportShoe>();
                using (SqlConnection DBconnection = new SqlConnection(stringConnection))
                {
                    DBconnection.Open();
                    string query = $@"SELECT * FROM AdoSportShoes";
                    SqlCommand cmd = new SqlCommand(query, DBconnection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            sportShoeList.Add(new SportShoe(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3), dr.GetInt32(4)));
                        }
                    }
                    DBconnection.Close();
                    return Ok(new { sportShoeList });
                }
                return Ok();
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

        // GET: api/AdoSportShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection DBconnection = new SqlConnection(stringConnection))
                {
                    DBconnection.Open();
                    string getByIdQuery = $@"SELECT * FROM AdoSportShoes WHERE Id ={id}";
                    SqlCommand get = new SqlCommand(getByIdQuery, DBconnection);
                    SqlDataReader sqlDataReader = get.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            SportShoe sportShoeById = new SportShoe(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetInt32(3), sqlDataReader.GetInt32(4));
                            return Ok(new { sportShoeById });
                        }
                    }
                    DBconnection.Close();
                }
                return NotFound();
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

        // POST: api/AdoSportShoes
        public IHttpActionResult Post([FromBody] SportShoe addSportShoe)
        {
            try
            {
                using (SqlConnection DBconnection = new SqlConnection(stringConnection))
                {
                    DBconnection.Open();
                    string addQuery = $@"INSERT INTO AdoSportShoes(Company,Brand,Size,Price) values('{addSportShoe.Company}','{addSportShoe.Brand}',{addSportShoe.Size},{addSportShoe.Price})";
                    SqlCommand postQuery = new SqlCommand(addQuery, DBconnection);
                    int rowsEffected = postQuery.ExecuteNonQuery();
                    DBconnection.Close();
                    return Ok(new { rowsEffected });
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

        // PUT: api/AdoSportShoes/5
        public IHttpActionResult Put(int id, [FromBody] SportShoe updateSportShoe)
        {
            try
            {
                using (SqlConnection DBconnection = new SqlConnection(stringConnection))
                {
                    DBconnection.Open();
                    string updateQuery = $@"UPDATE AdoSportShoes SET Company='{updateSportShoe.Company}',Brand='{updateSportShoe.Brand}',Size={updateSportShoe.Size},Price={updateSportShoe.Price} WHERE Id= {id}";
                    SqlCommand postQuery = new SqlCommand(updateQuery, DBconnection);
                    int updateRow = postQuery.ExecuteNonQuery();
                    DBconnection.Close();
                    return Ok(updateRow);
                }
                //return Ok();
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

        // DELETE: api/AdoSportShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection DBconnection = new SqlConnection(stringConnection))
                {
                    DBconnection.Open();
                    string deleteQuery = $@"DELETE FROM AdoSportShoes WHERE Id={id}";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, DBconnection);
                    int deleteRow = deleteCommand.ExecuteNonQuery();
                    DBconnection.Close();
                }
                return Ok("Item was Deleted");
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
