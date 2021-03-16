using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Models;

namespace Repository.Entities
{
    public class BaseEntity
    {
        [Key]
        public String Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String CreatedBy { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String UpdatedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
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


        public static implicit operator BaseModel(BaseEntity entity)
        {
            if (entity == null)
                return null;

            BaseModel model = new()
            {
                Id = entity.Id,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt,
            };

            return model;
        }

        public static implicit operator BaseEntity(BaseModel model)
        {
            if (model == null)
                return null;

            BaseEntity entity = new(model);

            return entity;
        }



        public void SetSoftDelete() =>
            DeletedAt = DateTimeOffset.UtcNow;
    }

}