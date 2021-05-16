namespace Framework.Domain.Model
{
    public class Entity<TKey>
    {
        public TKey Id { get; protected set; }
    }
}