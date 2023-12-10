namespace AnalogGoogleTableCSharp.Controllers
{
    //Класс для привязки модели к запросу
    public class JSONTableObject
    {
        public CellCoordinate cc { get; set; }
        public CellData cd { get; set; }

        /// <summary>
        /// Класс для значения координаты
        /// </summary>
        public class CellCoordinate
        {
            public int cell_coordinate { get; set; }
        }

        /// <summary>
        /// Класс для значении ячейки
        /// </summary>
        public class CellData
        {
            public string cell_data { get; set; }
        }
    }
}
