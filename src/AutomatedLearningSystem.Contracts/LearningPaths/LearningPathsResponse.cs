using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Contracts.LearningPaths;

public class LearningPathResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public List<LearningItemResponse> UserLearningItems { get; init; } = null!;
}

public class LearningItemResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public CategoryUi Category { get; set; }

    public bool Completed { get; set; }
}


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CategoryUi
{
    Frontend = 0,
    Backend = 1,
    Database = 2
}