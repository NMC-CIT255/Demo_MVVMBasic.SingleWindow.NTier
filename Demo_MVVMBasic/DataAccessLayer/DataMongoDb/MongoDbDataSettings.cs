using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVMBasic.DataAccessLayer.DataMongoDb
{
    public static class MongoDbDataSettings
    {
        private static string userName = "johnvelis";
        private static string password = "biketoday";

        public static string connectionString = $"mongodb://{userName}:{password}@cluster0-shard-00-00-hasci.mongodb.net:27017,cluster0-shard-00-01-hasci.mongodb.net:27017,cluster0-shard-00-02-hasci.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true";

        public static string collectionName = "widgets";       
        public static string databaseName = "cit255";
    }
}
