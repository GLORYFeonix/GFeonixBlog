using GFeonixBlog.Data.Models;

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
}