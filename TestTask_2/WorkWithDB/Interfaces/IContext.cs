using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_2.Models.Abstract;

namespace TestTask_2.WorkWithDB.Interfaces
{
    interface IContext
    {
        string Get();
        void Insert(Model model);
        void Update(Model model);
        void Delete(Model model);
    }
}
