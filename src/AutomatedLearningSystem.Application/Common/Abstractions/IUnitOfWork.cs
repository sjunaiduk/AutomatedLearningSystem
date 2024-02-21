namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IUnitOfWork
{
    Task<int> CommitChangesAsync(CancellationToken token = default);
}