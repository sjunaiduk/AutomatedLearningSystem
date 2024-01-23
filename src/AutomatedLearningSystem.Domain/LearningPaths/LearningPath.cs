using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningItems;

namespace AutomatedLearningSystem.Domain.LearningPaths
{
    public class LearningPath
    {
        public Guid Id { get; init; }


        private List<LearningItem> _items { get; } 

        public List<LearningItem> Items => _items.ToList();

        private LearningPath()
        {
        }

        private LearningPath(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }


        public Result<LearningPath> CreateLearningPath(Guid? id = null)
        {
           
            return new LearningPath(id);
        }

        public Result AddLearningItem(LearningItem item)
        {
         
            if (_items.Any(i => i.Id == item.Id))
            {
                return Error.Conflict("DuplicateLearningItem",
                    "Duplicate learning item added to learning items");

            }

            _items.Add(item);
            return Result.Success;
        }

        public Result DeleteLearningItem(Guid id)
        {
            if (_items.All(i => i.Id != id))
            {
                return Error.NotFound("LearningItemDoesntExist",
                    "Learning item in learning path was not found, failed to delete");
            }
            _items.RemoveAll(m => m.Id == id);
            return Result.Success;
        }
    }
}
