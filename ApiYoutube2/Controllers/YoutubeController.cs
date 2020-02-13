using ApiYoutube2.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
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
        Models.DataProductsEntities db = new Models.DataProductsEntities();
        [HttpGet]
        public List<SRM> BuscarLista(string palabra)
        {
            var ServicioYouTube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCENuuzGXhwKTvQVsuG0HyhEYW9DWuXGPg",
                ApplicationName = this.GetType().ToString()
            });

            var BuscarListaSolicitud = ServicioYouTube.Search.List("snippet");
            BuscarListaSolicitud.Q = palabra; //Buscador
            BuscarListaSolicitud.MaxResults = 5;

            SearchListResponse BuscarListaRespuesta = BuscarListaSolicitud.Execute();
            IList<Google.Apis.YouTube.v3.Data.SearchResult> searchResults = BuscarListaRespuesta.Items;
            List<SRM> searchResultModifieds = new List<SRM>();

            foreach (var item in searchResults)
            {
                SRM searchResultC = new SRM();
                searchResultC.VideoId = item.Id.VideoId;
                searchResultC.ImageUrl = item.Snippet.Thumbnails.Default__.Url;
                searchResultC.Title = item.Snippet.Title;
                searchResultC.Title = item.Snippet.ChannelTitle;
                searchResultC.Expo = "Hello";

                searchResultModifieds.Add(searchResultC);
            }
            //return searchResults.ToList();
            return searchResultModifieds;
        }





        Models.HistorialT BD = new Models.HistorialT();

        //[HttpGet]
        //public IEnumerable<SearchResult> Get(string keyword)
        //{
        //    var youtuberService = new YouTubeService(new BaseClientService.Initializer()
        //    {
        //        ApiKey = "AIzaSyBA5MWGsEof8dVHxcyJv3TYnP-qSRh1vjk",
        //        ApplicationName = this.GetType().ToString()
        //    });
        //    var searchListRequest = youtuberService.Search.List("snippet");
        //    searchListRequest.Q = keyword;
        //    searchListRequest.MaxResults = 5;
        //    var searchListResponse = searchListRequest.Execute();
        //    return searchListResponse.Items.ToList();
        //}

        [HttpPost]
        public HttpResponseMessage Post([FromBody]HistorialT historialTS)
        {
            using (Models.DataProductsEntities db = new Models.DataProductsEntities())
            {
                db.HistorialT.Add(historialTS);
                db.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.Created, historialTS);
        }

        [HttpGet]
        public IEnumerable<HistorialT> Get()
        {

            var listado = db.HistorialT.ToList();
            return listado;
        }
    }


    
}

