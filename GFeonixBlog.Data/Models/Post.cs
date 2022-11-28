namespace GFeonixBlog.Data.Models;
// 文章
public class Post
{
    public int Id { get; set; }

    // 标题
    public string Title { get; set; }

    // 文章状态，提取原markdown文件的文件名前缀，用于区分文章状态，例子如下
    // 《（未完成）StarBlog博客开发笔记(3)：模型设计》
    // 《（未发布）StarBlog博客开发笔记(3)：模型设计》
    public string? Status { get; set; }

    // 是否发表（不发表的话就是草稿状态）
    public bool IsPublish { get; set; }

    // 梗概
    public string? Summary { get; set; }

    // 内容（markdown格式）
    public string? Content { get; set; }

    // 博客在导入前的相对路径
    // 如："系列/AspNetCore开发笔记"
    public string? Path { get; set; }

    // 创建时间
    public DateTime CreationTime { get; set; }

    // 上次更新时间
    public DateTime LastUpdateTime { get; set; }

    // 分类ID
    public int CategoryId { get; set; }

    // 分类
    public Category? Category { get; set; }

    public string? Categories { get; set; }
}