using BlogNew.Data.Abstract;
using BlogNew.Entity;

namespace BlogNew.Data.Concrete.EfCore
{
    public class EfTagRepository : ITagRepository
    {
        private readonly BlogContext _blogContext;
        public EfTagRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IQueryable<Tag> Tags => _blogContext.Tags;

        public void CreateTag(Tag tag)
        {
            _blogContext.Tags.Add(tag);
            _blogContext.SaveChanges();
        }
    }
}
