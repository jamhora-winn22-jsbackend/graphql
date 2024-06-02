
using Azure.Core;
using CourseProviderInfrastructure.Data.Entities;
using CourseProviderInfrastructure.Models;
using Microsoft.Extensions.Logging;

namespace CourseProviderInfrastructure.Factories;

public static class CourseFactory
{
    private static readonly ILogger _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger("CourseFactory");

    public static CourseEntity CreateCourse(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            Id = Guid.NewGuid().ToString(),
            IsBestSeller = request.IsBestSeller,
            Image = request.Image,
            Title = request.Title,
            DescriptionTitle = request.DescriptionTitle,
            Description = request.Description,
            Author = request.Author,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            Hours = request.Hours,
            LikesProcent = request.LikesProcent,
            LikesInNumber = request.LikesInNumber,
            ArticelsNumber = request.ArticelsNumber,
            DownloadableResources = request.DownloadableResources,
            Category = request.Category == null ? null : new CategoryEntity
            {
                CategoryName = request.Category.CategoryName!.ToString(),
            },
            CourseSteps = request.CourseSteps?.Select(step => new CourseStepsEntity
            {
                StepTitle = step.StepTitle,
                StepDescription = step.StepDescription,
                StepNumber = step.StepNumber
            }).ToList(),
            LearningObjectives = request.LearningObjectives?.Select(objective => new LearningObjectiveEntity
            {
                Description = objective.Description
            }).ToList()
        };
    }
    //public static CourseEntity CreateCourse(CourseCreateRequest request)
    //{
    //    try
    //    {
    //        if (request == null)
    //        {
    //            throw new ArgumentNullException(nameof(request), "CourseCreateRequest cannot be null");
    //        }

    //        _logger.LogInformation("Creating CourseEntity from CourseCreateRequest: {@Request}", request);

    //        var courseEntity = new CourseEntity
    //        {
    //            IsBestSeller = request.IsBestSeller, // Assuming default value
    //            Image = request.Image ?? string.Empty, // Assuming default value
    //            Title = request.Title ?? string.Empty, // Assuming default value
    //            DescriptionTitle = request.DescriptionTitle ?? string.Empty, // Assuming default value
    //            Description = request.Description ?? string.Empty, // Assuming default value
    //            Author = request.Author ?? string.Empty, // Assuming default value
    //            Price = request.Price ?? "0", // Assuming default value
    //            DiscountPrice = request.DiscountPrice ?? "0", // Assuming default value
    //            Hours = request.Hours ?? "0", // Assuming default value
    //            LikesProcent = request.LikesProcent ?? "0", // Assuming default value
    //            LikesInNumber = request.LikesInNumber ?? "0", // Assuming default value
    //            ArticelsNumber = request.ArticelsNumber ?? "0", // Assuming default value
    //            DownloadableResources = request.DownloadableResources ?? "0", // Assuming default value
    //            Category = request.Category == null ? null : new CategoryEntity
    //            {
    //                CategoryName = request.Category.CategoryName?.ToString() ?? string.Empty, // Assuming default value
    //            },
    //            CourseSteps = request.CourseSteps?.Select(step => new CourseStepsEntity
    //            {
    //                StepTitle = step.StepTitle ?? string.Empty, // Assuming default value
    //                StepDescription = step.StepDescription ?? string.Empty, // Assuming default value
    //                StepNumber = step.StepNumber ?? "0" // Assuming default value
    //            }).ToList() ?? new List<CourseStepsEntity>(), // Assuming default value
    //            LearningObjectives = request.LearningObjectives?.Select(objective => new LearningObjectiveEntity
    //            {
    //                Description = objective.Description ?? string.Empty // Assuming default value
    //            }).ToList() ?? new List<LearningObjectiveEntity>() // Assuming default value
    //        };

    //        _logger.LogInformation("Successfully created CourseEntity: {@CourseEntity}", courseEntity);

    //        return courseEntity;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "An error occurred while creating CourseEntity");
    //        throw;
    //    }
    //}

    public static CourseEntity UpdateCourse(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            IsBestSeller = request.IsBestSeller,
            Image = request.Image,
            Title = request.Title,
            DescriptionTitle = request.DescriptionTitle,
            Description = request.Description,
            Author = request.Author,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            Hours = request.Hours,
            LikesProcent = request.LikesProcent,
            LikesInNumber = request.LikesInNumber,
            ArticelsNumber = request.ArticelsNumber,
            DownloadableResources = request.DownloadableResources,
            Category = request.Category == null ? null : new CategoryEntity
            {
                CategoryName = request.Category.CategoryName!.ToString(),
            },
            CourseSteps = request.CourseSteps?.Select(step => new CourseStepsEntity
            {
                StepTitle = step.StepTitle,
                StepDescription = step.StepDescription,
                StepNumber = step.StepNumber
            }).ToList(),
            LearningObjectives = request.LearningObjectives?.Select(objective => new LearningObjectiveEntity
            {
                Description = objective.Description
            }).ToList()
        };
    }

    public static Course CreateCourse(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            IsBestSeller = entity.IsBestSeller,
            Image = entity.Image,
            Title = entity.Title,
            DescriptionTitle = entity.DescriptionTitle,
            Description = entity.Description,
            Author = entity.Author,
            Price = entity.Price,
            DiscountPrice = entity.DiscountPrice,
            Hours = entity.Hours,
            LikesProcent = entity.LikesProcent,
            LikesInNumber = entity.LikesInNumber,
            ArticelsNumber = entity.ArticelsNumber,
            DownloadableResources = entity.DownloadableResources,
            Category = entity.Category == null ? null : new Category
            {
                CategoryName = entity.Category.CategoryName!.ToString(),
            },
            CourseSteps = entity.CourseSteps?.Select(step => new CourseSteps
            {
                StepTitle = step.StepTitle,
                StepDescription = step.StepDescription,
                StepNumber = step.StepNumber
            }).ToList(),
            LearningObjectives = entity.LearningObjectives?.Select(objective => new LearningObjective
            {
                Description = objective.Description
            }).ToList()
        };
    }

    //public static CategoryEntity CreateCategoryEntity(string categoryName)
    //{
    //    return new CategoryEntity
    //    {
    //        CategoryName = categoryName
    //    };
    //}

    //public static CourseStepsEntity CreateCourseStepsEntity(string stepTitle, string stepDescription, string stepNumber)
    //{
    //    return new CourseStepsEntity
    //    {
    //        StepTitle = stepTitle,
    //        StepDescription = stepDescription,
    //        StepNumber = stepNumber
    //    };
    //}

    //public static LearningObjectiveEntity CreateLearningObjectiveEntity(string description)
    //{
    //    return new LearningObjectiveEntity
    //    {
    //        Description = description
    //    };
    //}
}
