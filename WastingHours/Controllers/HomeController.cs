using System.Collections.Generic;
using System.Web.Mvc;
using WastingHours.Infrastructure.Abstract;
using WastingHours.Models;

namespace WastingHours.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public HomeController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public ActionResult Index()
        {
            List<BlogPost> posts = _blogPostService.GetBlogPosts(numberOfPosts: 3, isPreview: true);

            return View(posts);
        }

        public ActionResult Post(string title)
        {
            BlogPost post = _blogPostService.GetBlogPost(title);
            return View(post);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
