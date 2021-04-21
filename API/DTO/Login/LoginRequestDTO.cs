using System;
using System.Text.Json.Serialization;
using Domain.Models;

namespace Api.DTO.Login
{
    public class LoginRequestDTO
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }
        [JsonPropertyName("password")]
        public String Password { get; set; }
        public LoginRequestDTO()
        {
        }
        public UserModel ToUser()
        {
            return new()
            {
                Name = Name,
                Password = Password
            };
        }
    }
}