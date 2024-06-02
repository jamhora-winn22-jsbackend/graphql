

using CourseProviderInfrastructure.Data.Entities;

namespace CourseProviderInfrastructure.GraphQl.ObjectTypes;

public class CourseType : ObjectType<CourseEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseEntity> descriptor)
    {
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.IsBestSeller).Type<BooleanType>();
        descriptor.Field(x => x.Image).Type<StringType>();
        descriptor.Field(x => x.Title).Type<StringType>();
        descriptor.Field(x => x.DescriptionTitle).Type<StringType>();
        descriptor.Field(x => x.Description).Type<StringType>();
        descriptor.Field(x => x.Author).Type<StringType>();
        descriptor.Field(x => x.Price).Type<StringType>();
        descriptor.Field(x => x.DiscountPrice).Type<StringType>();
        descriptor.Field(x => x.Hours).Type<StringType>();
        descriptor.Field(x => x.LikesProcent).Type<StringType>();
        descriptor.Field(x => x.LikesInNumber).Type<StringType>();
        descriptor.Field(x => x.ArticelsNumber).Type<StringType>();
        descriptor.Field(x => x.DownloadableResources).Type<StringType>();
        descriptor.Field(x => x.Category).Type<CtegoryType>();
        descriptor.Field(x => x.CourseSteps).Type<ListType<CourseStepsType>>();
        descriptor.Field(x => x.LearningObjectives).Type<ListType<LearningObjectiveType>>();
    }
}
public class CtegoryType : ObjectType<CategoryEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CategoryEntity> descriptor)
    {
        descriptor.Field(x => x.CategoryName).Type<StringType>();
    }
}
public class CourseStepsType : ObjectType<CourseStepsEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseStepsEntity> descriptor)
    {
        descriptor.Field(x => x.StepNumber).Type<IntType>();
        descriptor.Field(x => x.StepTitle).Type<StringType>();
        descriptor.Field(x => x.StepDescription).Type<StringType>();
    }
}
public class LearningObjectiveType : ObjectType<LearningObjectiveEntity>
{
    protected override void Configure(IObjectTypeDescriptor<LearningObjectiveEntity> descriptor)
    {
        descriptor.Field(x => x.Description).Type<StringType>();
    }
}