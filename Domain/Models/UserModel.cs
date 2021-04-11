using System;
using Domain.Interfaces;
using Domain.Interfaces.Entities;

namespace Domain.Models
{
    public class UserModel : BaseModel
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        public String Token { get; set; }



        public UserModel() : base()
        {
        }

        public UserModel(UserModel model) : base(model)
        {
            if (model == null)
                return;

            Name = model.Name;
            Password = model.Password;
            Role = model.Role;
            Token = model.Token;
        }
    }
}