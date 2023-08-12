using GFeonixBlog.Data.Contexts;
using GFeonixBlog.Data.Models;
using Markdig;
using Markdig.Syntax;

namespace GFeonixBlog.Migrate;

public class PostProcessor
{
    private string Path { get; set; }
    private Post Post { get; set; }

    public PostProcessor(string path)
    {
        Path = path;
        Post = new();
    }

    /// <summary>
    /// 获取标题
    /// </summary>
    private void GetTittle()
    {
        Post.Title = System.IO.Path.GetFileNameWithoutExtension(Path);
    }

    /// <summary>
    /// 获取内容
    /// </summary>
    private void GetContent()
    {
        using StreamReader sr = new(Path);
        var mdText = sr.ReadToEnd();
        Post.Markdown = mdText;
        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        Post.Content = Markdown.ToPlainText(mdText, pipeline);
        Post.Html = Markdown.ToHtml(mdText, pipeline);
    }

    /// <summary>
    /// 获取摘要
    /// </summary>
    private void GetSummary()
    {
        Post.Summary = Post.Content[..200];
    }

    /// <summary>
    /// 获取时间信息
    /// </summary>
    private void GetTimeInfo()
    {
        var fi = new FileInfo(Path);
        Post.CreateTime = fi.CreationTime;
        Post.UpdateTime = fi.LastWriteTime;
    }

    /// <summary>
    /// 获取分类
    /// </summary>
    private void GetCategories()
    {

    }

    /// <summary>
    /// 获取文章信息
    /// </summary>
    public void GetInfo()
    {
        GetTittle();
        GetContent();
        GetSummary();
        GetTimeInfo();
        GetCategories();
    }

    /// <summary>
    /// 存储到数据库
    /// </summary>
    /// <param name="db"></param>
    public void ToDB(BlogContext db)
    {
        var post = db.Posts.SingleOrDefault(p => p.Title == Post.Title);

        if (post == null)
        {
            db.Posts.Add(Post);
        }
        else
        {
            post.Title = Post.Title;
            post.Summary = Post.Summary;
            post.Content = Post.Content;
            post.Markdown = Post.Markdown;
            post.Html = Post.Html;
            post.CreateTime = Post.CreateTime;
            post.UpdateTime = Post.UpdateTime;
            post.Categories = Post.Categories;
        }
        db.SaveChanges();
    }

    /// <summary>
    /// 生成 html 文件
    /// </summary>
    /// <param name="dstPath"></param>
    public void ToHtml(string dstPath)
    {
        if (!Directory.Exists(System.IO.Path.GetDirectoryName(dstPath)))
        {
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dstPath));
        }

        using StreamReader sr = new(Path);
        using StreamWriter sw = new(dstPath.Replace(".md", ".html"));

        var text = sr.ReadToEnd();
        text = Markdown.ToHtml(text);
        sw.Write(text);
    }
}