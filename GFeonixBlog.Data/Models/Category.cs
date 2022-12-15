namespace GFeonixBlog.Data.Models;
// 文章分类
public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ParentId { get; set; }

    public Category? Parent { get; set; }

    // public bool Visible { get; set; } = true;

    public List<Post>? Posts { get; set; }
}
