using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class UserEntity : BaseEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public String Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Password { get; set; }

        public UserEntity()
        {
        }

    }
}