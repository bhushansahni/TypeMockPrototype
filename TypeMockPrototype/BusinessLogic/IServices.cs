using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeMockPrototype.Models;

namespace TypeMockPrototype.BusinessLogic
{
    public interface IServices<T> where T : IEntity
    {
        T Get(int id);
        void Save(T entity);
        T GetUsingDB(int id);
        void SaveUsingDB(T entity);
    }
}
