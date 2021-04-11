using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Repository.Entities
{
    public class User : BaseEntity<UserModel>
    {
        [Column(TypeName = "nvarchar(100)")]
        public String Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Role { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public String Token { get; set; }

        public User() : base()
        {
        }

        public User(UserModel model) : base(model)
        {
            if (model == null)
                return;

            Name = model.Name;
            Password = model.Password;
            Role = model.Role;
            Token = model.Token;
        }

        public override UserModel ToModel()
        {
            UserModel model = new();

            model.InstantiateBase(this);

            model.Name = Name;
            model.Password = Password;
            model.Role = Role;
            model.Token = Token;

            return model;
        }

        public override void FromModel(UserModel model)
        {
            base.FromModel(model);

            Name = model.Name;
            Password = model.Password;
            Role = model.Role;
            Token = model.Token;
        }
    }
}