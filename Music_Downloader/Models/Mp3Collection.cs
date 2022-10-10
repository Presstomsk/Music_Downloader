namespace Music_Downloader.Models.Mp3Collection
{
        public class Rootobject
        {
            public bool ok { get; set; }
            public Result result { get; set; }
        }

        public class Result
        {
            public Song[] songs { get; set; }
            public Video[] videos { get; set; }
        }

        public class Song
        {
            public string id { get; set; }
            public string name { get; set; }
            public string title { get; set; }
            public Artist[] artists { get; set; }
            public Album album { get; set; }
            public int duration { get; set; }
            public string thumbnail { get; set; }
        }

        public class Album
        {
            public string album_id { get; set; }
            public string name { get; set; }
        }

        public class Artist
        {
            public string artist_id { get; set; }
            public string name { get; set; }
        }

        public class Video
        {
            public string id { get; set; }
            public string title { get; set; }
            public int duration { get; set; }
        }

}

