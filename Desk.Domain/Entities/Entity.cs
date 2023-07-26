namespace Desk.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity? other)
        {
            if (other == null)
                return false;

            return Id == other.Id;
        }
    }
}