﻿using AutomatedLearningSystem.Application.Common.Abstractions;

namespace AutomatedLearningSystem.Infrastructure.Common.Persistence;

public class UnitOfWork : IUnitOfWork
{

    private readonly AutomatedLearningSystemDbContext _dbContext;

    public UnitOfWork(AutomatedLearningSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CommitChangesAsync(CancellationToken token = default)
    {
        await _dbContext.SaveChangesAsync(token);
    }
}