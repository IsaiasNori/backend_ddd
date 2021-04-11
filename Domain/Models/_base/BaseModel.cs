using System;
using Domain.Interfaces.Entities;

namespace Domain.Models
{
    public abstract class BaseModel
    {
        public String Id { get; set; }
        public String CreatedBy { get; private set; }
        public String UpdatedBy { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }
        public BaseModel()
        {
        }

        public BaseModel(BaseModel model)
        {
            if (model == null)
                return;

            Id = model.Id;
            CreatedBy = model.CreatedBy;
            UpdatedBy = model.UpdatedBy;
            CreatedAt = model.CreatedAt;
            UpdatedAt = model.UpdatedAt;
            DeletedAt = model.DeletedAt;
        }

        public void InstantiateBase(IEntity entity)
        {
            if (entity == null)
                return;

            Id = entity.GetId();
            CreatedBy = entity.GetCreatedBy();
            UpdatedBy = entity.GetUpdatedBy();
            CreatedAt = entity.GetCreatedAt();
            UpdatedAt = entity.GetUpdatedAt();
            DeletedAt = entity.GetDeletedAt();
        }
    }
}