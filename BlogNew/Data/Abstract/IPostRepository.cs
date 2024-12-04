using BlogNew.Entity;

namespace BlogNew.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; } //IQueryable anlamı extre filtreme yapmak için bu tipte oldugunu belirttik
        void CreatePost(Post post);
    }
}
