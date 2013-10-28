using System.Collections.Generic;
using WastingHours.Models;

namespace WastingHours.Infrastructure.Abstract
{
    public interface IBlogPostService
    {
        List<BlogPost> GetBlogPosts(int numberOfPosts);
    }
}