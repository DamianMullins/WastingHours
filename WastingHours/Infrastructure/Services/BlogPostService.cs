using MarkdownSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WastingHours.Infrastructure.Abstract;
using WastingHours.Models;

namespace WastingHours.Infrastructure.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly string _blogFilePath;

        public BlogPostService()
        {
            _blogFilePath = "~/App_Data/BlogPosts";
        }

        public List<BlogPost> GetBlogPosts(int numberOfPosts = 10)
        {
            var fullDirectoryPath = HttpContext.Current.Server.MapPath(_blogFilePath);
            List<string> files = Directory.GetFiles(fullDirectoryPath, "*.md").ToList();
            var posts = new List<BlogPost>();

            //TODO: Parse filename for date so we can limit number of posts before building BlogPost objects

            foreach (string fileName in files)
            {
                var fileContents = File.ReadAllText(fileName);
                string config = fileContents.Substring(0, fileContents.IndexOf('}') + 1);
                string body = fileContents.Substring(fileContents.IndexOf('}') + 1).Trim();

                BlogPost post = new JavaScriptSerializer().Deserialize<BlogPost>(config);
                post.Body = new Markdown(new MarkdownOptions { AutoNewLines = true }).Transform(body).Trim(); // Add formatted body
                posts.Add(post);
            }
            return posts.OrderByDescending(p => p.Date).Take(numberOfPosts).ToList();
        }
    }
}
