using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;

namespace AutomatedLearningSystem.Domain.LearningPaths
{
    public class LearningPath
    {
        public Guid Id { get; init; }

        public string Name { get; private set; }
        public List<LearningItem> LearningItems { get; private set; } = new();


        public LearningPath()
        {
        }

        private LearningPath(string name, Guid? id = null)
        {
            Name = name;
            Id = id ?? Guid.NewGuid();
        }


        public static LearningPath CreateLearningPath(string name,Guid? id = null)
        {

            return new LearningPath(name,id);
        }

        public Result AddLearningItem(LearningItem item)
        {

            if (LearningItems.Any(i => i.Id == item.Id))
            {
                return LearningPathErrors.Conflict;

            }

            LearningItems.Add(item);
            return Result.Success;
        }

        public Result DeleteLearningItem(Guid id)
        {
            if (LearningItems.All(i => i.Id != id))
            {
                return Error.NotFound(
                    "Learning item in learning path was not found, failed to delete");
            }
            LearningItems.RemoveAll(m => m.Id == id);
            return Result.Success;
        }
    }
}
