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
                 UserLearningItems = lp.UserLearningItems.Select(userLearningItem => new LearningItemResponse()
                 {
                     Category = userLearningItem.LearningItem!.Category switch
                     {
                         Category.Database => CategoryUi.Database,
                         Category.Frontend => CategoryUi.Frontend,
                         Category.Backend => CategoryUi.Backend,
                         _ => throw new InvalidOperationException()
                     },
                     Description = userLearningItem.LearningItem.Description,
                     Id = userLearningItem.Id,
                     Name = userLearningItem.LearningItem.Name,
                     Completed = userLearningItem.Completed
                 }).ToList()
             }
         ).ToList();

        return new LearningPathsResponse()
        {
            LearningPaths = learningPaths
        };
    }
}