using System;
using System.Text.Json.Serialization;
using Domain.Models;

namespace Api.DTO
{
    public class UserDTO : BaseDTO
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }
        [JsonPropertyName("password")]
        public String Password { get; set; }

        public UserDTO()
        {
        }
        public UserDTO(UserModel model) : base(model)
        {
            if (model == null)
                return;

            Name = model.Name;
            Password = model.Password;
        }

    }

    public static class UserDTOExtensions
    {

        public static UserModel ToModel(this UserDTO dto)
        {
            if (dto == null)
                return null;

            UserModel model = new()
            {
                Name = dto.Name,
                Password = dto.Password,
            };

            return model;
        }

    }

}