using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Generics
{
    public class GenericsRepository : IRepository<Customers>
    {

        public List<Customers> CustomersList { get; set; }
        public void Add(Customers item)
        {
            CustomersList.Add(item);
        }

        public IEnumerable<Customers> GetAll()
        {
            return CustomersList;
        }

        public Customers GetById(int id)
        {
            for (int i = 0; i < CustomersList.Count; i++)
            {
                if (CustomersList[i].Id == id)
                {
                    return CustomersList[i];
                }
            }
            return null;
        }

        public void Remove(Customers item)
        {
            CustomersList.Remove(item);
        }

        public void Save()
        {
            
        }
    }
}
