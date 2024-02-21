namespace AutomatedLearningSystem.Contracts.LearningPaths;

public class LearningPathsResponse
{
    public List<LearningPathResponse> LearningPaths { get; init; }
}

public class LearningPathResponse
{
    public Guid Id { get; set; }
    public List<LearningItemResponse> LearningItems { get; init; }
}

public class LearningItemResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public CategoryUi Category { get; set; }

    public bool Completed { get; set; }
}

public enum CategoryUi
{
    Frontend = 0,
    Backend = 1,
    Database = 2
}