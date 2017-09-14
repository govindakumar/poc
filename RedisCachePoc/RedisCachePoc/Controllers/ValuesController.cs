using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StackExchange.Redis;
using RedisCachePoc.Models;
using Newtonsoft.Json;

namespace RedisCachePoc.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("DemoRedisCache.redis.cache.windows.net:6380,password=S+NsEZUzdj3VV68+e9COKhV/tT6KaVAQ2EiLDk6MhNc=,ssl=True,abortConnect=False,ConnectTimeout=10000");
            //return ConnectionMultiplexer.Connect("pocs.redis.cache.windows.net,abortConnect=false,ssl=true,password=tQNvBdL/Ldzg2VkV7OxmYJ7rRVu8X9hpg6gDNn6W9V4=,ConnectTimeout=10000");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
        public IDatabase cacheDB { get; set; }

        public ValuesController()
        {
            cacheDB = Connection.GetDatabase();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            cacheDB.StringSet("UserId", "alaskaWebApp");
            cacheDB.StringSet("key2", 25);
            var emp = new Employee()
            {
                Id = 11258148,
                Name = "Govinda Kumar",
                Age = 27,
                Address = "Kolkata"
            };
            cacheDB.StringSet("e11258148", JsonConvert.SerializeObject(emp));
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            var userId=cacheDB.StringGet("UserId");
            Employee e25 = JsonConvert.DeserializeObject<Employee>(cacheDB.StringGet("e11258148"));
            return JsonConvert.SerializeObject(e25).ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
