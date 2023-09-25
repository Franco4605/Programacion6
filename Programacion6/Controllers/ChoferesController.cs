using Microsoft.AspNetCore.Mvc;
using Programacion6.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Programacion6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoferesController : ControllerBase
    {

        string connectionString = "Server=DESKTOP-IKDJ719;Database=ParcialProg6; Trusted_Connection=true;TrustServerCertificate=true;";
        [HttpGet]
        [Route("getChoferes")]
        public List<Choferes> getChoferes()
        {
            List<Choferes> LH = new List<Choferes>();

            string Query="Select IdChofer, Nombre, EDAD, Apellido, Unidad, DNI from Choferes";

            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlCommand sqlCM = new SqlCommand(Query, sqlConn);
            SqlDataReader dr = sqlCM.ExecuteReader();
            while (dr.Read())
            {
                Choferes oh = new Choferes();
                oh.IdChofer = int.Parse(dr[0].ToString());
                oh.Nombre = dr[1].ToString();
                oh.Edad = int.Parse(dr[2].ToString());
                oh.Apellido = dr[3].ToString();
                oh.Unidad = dr[4].ToString();
                oh.DNI = int.Parse(dr[5].ToString());


                LH.Add(oh);
            }
            

            sqlConn.Close();

         



            return LH;
        }







        // GET: api/<ChoferesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ChoferesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChoferesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChoferesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChoferesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
