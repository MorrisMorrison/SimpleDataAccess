using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleDataAccess.Dao
{
    public interface IDao
    {
        Task<T> Get<T>(string p_id) where T:IEntity;
        IList<T> Get<T>(Func<T, bool> p_condition) where T : IEntity;
        Task<IList<T>> Get<T>() where T:IEntity;
        void Create<T>(T p_entity) where T:IEntity;
        void Create<T>(IList<T> p_entities) where T:IEntity;
        void Update<T>(T p_entity) where T:IEntity;
        void Delete<T>(T p_entity) where T:IEntity;
        void Delete<T>(string p_id) where T:IEntity;
    }
}