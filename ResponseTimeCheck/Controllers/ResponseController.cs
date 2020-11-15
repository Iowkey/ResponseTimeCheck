using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ResponseTimeCheck.Controllers
{
    public class ResponseController : ApiController
    {

        private IEnumerable<Entity> GetEntities()
        {
            using(DataBaseManager dbm = new DataBaseManager())
            {
                return dbm.Entities.ToList();
            }
        }

        [Route("api/Entities/All")]
        public IEnumerable<Entity> Get()
        {
            return GetEntities();
        }

        [Route("api/Entities/Latest/{number}")]
        public IEnumerable<Entity> GetLatest(int number)
        {
            return GetEntities().Reverse().Take(number);
        }

        [Route("api/Entities/First/{number}")]
        public IEnumerable<Entity> GetFirst(int number)
        {
            return GetEntities().Take(number);
        }
    }
}
