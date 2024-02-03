using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project
{
    internal class Root<T> : IRoot<T> where T : class
    {
        List<T> list = new List<T>();
        public void Add(T item)
        {
            list.Add(item);
        }
        public void Remove(T item)
        {
            list.Remove(item);
        }

        public List<T> GetAll()
        {
            return list;
        }

    }
}
