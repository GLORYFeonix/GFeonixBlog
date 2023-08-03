namespace GFeonixBlog.Data.Models;
// 文章
public class Post
{
    public int ID { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 梗概
    /// </summary>
    public string Summary { get; set; }

    /// <summary>
    /// 内容（PlainText格式）
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 内容 (Markdown格式)
    /// </summary>
    public string Markdown { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdateTime { get; set; }

    /// <summary>
    /// 分类
    /// </summary>
    public List<Category>? Categories { get; set; }
}