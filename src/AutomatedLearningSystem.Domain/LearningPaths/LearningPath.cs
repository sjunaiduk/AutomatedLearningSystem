using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;

namespace AutomatedLearningSystem.Domain.LearningPaths
{
    public class LearningPath
    {
        public Guid Id { get; init; }


        //private List<LearningItem> _learningItems { get; } = new();

        //public List<LearningItem> LearningItems => _learningItems.ToList();

        public List<LearningItem> LearningItems { get; private set; } = new();


        public LearningPath()
        {
        }

        private LearningPath(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }


        public static LearningPath CreateLearningPath(Guid? id = null)
        {

            return new LearningPath(id);
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
