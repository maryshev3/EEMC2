using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Repositories
{
    public interface IRepository<T> where T : class
    {
        public List<T> Get();
        public void Remove(T item);
        public void Add(T item);
        public void Update(T item);
    }
}
