using GFeonixBlog.Data.Contexts;
using GFeonixBlog.Data.Models;
using Markdig;
using Markdig.Syntax;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GFeonixBlog.Api.Services;

[Route("[controller]/[action]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly BlogContext _blogContext;

    public PostController(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }

    [EnableCors("MyPolicy")]
    [HttpGet]
    public async Task<List<Post>> GetPostsList()
    {
        return _blogContext.Posts.ToList();
    }

    [EnableCors("MyPolicy")]
    [HttpGet]
    public async Task<Post> GetPostById(int id)
    {
        return _blogContext.Posts.FirstOrDefault(p => p.ID == id);
    }

    [EnableCors("MyPolicy")]
    [HttpGet]
    public async Task<List<TocNode>> GetPostTOCById(int id)
    {
        var post = _blogContext.Posts.FirstOrDefault(p => p.ID == id);
        var document = Markdown.Parse(post.Markdown);
        var headings = new List<Heading>();
        foreach (var block in document.AsEnumerable())
        {
            if (block is not HeadingBlock heading)
            {
                continue;
            }
            var item = new Heading { Level = heading.Level, Text = heading.Inline?.FirstChild?.ToString() };
            headings.Add(item);
        }

        var chineseTitleCount = 0;
        for (var i = 0; i < headings.Count; i++)
        {
            var item = headings[i];
            item.Id = i;

            // TODO:中文开头，夹带英文的标题处理
            var text = item.Text ?? "";
            if (System.Text.RegularExpressions.Regex.IsMatch(text, "[\u4e00-\u9fbb]"))
            {
                item.Slug = chineseTitleCount == 0 ? "section" : $"section-{chineseTitleCount}";
                chineseTitleCount++;
            }
            else
            {
                item.Slug = text.Replace(" ", "-").ToLower();
            }

            for (var j = i; j >= 0; j--)
            {
                var preItem = headings[j];
                if (item.Level == preItem.Level + 1)
                {
                    item.Pid = j;
                    break;
                }
            }
        }
        List<TocNode> Nodes = GetNodes(headings, -1);
        return Nodes;
    }

    private List<TocNode>? GetNodes(List<Heading> headings, int pid = -1)
    {
        var nodes = headings.Where(a => a.Pid == pid).ToList();
        return nodes.Count == 0 ? null
          : nodes.Select(a => new TocNode { Text = a.Text, Href = $"#{a.Slug}", Nodes = GetNodes(headings, a.Id) }).ToList();
    }

    [EnableCors("MyPolicy")]
    [HttpDelete]
    public async Task DeletePosts()
    {
        var blogs = _blogContext.Posts.ToList();
        _blogContext.RemoveRange(blogs);
        _blogContext.SaveChanges();
        return;
    }
}