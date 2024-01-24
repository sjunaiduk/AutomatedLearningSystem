namespace AutomatedLearningSystem.Application.Common.Abstractions;

public interface IUnitOfWork
{
    Task CommitChangesAsync(CancellationToken token = default);
}