using GFeonixBlog.Data.Contexts;
using GFeonixBlog.Migrate;
using Microsoft.EntityFrameworkCore;

var srcPath = Path.Join("GFeonixBlog.Migrate", "blogs");
var dstPath = Path.Join("GFeonixBlog.Vue", "src", "assets", "blogs");

var contextOptions = new DbContextOptionsBuilder<BlogContext>()
    .UseSqlite("Data Source=GFeonixBlog.Data/GFeonixBlog.db")
    .Options;
using var db = new BlogContext(contextOptions);

var blogs = Directory.GetDirectories(srcPath);

foreach (var blog in blogs)
{
    var mdfile = Directory.GetFiles(blog, "*.md").Single();
    var title = Path.GetFileNameWithoutExtension(mdfile);
    var assets = Path.Join(blog, "assets");

    PostProcessor pp = new(mdfile);
    pp.GetInfo();
    pp.ToDB(db);

    Stack<string> dirs = new(20);

    dirs.Push(assets);

    do
    {
        var currentPath = dirs.Pop();
        var subDirs = Directory.GetDirectories(currentPath);
        var files = Directory.GetFiles(currentPath);

        foreach (var subDir in subDirs)
        {
            dirs.Push(subDir);
        }

        foreach (var file in files)
        {
            var param = Path.Join(blog, "assets");
            var dstfile = file.Replace(param, Path.Join(dstPath, title));
            if (!Directory.Exists(Path.GetDirectoryName(dstfile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dstfile));
            }
            File.Copy(file, dstfile, true);
        }

    } while (dirs.Count > 0);
}