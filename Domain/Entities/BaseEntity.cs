using System;

namespace Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}
