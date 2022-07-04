using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : IdentityDbContext<WriterUser, WriterRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = (localdb)\mssqllocaldb; initial catalog =MvcBlogProject; integrated security = true");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<WriterMessage> WriterMessages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<WriterUser> WriterUsers { get; set; }
        public DbSet<WriterRole> WriterRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }

    }
}
