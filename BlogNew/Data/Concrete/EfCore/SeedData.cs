using BlogNew.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogNew.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Tags.Any()) //ilgili tabloda herhangi bir kayıt yoksa tersini aldıgımız için anlamı bu
                {
                    context.Tags.AddRange(
                        new Tag { Text = "Web Programlama" },
                        new Tag { Text = "Backend" },
                        new Tag { Text = "FrontEnd" },
                        new Tag { Text = "FullStack" },
                        new Tag { Text = "Php" }
                        );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "denemekullan" },
                        new User { UserName = "kullanyeni" }
                        );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.net Core",
                            Content = "asp.net core dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1
                        },
                          new Post
                          {
                              Title = "Php Core",
                              Content = "php core dersleri",
                              IsActive = true,
                              PublishedOn = DateTime.Now.AddDays(-20),
                              Tags = context.Tags.Take(2).ToList(),
                              Image = "2.jpg",
                              UserId = 1
                          },
                            new Post
                            {
                                Title = "DjangoCore",
                                Content = "Django core dersleri",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-5),
                                Tags = context.Tags.Take(4).ToList(),
                                Image = "3.jpg",
                                UserId = 2
                            }
                        );
                    context.SaveChanges();
                }//end if
            }
        }
    }
}
