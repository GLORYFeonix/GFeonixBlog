namespace GFeonixBlog.Data.Models;

public class Heading
{
    public int Id { get; set; }
    public int Pid { get; set; } = -1;
    public string? Text { get; set; }
    public string? Slug { get; set; }
    public int Level { get; set; }
}

public class TocNode
{
    public string? Text { get; set; }
    public string? Href { get; set; }
    public List<TocNode>? Nodes { get; set; }
}