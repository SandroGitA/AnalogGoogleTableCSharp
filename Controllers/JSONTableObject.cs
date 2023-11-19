namespace AnalogGoogleTableCSharp.Controllers
{
    public class JSONTableObject
    {
        public id_cell ID_cell { get; set; }
        public data Data { get; set; }

        public class id_cell
        {
            public int id { get; set; }
        }

        public class data
        {
            public string text { get; set; }
        }
    }
}
