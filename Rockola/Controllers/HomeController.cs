using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using Rockola.ServiceReference1;

namespace Rockola.Controllers
{
    public class HomeController : Controller
    {
        //private Service1Client sc = new Service1Client();
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult SearchList(string keyword)
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

                var respuesta = searchListResponse.Items;
                return PartialView("Search", respuesta);


           
              



            // return PartialView("Search",sc.GetListYoutube(keyword).ToList());
        }


        //[HttpGet]
        //public JsonResult PlayList(Google.Apis.YouTube.v3.Data.SearchResult VideoId)
        //{

        //    return Json(VideoId, JsonRequestBehavior.AllowGet);

        //  //  return PartialView("AddPlay",Json(VideoId, JsonRequestBehavior.AllowGet));
        //}


    }
}