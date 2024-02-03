using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project
{
    internal interface IRoot<T> where T : class
    {
        void Add(T item);
        void Remove(T item);
        
        List<T> GetAll();
    }
}
