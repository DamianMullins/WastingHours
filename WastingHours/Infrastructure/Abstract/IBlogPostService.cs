using System.Collections.Generic;
using WastingHours.Models;

namespace WastingHours.Infrastructure.Abstract
{
    public interface IBlogPostService
    {
        /// <summary>
        /// Retreive a single blog post by its title.
        /// </summary>
        /// <param name="title">Title of the blog post to retrieve.</param>
        /// <returns>Single blog post.</returns>
        BlogPost GetBlogPost(string title);

        /// <summary>
        /// Retrieve a list of blog posts.
        /// </summary>
        /// <param name="isPreview">If this is for a preview list do not transform the Markdown-formatted text to HTML.</param>
        /// <returns>List of blog posts.</returns>
        List<BlogPost> GetBlogPosts(bool isPreview);

        /// <summary>
        /// Retrieve a list of blog posts.
        /// </summary>
        /// <param name="numberOfPosts">The maximum number of blog posts to retrieve.</param>
        /// <param name="isPreview">If this is for a preview list do not transform the Markdown-formatted text to HTML.</param>
        /// <returns>List of blog posts.</returns>
        List<BlogPost> GetBlogPosts(int numberOfPosts, bool isPreview);
    }
}
