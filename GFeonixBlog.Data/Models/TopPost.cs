namespace GFeonixBlog.Data.Models;
// 置顶文章
public class TopPost
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public Post Post { get; set; }
}