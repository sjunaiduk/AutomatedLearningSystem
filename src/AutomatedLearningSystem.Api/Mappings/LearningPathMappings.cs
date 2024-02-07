using AutomatedLearningSystem.Contracts.LearningPaths;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Api.Mappings;

public static class LearningPathMappings
{
    public static LearningPathsResponse ToLearningPathsResponse(this List<LearningPath> learningPathsDomain)
    {
       var learningPaths = learningPathsDomain.Select(lp =>
            new LearningPathResponse()
            {
                Id = lp.Id,
                LearningItems = lp.LearningItems.Select(li => new LearningItemResponse()
                {
                    Category = li.Category switch
                    {
                        Category.Database => CategoryUi.Database,
                        Category.Frontend => CategoryUi.Frontend,
                        Category.Backend => CategoryUi.Backend,
                        _ => throw new InvalidOperationException()
                    },
                    Description = li.Description,
                    Id = li.Id,
                    Name = li.Name
                }).ToList()
            }
        ).ToList();

        return new LearningPathsResponse()
        {
            LearningPaths = learningPaths
        };
    }
}