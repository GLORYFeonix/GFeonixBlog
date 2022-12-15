using GFeonixBlog.Data.Models;
using GFeonixBlog.Migrate;

string importDir = Path.GetFullPath("./GFeonixBlog.Migrate/blogs/");
string assetsPath = Path.GetFullPath("./GFeonixBlog.Web/wwwroot/media/blog");

CopyBlogs(@".\GFeonixBlog.Migrate\blogs");

void CopyBlogs(string root)
{
    var rootPath = System.IO.Path.GetFullPath(root);

    Console.WriteLine($"正在扫描文件夹：{root}");
    System.Console.WriteLine();

    Stack<string> dirs = new Stack<string>(20);

    if (!System.IO.Directory.Exists(root))
    {
        throw new ArgumentException();
    }
    dirs.Push(root);

    while (dirs.Count > 0)
    {
        string currentDir = dirs.Pop();
        string[] subDirs;
        try
        {
            subDirs = System.IO.Directory.GetDirectories(currentDir);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
            continue;
        }
        catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
            continue;
        }

        string[] files;
        try
        {
            files = System.IO.Directory.GetFiles(currentDir, "*.md");
        }
        catch (UnauthorizedAccessException e)
        {

            Console.WriteLine(e.Message);
            continue;
        }
        catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
            continue;
        }

        foreach (string file in files)
        {
            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);

                Console.WriteLine(fi.Name);

                var postPath = fi.DirectoryName.Replace(rootPath, "").Remove(0, 1);

                var categoryNames = postPath.Split("\\").SkipLast(1).ToList();

                Console.WriteLine($"分类: {string.Join("/", categoryNames)}");

                var categories = new List<Category>();

                if (categoryNames.Count() > 0)
                {
                    var rootCategory = new Category() { Name = categoryNames[0] };
                    categories.Add(rootCategory);
                    Console.WriteLine($"+ 添加分类: {rootCategory.Id}. {rootCategory.Name}");
                    for (var i = 1; i < categoryNames.Count; i++)
                    {
                        var name = categoryNames[i];
                        var parent = categories[i - 1];
                        var category = new Category() { Name = name, ParentId = parent.Id, Parent = parent };
                        categories.Add(category);
                        Console.WriteLine($"+ 添加子分类：{category.Id}. {category.Name}");
                    }
                }

                var reader = fi.OpenText();
                var content = reader.ReadToEnd();
                reader.Close();

                // 保存文章
                var post = new Post
                {
                    Title = fi.Name.Replace(".md", ""),
                    Content = content,
                    CreationTime = fi.CreationTime,
                    LastUpdateTime = fi.LastWriteTime,
                    Categories = categories
                };
                if (categories.Count > 0)
                {
                    post.Category = categories[^1];
                    post.CategoryId = categories[^1].Id;
                }

                var processor = new PostProcessor(importDir, assetsPath, post);
                // // 处理文章标题和状态
                // processor.InflateStatusTitle();
                // // 处理文章正文内容
                // // 导入文章的时候一并导入文章里的图片，并对图片相对路径做替换操作
                // post.Content = processor.MarkdownParse();
                processor.CopyPost();
                post.Summary = processor.GetSummary(200);

                System.Console.WriteLine();
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }

        foreach (string str in subDirs)
        {
            dirs.Push(str);
        }
    }
}