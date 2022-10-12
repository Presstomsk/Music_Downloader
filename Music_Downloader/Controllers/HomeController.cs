using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music_Downloader.Database;
using Music_Downloader.Models;
using Music_Downloader.Models.Mp3Collection;
using Music_Downloader.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using Song = Music_Downloader.Models.Song;

namespace Music_Downloader.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainContext _context;

        public HomeController(ILogger<HomeController> logger, MainContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() 
        {
            var infoList = new List<Song>();

            return View(infoList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Action(string songId)
        {
            var http = new HTTP();
            var response = http.GetDownloadUrl(songId);
            var info = JsonConvert.DeserializeObject<Models.DownloadUrl.Rootobject>(response);
            string link = info.result?.download_url; //ссылка         
            Process.Start(new ProcessStartInfo
            {
                FileName = link,
                UseShellExecute = true
            });

            var songs = _context.Songs.ToList();

            return View("Index", songs);
        }

        [HttpPost]
        public IActionResult GetNewData(string artistName) 
        {            
            var http = new HTTP();
            var response = http.Search(artistName);
            var info = JsonConvert.DeserializeObject<Rootobject>(response);
            var songs =info.ok ? info.result.songs.Select(x => new Song { Id = x.id, Name = x.name, Src = x.thumbnail }).ToList() : new List<Song>();
            if(info.ok)
            {
                info.result.videos.Select(x => new Song { Id = x.id, Name = x.title }).ToList().ForEach(x => {
                    songs.Add(x);
                });
            }
            _context.Songs.AddRange(songs);
            _context.SaveChanges();
            
            return View("Index",songs);
        }
    }    
}
