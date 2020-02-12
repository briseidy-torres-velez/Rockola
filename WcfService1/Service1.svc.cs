using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       
        public List<SearchResult> GetListYoutube(string keyword)
        {
            var youtuberService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBA5MWGsEof8dVHxcyJv3TYnP-qSRh1vjk",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtuberService.Search.List("snippet");
            searchListRequest.Q = keyword;


            searchListRequest.MaxResults = 5;



            var searchListResponse = searchListRequest.Execute();

          

            return searchListResponse.Items.ToList();
        }

        public void GetListYoutube()
        {
            throw new NotImplementedException();
        }
    }
}
