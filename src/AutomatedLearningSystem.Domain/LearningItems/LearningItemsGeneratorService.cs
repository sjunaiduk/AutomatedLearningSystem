using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;

namespace AutomatedLearningSystem.Domain.LearningItems;


public static class LearningItemsGeneratorService
{
    private const decimal HighInterestMultiplier = 2.0m;
    private const decimal LowInterestMultiplier = 0.5m;
    private const int _maxLearningItems = 10;

    public static List<LearningItem> Generate(List<AnswerForQuestion> answers,
        List<LearningItem> availableLearningItems, UserProficiencyProfile proficiencyProfile)
    {
        var categorizedItems = CategorizeLearningItems(availableLearningItems);

        foreach (var answer in answers)
        {
            var categoryItems = categorizedItems[answer.Question.Category];
            AdjustScoresBasedOnInterestAndProficiency(categoryItems, answer, proficiencyProfile);
        }

        return categorizedItems.SelectMany(kvp => kvp.Value)
            .OrderByDescending(item => item.Score)
            .ThenByDescending(item => item.Priority)
            .Take(_maxLearningItems)
            .ToList();
    }

    private static Dictionary<Category, List<LearningItem>> CategorizeLearningItems(List<LearningItem> items)
    {
        return items.GroupBy(item => item.Category)
                    .ToDictionary(group => group.Key, group => group.ToList());
    }

    private static void AdjustScoresBasedOnInterestAndProficiency(List<LearningItem> items, AnswerForQuestion answer, UserProficiencyProfile profile)
    {
        decimal interestMultiplier = CalculateInterestMultiplier(answer.Answer);

        foreach (var item in items)
        {
            item.Score = CalculateItemScore(item, profile, interestMultiplier, answer.Question.Category);
        }
    }

    private static decimal CalculateInterestMultiplier(int response)
    {
        // Adjust the multiplier based on the response (1-5)
        return response switch
        {
            1 => LowInterestMultiplier,
            5 => HighInterestMultiplier,
            _ => 1.0m // Neutral multiplier for mid-range responses
        };
    }

    private static decimal CalculateItemScore(LearningItem item, UserProficiencyProfile profile, decimal interestMultiplier, Category category)
    {
        // Complex scoring logic
        decimal proficiencyAdjustment = GetProficiencyAdjustment(item, profile, category);
        return item.Score * interestMultiplier * proficiencyAdjustment;
    }

    private static decimal GetProficiencyAdjustment(LearningItem item, UserProficiencyProfile profile, Category category)
    {
        // Adjust the score based on the user's proficiency in the category
        // Example: Reduce score for items at or below user's level in a category
        switch (category)
        {
            case Category.Backend:
                return item.DifficultyLevel < profile.BackEndLevel ? 0.75m : 1.25m;
            case Category.Frontend:
                return item.DifficultyLevel < profile.FrontEndLevel ? 0.75m : 1.25m;
            case Category.Database:
                return item.DifficultyLevel < profile.DatabaseLevel ? 0.75m : 1.25m;
            default:
                return 1.0m;
        }
    }
}

//public static class LearningItemsGeneratorService
//{
//    private const decimal positiveDifficultyLevelMultiplier = 1.5m;
//    private const decimal negativeDifficultyLevelMultiplier = 0.75m;

//    public static List<LearningItem> Generate(List<AnswerForQuestion> answers, 
//        List<LearningItem> availableLearningItems, DifficultyLevel userBackEndLevel,
//        DifficultyLevel userFrontEndLevel, DifficultyLevel userDatabaseLevel)
//    {

//        var backEndTopics = availableLearningItems.Where(x =>
//            x.Category == Category.Backend).ToList();
//        var frontEndTopics = availableLearningItems.Where(x =>
//            x.Category == Category.Frontend).ToList();
//        var databaseTopics = availableLearningItems.Where(x =>
//            x.Category == Category.Database).ToList();

//        foreach (var answer in answers)
//        {

//            int score = 0;

//            if (answer.Answer >= 3)
//            {
//                score = 3;
//            }

//            if (answer.Question.Category == Category.Backend)
//            {
//                foreach (var item in backEndTopics)
//                {
//                    item.Score += score;

//                    if (item.DifficultyLevel == userBackEndLevel)
//                    {
//                        item.Score *= positiveDifficultyLevelMultiplier;
//                    }
//                    else
//                    {
//                        item.Score *= negativeDifficultyLevelMultiplier;
//                    }

//                }
//            }

//            if (answer.Question.Category == Category.Frontend)
//            {
//                foreach (var item in frontEndTopics)
//                {
//                    item.Score += score;

//                    if (item.DifficultyLevel == userFrontEndLevel)
//                    {
//                        item.Score *= positiveDifficultyLevelMultiplier;
//                    }
//                    else
//                    {
//                        item.Score *= negativeDifficultyLevelMultiplier;
//                    }

//                }
//            }


//            if (answer.Question.Category == Category.Database)
//            {
//                foreach (var item in databaseTopics)
//                {
//                    item.Score += score;

//                    if (item.DifficultyLevel == userDatabaseLevel)
//                    {
//                        item.Score *= positiveDifficultyLevelMultiplier;
//                    }
//                    else
//                    {
//                        item.Score *= negativeDifficultyLevelMultiplier;
//                    }

//                }
//            }


//        }


//        return availableLearningItems.OrderByDescending(x => x.Score)
//            .ThenByDescending(x => x.Priority)
//            .ToList();


//    }
//}