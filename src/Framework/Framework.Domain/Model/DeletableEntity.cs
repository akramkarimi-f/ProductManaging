namespace Framework.Domain.Model
{
    public abstract class DeletableEntity<TKey> : Entity<TKey>
    {
        public bool IsDeleted { get; protected set; }
    }
}