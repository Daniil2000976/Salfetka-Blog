using System.Collections.ObjectModel;
using System.Linq;
using SalfetkaBlog.Models;

namespace SalfetkaBlog.Controllers
{
    public class PostController
    {
        public ObservableCollection<Post> Posts { get; set; }

        public PostController()
        {
            Posts = new ObservableCollection<Post>();
        }

        public void AddPost(Post post)
        {
            Posts.Add(post);
        }

        public void EditPost(Post post)
        {
            var existingPost = Posts.FirstOrDefault(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
            }
        }

        public void DeletePost(int postId)
        {
            var post = Posts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                Posts.Remove(post);
            }
        }
    }
}
