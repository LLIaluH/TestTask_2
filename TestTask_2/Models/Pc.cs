using TestTask_2.Models.Abstract;

namespace TestTask_2.Models
{
    public class Pc : Model
    {
        public int Cpu { get; set; }
        public int Memory { get; set; }
        public int Hdd { get; set; }
    }
}