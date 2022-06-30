using MassTransit;
namespace Core.Domain.Contracts
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        protected BaseEntity()
        {
            Id = NewId.Next().ToGuid();
        }
    }
}