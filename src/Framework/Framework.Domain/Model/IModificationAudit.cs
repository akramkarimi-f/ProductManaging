using System;

namespace Framework.Domain.Model
{
    public interface IModificationAudit
    {
        public string ModifierUserId { get; }
        public DateTime ModificationTime { get; }
    }
}
