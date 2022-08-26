using TestTask_2.Models.Abstract;

namespace TestTask_2.Models
{
    public class User : Model
    {
        public string UserName { get; set; }
        public float Salary { get; set; }
        public string DepartamentId { get; set; }
        public string PCId { get; set; }
    }
}