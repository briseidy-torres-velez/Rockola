using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using HistorialData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiYoutube2.Controllers
{
    public class YoutubeController : ApiController
    {
        DataProductsEntities dataProductsEntities = new DataProductsEntities();
        [HttpGet]
        public IEnumerable<SearchResult> Get(string keyword)
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

        [HttpPost]
        public bool Post(HistorialT historialT)
        {
           
            dataProductsEntities.HistorialT.
        }
    }
}
