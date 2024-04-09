using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;
using AutomatedLearningSystem.Domain.UserLearningItems;

namespace AutomatedLearningSystem.Domain.LearningPaths
{
    public class LearningPath
    {
        public Guid Id { get; init; }

        public string Name { get; private set; }
        public List<UserLearningItem> UserLearningItems { get; private set; } = new();

        public Guid UserId { get; private set; }
        public LearningPath()
        {
        }

        private LearningPath(string name, Guid? id = null)
        {
            Name = name;
            Id = id ?? Guid.NewGuid();
        }


        public static LearningPath CreateLearningPath(string name, Guid? id = null)
        {

            return new LearningPath(name, id);
        }

        public Result AddLearningItem(UserLearningItem item)
        {

            if (UserLearningItems.Any(i => i.LearningItem?.Id == item.LearningItem?.Id))
            {
                return LearningPathErrors.Conflict;

            }

            UserLearningItems.Add(item);


            return Result.Success;
        }

        public Result DeleteLearningItem(Guid id)
        {
            if (UserLearningItems.All(i => i.Id != id))
            {
                return Error.NotFound(
                    "Learning item in learning path was not found, failed to delete");
            }
            UserLearningItems.RemoveAll(m => m.Id == id);
            return Result.Success;
        }
    }
}
