namespace GFeonixBlog.Data.Models;

/// <summary>
/// 置顶文章
/// </summary>
public class TopPost
{
    public int Id { get; set; }
    public string PostId { get; set; }
    public Post Post { get; set; }
}