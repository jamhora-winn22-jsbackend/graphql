
using CourseProviderInfrastructure.Models;
using CourseProviderInfrastructure.Services;

namespace CourseProviderInfrastructure.GraphQl.Mutations;

public class CourseMutation(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("createCourse")]
    public async Task<Course> AddCourseAsync(CourseCreateRequest input)
    {
        return await _courseService.AddCourseAsync(input);
    }

    [GraphQLName("updateCourse")]
    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest input)
    {
        return await _courseService.UpdateCourseAsync(input);
    }

    [GraphQLName("deleteCourse")]
    public async Task<bool> DeleteCourseAsync(string id)
    {
        return await _courseService.DeleteCourseAsync(id);
    }
}
