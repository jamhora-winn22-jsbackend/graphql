
namespace CourseProviderInfrastructure.Models;

public class Course
{
    public string Id { get; set; } = null!;
    public bool IsBestSeller { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string DescriptionTitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public string Hours { get; set; } = null!;
    public string LikesProcent { get; set; } = null!;
    public string LikesInNumber { get; set; } = null!;
    public string? ArticelsNumber { get; set; }
    public string? DownloadableResources { get; set; }

    public virtual Category? Category { get; set; }

    public virtual List<LearningObjective>? LearningObjectives { get; set; }
    public virtual List<CourseSteps>? CourseSteps { get; set; }
}
public class Category
{
    public string? CategoryName { get; set; }
}
public class CourseSteps
{
    public string? StepTitle { get; set; } 
    public string? StepDescription { get; set; } 
    public string? StepNumber { get; set; } 

}
public class LearningObjective
{
    public string? Description { get; set; }

}