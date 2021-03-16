using System;

namespace Domain.Core.Models
{
    public class UserModel : BaseModel
    {
        public String Name { get; set; }
        public String Password { get; set; }

        public UserModel() : base()
        {
        }

    }
}