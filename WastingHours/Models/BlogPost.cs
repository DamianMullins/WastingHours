using System;
using System.Collections.Generic;
using System.Linq;

namespace WastingHours.Models
{
    public class BlogPost
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Tags { get; set; }
        public List<string> TagList 
        {
            get { return Tags.Split(',').Select(tag => tag.Trim()).ToList(); }
        }
    }
}
