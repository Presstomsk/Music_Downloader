namespace Music_Downloader.Models.DownloadUrl
{   
        public class Rootobject
        {
            public bool ok { get; set; }
            public Result result { get; set; }
        }

        public class Result
        {
            public string download_url { get; set; }
        }
    
}
