﻿using System.Text.Json.Serialization;

namespace AutomatedLearningSystem.Contracts.LearningPaths;

public class LearningPathResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public List<UserLearningItemDto> UserLearningItems { get; init; } = null!;
}

public class UserLearningItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public CategoryDto Category { get; set; }

    public bool Completed { get; set; }
}


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CategoryDto
{
    Frontend = 0,
    Backend = 1,
    Database = 2
}