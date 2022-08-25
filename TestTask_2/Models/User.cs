using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask_2.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public float Salary { get; set; }
        public string DepartamentId { get; set; }
        public string PCId { get; set; }
    }
}