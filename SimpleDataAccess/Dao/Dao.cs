using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace SimpleDataAccess.Dao
{
    public interface IEntity
    {
        public string Id { get; set; }
    }
    
    public class Dao:IDao
    {

        private DbAccess _dbAccess { get; set; }
        
        public Dao(DbAccess p_dbAccess)
        {
            _dbAccess = p_dbAccess;
        }

        public async Task<IList<T>> Get<T>() where T:IEntity
        {
            return await _dbAccess.GetCollection<T>().Find(_=> true).ToListAsync();
        }

        public IList<T> Get<T>(Func<T, bool> p_condition) where T : IEntity
        {
            return _dbAccess.GetCollection<T>().AsQueryable().Where(p_condition).ToList();
        }

        public async Task<T> Get<T>(string p_id) where T:IEntity
        {
            return await _dbAccess.GetCollection<T>().Find(p_entity => p_entity.Id.Equals(p_id)).FirstOrDefaultAsync();
        }

        public async void Create<T>(T p_entity) where T:IEntity
        {
            await _dbAccess.GetCollection<T>().InsertOneAsync(p_entity);
        }

        public async void Create<T>(IList<T> p_entities) where T:IEntity
        {
            await _dbAccess.GetCollection<T>().InsertManyAsync(p_entities);
        }

        public async void Update<T>(T p_entity) where T:IEntity
        {
            await _dbAccess.GetCollection<T>().ReplaceOneAsync(p_x => p_x.Id.Equals(p_entity.Id), p_entity);
        }

        public async void Delete<T>(T p_entity) where T:IEntity
        {
            await _dbAccess.GetCollection<T>().DeleteOneAsync(p_x => p_x.Id.Equals(p_entity.Id));

        }

        public async void Delete<T>(string p_id) where T:IEntity
        {
            await _dbAccess.GetCollection<T>().DeleteOneAsync(p_entity => p_entity.Id.Equals(p_id));
        }
    }


}