using FastFood.Domain.Common.Exceptions;

namespace FastFood.Domain.Entities.PreparationManagement
{
    public class Preparation
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public EnumPreparationStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }

        public Preparation()
        {
            
        }
        public Preparation(Guid id, Guid orderId, EnumPreparationStatus status, DateTime createdAt, DateTime? startedAt = null, DateTime? finishedAt = null)
        {
            Id = id;
            OrderId = orderId;
            Status = status;
            CreatedAt = createdAt;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }

        public Preparation(Guid orderId)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            Status = EnumPreparationStatus.Waiting;
            CreatedAt = DateTime.UtcNow;
        }

        public void StartPreparation()
        {
            DomainValidation.ThrowIf(Status != EnumPreparationStatus.Waiting, "Preparação já iniciada ou finalizada.");
            Status = EnumPreparationStatus.InProgress;
            StartedAt = DateTime.UtcNow;
        }

        public void FinishPreparation()
        {
            DomainValidation.ThrowIf(Status != EnumPreparationStatus.InProgress, "Preparação ainda não iniciada ou já finalizada.");
            Status = EnumPreparationStatus.Finished;
            FinishedAt = DateTime.UtcNow;
        }
    }
}