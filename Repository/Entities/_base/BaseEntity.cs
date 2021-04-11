using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces.Entities;
using Domain.Models;

namespace Repository.Entities
{
    public abstract class BaseEntity<M> : IEntity
        where M : BaseModel
    {
        [Key]
        public String Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String CreatedBy { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String UpdatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public BaseEntity()
        {
        }
        public BaseEntity(BaseModel model)
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
        public String GetId() => Id;
        public String GetCreatedBy() => CreatedBy;
        public String GetUpdatedBy() => UpdatedBy;
        public DateTimeOffset GetCreatedAt() => CreatedAt;
        public DateTimeOffset GetUpdatedAt() => UpdatedAt;
        public DateTimeOffset? GetDeletedAt() => DeletedAt;
        public abstract M ToModel();
        public virtual void FromModel(M model)
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

    }

}