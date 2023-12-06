using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnalogGoogleTableCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class v1Controller : ControllerBase
    {
        //При запуске приложения создаем подключение к БД
        SQLConnect connect = new SQLConnect();

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {                      
            var str = connect.ReturnSQLConnection();

            //Создаем объект команды
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from DataTable";
            cmd.Connection = str;

            SqlDataReader dr = cmd.ExecuteReader();

            object js = "";

            while (dr.Read())
            {
                object id = dr.GetValue(0);
                object data = dr.GetValue(1);
                object coordinate = dr.GetValue(2);

                js = new JSONTableObject(){
                    Data = (JSONTableObject.data)data, ID_cell = (JSONTableObject.id_cell)id
                };
            }
            
            dr.Close();
            str.Close();

            //return new string[] { "value1", "value2" };

            return (IEnumerable<string>)js;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] JSONTableObject value)
        {
            var request = value;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }    
}
