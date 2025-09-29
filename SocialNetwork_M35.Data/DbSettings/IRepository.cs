using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_M35.Data.DbSettings
{
    public interface IRepository<T> where T : class
    {
        // Разбор: IRepository<T> T - обозначает тип данных который будет наследоваться от
        // этого репозитория и при применении T Get(int id); - мы получим обьект этого класса
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
