using AutomatedLearningSystem.Contracts.LearningPaths;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Api.Mappings;

public static class LearningPathMappings
{
    public static List<LearningPathResponse> ToLearningPathsResponse(this List<LearningPath> learningPathsDomain)
    {
        var learningPaths = learningPathsDomain.Select(lp =>
             new LearningPathResponse()
             {
                 Id = lp.Id,
                 Name = lp.Name,
                 UserLearningItems = lp.UserLearningItems.Select(userLearningItem => new UserLearningItemDto()
                 {
                     Category = userLearningItem.LearningItem!.Category switch
                     {
                         Category.Database => CategoryDto.Database,
                         Category.Frontend => CategoryDto.Frontend,
                         Category.Backend => CategoryDto.Backend,
                         _ => throw new InvalidOperationException()
                     },
                     Description = userLearningItem.LearningItem.Description,
                     Id = userLearningItem.Id,
                     Name = userLearningItem.LearningItem.Name,
                     Completed = userLearningItem.Completed
                 }).ToList()
             }
         ).ToList();

        return learningPaths;
    }
}