namespace GFeonixBlog.Data.Models;
// 文章分类
public class Category
{
    public int ID { get; set; }

    public string Name { get; set; }

    public Category? Parent { get; set; }

    public List<Post>? Posts { get; set; }
}
