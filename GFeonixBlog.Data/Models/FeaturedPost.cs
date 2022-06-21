namespace GFeonixBlog.Data.Models;

/// <summary>
/// 推荐文章
/// </summary>
public class FeaturedPost
{
    public int Id { get; set; }
    public string PostId { get; set; }
    public Post Post { get; set; }
}