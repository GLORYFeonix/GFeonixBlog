namespace GFeonixBlog.Data.Models;

/// <summary>
/// 推荐图片
/// </summary>
public class FeaturedPhoto
{
    public int Id { get; set; }
    public string PhotoId { get; set; }
    public Photo Photo { get; set; }
}