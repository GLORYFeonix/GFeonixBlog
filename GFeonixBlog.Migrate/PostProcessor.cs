using GFeonixBlog.Data.Contexts;
using GFeonixBlog.Data.Models;
using Markdig;

namespace GFeonixBlog.Migrate;

public class PostProcessor
{
    private string _path { get; set; }
    private Post _post { get; set; }

    public PostProcessor(string path)
    {
        _path = path;
        _post = new();
    }

    /// <summary>
    /// 获取标题
    /// </summary>
    private void GetTittle()
    {
        _post.Title = Path.GetFileNameWithoutExtension(_path);
    }

    /// <summary>
    /// 获取内容
    /// </summary>
    private void GetContent()
    {
        using StreamReader sr = new(_path);
        var mdText = sr.ReadToEnd();
        _post.Markdown = mdText;
        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        _post.Content = Markdown.ToPlainText(mdText, pipeline);
    }

    /// <summary>
    /// 获取摘要
    /// </summary>
    private void GetSummary()
    {
        _post.Summary = _post.Content[..200];
    }

    /// <summary>
    /// 获取时间信息
    /// </summary>
    private void GetTimeInfo()
    {
        var fi = new FileInfo(_path);
        _post.CreateTime = fi.CreationTime;
        _post.UpdateTime = fi.LastWriteTime;
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
        var post = db.Posts.SingleOrDefault(p => p.Title == _post.Title);

        if (post == null)
        {
            db.Posts.Add(_post);
        }
        else
        {
            post.Title = _post.Title;
            post.Summary = _post.Summary;
            post.Content = _post.Content;
            post.Markdown = _post.Markdown;
            post.CreateTime = _post.CreateTime;
            post.UpdateTime = _post.UpdateTime;
            post.Categories = _post.Categories;
        }
        db.SaveChanges();
    }

    /// <summary>
    /// 生成 html 文件
    /// </summary>
    /// <param name="dstPath"></param>
    public void ToHtml(string dstPath)
    {
        if (!Directory.Exists(Path.GetDirectoryName(dstPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dstPath));
        }

        using StreamReader sr = new(_path);
        using StreamWriter sw = new(dstPath.Replace(".md", ".html"));

        var text = sr.ReadToEnd();
        text = Markdown.ToHtml(text);
        sw.Write(text);
    }
}