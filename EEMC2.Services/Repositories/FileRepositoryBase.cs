using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Repositories
{
    public abstract class FileRepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly string _entityFullFileName;

        public FileRepositoryBase(string baseFilePath, string entityFileName)
        {
            _entityFullFileName = Path.Combine(baseFilePath, entityFileName);

            EnsureFileExists(_entityFullFileName);
        }

        private void EnsureFileExists(string entityFullFileName)
        {
            if (!File.Exists(entityFullFileName)) 
            {
                File.WriteAllText(entityFullFileName, "[]");
            }
        }

        public abstract void Add(T item);

        public abstract void Remove(T item);

        public abstract void Update(T item);

        public List<T> Get() =>
            JsonConvert
                .DeserializeObject<List<T>>(
                    File.ReadAllText(_entityFullFileName)
                );

        protected void Save(IEnumerable<T> courses) =>
            File
                .WriteAllText(
                    _entityFullFileName,
                    JsonConvert.SerializeObject(courses)
                );
    }
}
