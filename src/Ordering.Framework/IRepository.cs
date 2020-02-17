﻿namespace Ordering.Framework
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWOrk { get; }
    }
}