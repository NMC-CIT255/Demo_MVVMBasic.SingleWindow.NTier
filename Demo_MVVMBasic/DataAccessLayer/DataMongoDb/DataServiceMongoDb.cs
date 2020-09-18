using Demo_MVVMBasic.DataAccessLayer.DataMongoDb;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVMBasic.DataAccessLayer
{
    public class DataServiceMongoDb : IDataService
    {
        private List<Widget> _widgets;
        private IMongoCollection<Widget> _collection;

        public DataServiceMongoDb()
        {
            //WriteSeedData();
            Connection();
        }

        private void WriteSeedData()
        {
            try
            {
                MongoDbUtilities.WriteSeedDataToDatabase();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool Connection()
        {
            try
            {
                MongoClient dbClient = new MongoClient(MongoDbDataSettings.connectionString);
                IMongoDatabase database = dbClient.GetDatabase(MongoDbDataSettings.databaseName);
                IMongoCollection<Widget> _collection = database.GetCollection<Widget>(MongoDbDataSettings.collectionName);

                _widgets = _collection.Find(Builders<Widget>.Filter.Empty).ToList();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Widget> GetAll()
        {
            return _widgets;
        }

        public void Add(Widget widget)
        {
            _collection.InsertOne(widget);
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public Widget GetById(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Widget widget)
        {
            throw new NotImplementedException();
        }
    }
}
