using System;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace ResponseTimeCheck
{
    public class ResponseManager
    {
        public string Uri { get; set; }
        private HttpWebRequest request;
        private HttpWebResponse response;
        private Stopwatch timer;

        public ResponseManager(string customURI = CommonConstants.DefaultURI)
        {
            Uri = customURI;
        }

        public Entity GetResponseTime()
        {
            timer = new Stopwatch();
            try
            {
                request = (HttpWebRequest)WebRequest.Create(Uri);
                timer.Start();
                response = (HttpWebResponse)request.GetResponse();
                response.Close();
                timer.Stop();

                return new Entity
                {
                    RequestID = 1,
                    RequestTime = timer.Elapsed,
                    ErrorMessage = "Success measurement"
                };
            }
            catch(Exception ex)
            {
                return new Entity
                {
                    RequestID = 1,
                    RequestTime = default,
                    ErrorMessage = ex.ToString()
                };
            }

           
        }

        public void StartMonitoring()
        {
            using (var db = new DataBaseManager())
            {
                while(true)
                {
                    Entity entity = GetResponseTime();
                    db.Entities.Add(entity);
                    db.SaveChanges();
                    Thread.Sleep(CommonConstants.PeriodInSeconds * 1000);
                }
            }
        }
    }
}
