using BlogNew.Data.Abstract;
using BlogNew.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogNew.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult Index()
        {
            return View(_postRepository.Posts.ToList());
        }
    }
}
