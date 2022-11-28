namespace GFeonixBlog.Data.Models;
// 推荐分类
public class FeaturedCategory
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    // 重新定义的推荐名称
    public string Name { get; set; }

    // 推荐分类解释
    public string Description { get; set; }

    /// <summary>
    /// 图标
    /// <list type="number">
    ///     <listheader>例子</listheader>
    ///     <item>fa-solid fa-c</item>
    ///     <item>fa-brands fa-python</item>
    ///     <item>fa-brands fa-android</item>
    /// </list>
    /// </summary>
    public string IconCssClass { get; set; }
}
