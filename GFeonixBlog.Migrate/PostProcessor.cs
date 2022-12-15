using System.Text.RegularExpressions;
using GFeonixBlog.Data.Models;
using Markdig;
using Markdig.Renderers.Normalize;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace GFeonixBlog.Migrate;

public class PostProcessor
{
    private readonly Post _post;
    private readonly string _importPath;
    private readonly string _assetsPath;

    public PostProcessor(string importPath, string assetsPath, Post post)
    {
        _post = post;
        _assetsPath = assetsPath;
        _importPath = importPath;
    }

    // 获取摘要
    public string GetSummary(int length)
    {
        return _post.Content == null ? string.Empty : Markdown.ToPlainText(_post.Content).Substring(0, length);
    }

    // // 获取文章状态
    // public void InflateStatusTitle()
    // {
    //     const string pattern = @"^（(.+)）(.+)$";
    //     var status = _post.Status ?? "已发布";
    //     var title = _post.Title;
    //     if (string.IsNullOrEmpty(title))
    //     {
    //         _post.Status = status;
    //         _post.Title = $"未命名文章{_post.CreationTime.ToLongDateString()}";
    //     }

    //     var result = Regex.Match(title, pattern);
    //     if (result.Success)
    //     {
    //         status = result.Groups[1].Value;
    //         title = result.Groups[2].Value;
    //     }
    //     _post.Status = status;
    //     _post.Title = title;

    //     if (!new[] { "已发布" }.Contains(_post.Status))
    //     {
    //         _post.IsPublish = false;
    //     }
    // }

    // // Markdown内容解析，复制图片 & 替换图片链接
    // public string MarkdownParse()
    // {
    //     if (_post.Content == null)
    //     {
    //         return string.Empty;
    //     }

    //     var document = Markdown.Parse(_post.Content);

    //     foreach (var node in document.AsEnumerable())
    //     {
    //         if (node is not ParagraphBlock { Inline: { } } paragraphBlock) continue;
    //         foreach (var inline in paragraphBlock.Inline)
    //         {
    //             if (inline is not LinkInline { IsImage: true } linkInline) continue;

    //             if (linkInline.Url == null) continue;
    //             if (linkInline.Url.StartsWith("http")) continue;

    //             // 路径处理
    //             var imgPath = Path.Combine(_importPath, _post.Title, linkInline.Url);
    //             var imgFilename = Path.GetFileName(linkInline.Url);
    //             var destDir = Path.Combine(_assetsPath, _post.Title.ToString());
    //             if (!Directory.Exists(destDir))
    //             {
    //                 Directory.CreateDirectory(destDir);
    //             }
    //             var destPath = Path.Combine(destDir, imgFilename);
    //             // if (File.Exists(destPath))
    //             // {
    //             //     // 图片重名处理
    //             //     var imgId = GuidUtils.GuidTo16String();
    //             //     imgFilename = $"{Path.GetFileNameWithoutExtension(imgFilename)}-{imgId}.{Path.GetExtension(imgFilename)}";
    //             //     destPath = Path.Combine(destDir, imgFilename);
    //             // }

    //             // 替换图片链接
    //             // linkInline.Url = imgFilename;
    //             // 复制图片
    //             File.Copy(imgPath, destPath);

    //             Console.WriteLine($"复制 {imgPath} 到 {destPath}");
    //         }
    //     }


    //     using var writer = new StringWriter();
    //     var render = new NormalizeRenderer(writer);
    //     render.Render(document);
    //     return writer.ToString();
    // }

    public void CopyPost()
    {
        string categoriesPath = string.Empty;
        foreach (var category in _post.Categories)
        {
            categoriesPath = Path.Join(categoriesPath, category.Name);
        }

        string sourcePath = Path.Join(_importPath, categoriesPath, _post.Title);
        string targetPath = Path.Join(_assetsPath, categoriesPath, _post.Title);

        string[] files = System.IO.Directory.GetFiles(sourcePath);

        // Copy the files and overwrite destination files if they already exist.
        foreach (var file in files)
        {
            // Use static Path methods to extract only the file name from the path.
            var fileName = System.IO.Path.GetFileName(file);
            var destPath = System.IO.Path.Combine(targetPath, fileName);
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            System.IO.File.Copy(file, destPath, true);
        }
    }
}