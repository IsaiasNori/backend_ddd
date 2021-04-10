using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Repository.Entities
{
    public class UserEntity : BaseEntity<UserModel>
    {
        [Column(TypeName = "nvarchar(100)")]
        public String Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Password { get; set; }

        public UserEntity() : base()
        {
        }

        public UserEntity(UserModel model) : base(model)
        {
            if (model == null)
                return;

            Name = model.Name;
            Password = model.Password;
        }

        public override UserModel ToModel()
        {
            UserModel model = new();

            model.InstantiateBase(this);

            model.Name = Name;
            model.Password = Password;

            return model;
        }

        public override void FromModel(UserModel model)
        {
            base.FromModel(model);

            Name = model.Name;
            Password = model.Password;
        }
    }
}