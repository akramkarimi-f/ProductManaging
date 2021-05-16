using System;

namespace Framework.Domain.Model
{
    public interface ICreationAudit
    {
        public string CreatorUserId { get; }
        public DateTime CreationTime { get; }
    }
}
