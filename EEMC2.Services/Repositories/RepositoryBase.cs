using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        public abstract void Add(T item);

        public abstract List<T> Get();

        public abstract void Remove(T item);

        public abstract void Update(T item);
    }
}
