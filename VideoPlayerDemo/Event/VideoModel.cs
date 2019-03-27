using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VideoPlayerDemo.Event
{
    public class VideoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Desc { get; set; }
        public string VideoIcon { get; set; }

        public string VideoUrl { get; set; }
        public string VideoLong { get; set; }

        public int VideoShareCount { get; set; }
        public int VideoCommentCount { get; set; }
        public int VideoLikeCount { get; set; }
        public int VideoPlayCount { get; set; }
        public int VideoSubscribeCount { get; set; }
        public int VideoClassId { get; set; }
        public string SubTitle { get; set; }
        public int PartId { get; set; }
        public int ResId { get; set; }
        public int ResHId { get; set; }

        public int VideoViewCount { get; set; }
        public int Episode { get; set; }

        public string Categoryids { get; set; }
    }

    public class ArticleComment
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public string Author { get; set; }

        public string AuthorUrl { get; set; }

        public string FaceUrl { get; set; }

        public int Floor { get; set; }

        public DateTime DateAdded { get; set; }
    }
}