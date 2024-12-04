using BlogNew.Data.Abstract;
using BlogNew.Data.Concrete.EfCore;
using BlogNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogNew.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository; 
        }
        public IActionResult Index()
        {
            return View(
                new PostViewModel
                {
                    Posts = _postRepository.Posts.ToList(),
                    
                }
                );
        }
    }
}
