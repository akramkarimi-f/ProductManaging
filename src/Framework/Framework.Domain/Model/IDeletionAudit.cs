using System;

namespace Framework.Domain.Model
{
    public interface IDeletionAudit
    {
        public string DeleterUserId { get; }
        public DateTime? DeletionTime { get; }
    }
}
