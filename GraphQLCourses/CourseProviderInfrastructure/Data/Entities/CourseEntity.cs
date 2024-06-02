
using System.ComponentModel.DataAnnotations;

namespace CourseProviderInfrastructure.Data.Entities;

public class CourseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string PartitionKey { get; set; } = "Course";
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

    public virtual CategoryEntity? Category { get; set; }

    public virtual List<LearningObjectiveEntity>? LearningObjectives { get; set; }
    public virtual List<CourseStepsEntity>? CourseSteps { get; set; }
}
