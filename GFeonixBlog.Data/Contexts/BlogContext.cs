using GFeonixBlog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GFeonixBlog.Data.Contexts;

public class BlogContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }

    public BlogContext()
    {

    }

    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {

    }
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlite($"Data Source=GFeonixBlog.db");
}
