using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

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
        public string Get()
        {                      
            var connection = connect.ReturnSQLConnection();

            //Создаем объект команды
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from DataTable";
            cmd.Connection = connection;

            SqlDataReader reader = cmd.ExecuteReader();

            //Создаем лист объектов
            List<JSONTableObject> listCoordinates = new List<JSONTableObject>();

            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object data = reader.GetValue(1);
                object coordinate = reader.GetValue(2);

                listCoordinates.Add(new JSONTableObject { cd = (JSONTableObject.CellData)data, cc = (JSONTableObject.CellCoordinate)coordinate });
            }
            
            reader.Close();
            connection.Close();

            return JsonConvert.SerializeObject(listCoordinates);

            //return new string[] { "value1", "value2" };            
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
