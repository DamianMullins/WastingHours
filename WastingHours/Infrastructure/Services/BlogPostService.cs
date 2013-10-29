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
        private readonly HttpContextBase _httpContext;

        public BlogPostService(HttpContextBase httpContext)
        {
            _blogFilePath = "~/App_Data/BlogPosts";
            _httpContext = httpContext;
        }

        public BlogPost GetBlogPost(string title)
        {
            string filename = ScanForFiles().FirstOrDefault(f => f.Contains(title));
            BlogPost post = BuildBlogPost(filename, false);
            return post;
        }

        public List<BlogPost> GetBlogPosts(bool isPreview = true)
        {
            return ProcessBlogPosts(isPreview).OrderByDescending(p => p.Date).ToList();
        }

        public List<BlogPost> GetBlogPosts(int numberOfPosts, bool isPreview = true)
        {
            return ProcessBlogPosts(isPreview).OrderByDescending(p => p.Date).Take(numberOfPosts).ToList();
        }

        private IEnumerable<string> ScanForFiles()
        {
            var fullDirectoryPath = _httpContext.Server.MapPath(_blogFilePath);
            var files = Directory.GetFiles(fullDirectoryPath, "*.md");
            return files;
        }

        private BlogPost BuildBlogPost(string filename, bool isPreview)
        {
            var fileContents = File.ReadAllText(filename);
            string config = fileContents.Substring(0, fileContents.IndexOf('}') + 1);
            string body = fileContents.Substring(fileContents.IndexOf('}') + 1).Trim();
            BlogPost post = new JavaScriptSerializer().Deserialize<BlogPost>(config);

            if (!isPreview)
            {
                var options = new MarkdownOptions { AutoNewLines = true };
                post.Body = new Markdown(options).Transform(body).Trim(); // Add formatted body
            }
            return post;
        }

        private IEnumerable<BlogPost> ProcessBlogPosts(bool isPreview)
        {
            var files = ScanForFiles();
            return files.Select(filename => BuildBlogPost(filename, isPreview)).ToList();
        }
    }
}
