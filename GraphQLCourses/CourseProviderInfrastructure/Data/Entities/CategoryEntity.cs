using System.ComponentModel.DataAnnotations;

namespace CourseProviderInfrastructure.Data.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}