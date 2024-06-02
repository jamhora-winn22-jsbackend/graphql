
namespace CourseProviderInfrastructure.Models;

public class CourseCreateRequest
{
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

    public virtual CategoryRequest? Category { get; set; }

    public virtual List<LearningObjectiveRequest>? LearningObjectives { get; set; }
    public virtual List<CourseStepsRequest>? CourseSteps { get; set; }
}
public class CategoryRequest
{
    public string? CategoryName { get; set; }
}
public class CourseStepsRequest
{
    public string? StepTitle { get; set; }
    public string? StepDescription { get; set; }
    public string? StepNumber { get; set; }


}
public class LearningObjectiveRequest
{
    public string? Description { get; set; }

}