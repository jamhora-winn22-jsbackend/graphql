
using CourseProviderInfrastructure.Data.Contexts;
using CourseProviderInfrastructure.Data.Entities;
using CourseProviderInfrastructure.Factories;
using CourseProviderInfrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProviderInfrastructure.Services;

public interface ICourseService
{
    Task<Course> AddCourseAsync(CourseCreateRequest request);
    Task<Course> GetCourseByIdAsync(string id);
    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<Course> UpdateCourseAsync(CourseUpdateRequest request);
    Task<bool> DeleteCourseAsync(string id);
}
public class CourseService(IDbContextFactory<DataContext> contextFactory) : ICourseService
{
    private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

    public async Task<Course> AddCourseAsync(CourseCreateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();

        var courseEntity = CourseFactory.CreateCourse(request);
        context.Courses.Add(courseEntity);

        if (string.IsNullOrEmpty(courseEntity.Id))
        {
            throw new ArgumentException("Course (partition key) must be provided.");
        }


        await context.SaveChangesAsync();

        return CourseFactory.CreateCourse(courseEntity);
    }

    public async Task<bool> DeleteCourseAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if (courseEntity == null)
            return false;
        
        context.Courses.Remove(courseEntity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Course> GetCourseByIdAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        return courseEntity == null ? null! : CourseFactory.CreateCourse(courseEntity);
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        await using var context = _contextFactory.CreateDbContext();
        var courseEntities = await context.Courses.ToListAsync();

        return courseEntities.Select(CourseFactory.CreateCourse);
    }

    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest request)
    {
        await using var context = _contextFactory.CreateDbContext();
        var existingCourse = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (existingCourse == null)
            return null!;

        var updatedCourseEntity = CourseFactory.UpdateCourse(request);
        updatedCourseEntity.Id = existingCourse.Id;
        context.Entry(existingCourse).CurrentValues.SetValues(updatedCourseEntity);

        await context.SaveChangesAsync();
        return CourseFactory.CreateCourse(existingCourse);
    }
}
