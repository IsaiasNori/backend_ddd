using System;
using System.Text.Json.Serialization;
using Domain.Models;

namespace Api.DTO.Login
{
    public class LoginResponseDTO
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }
        [JsonPropertyName("role")]
        public String Role { get; set; }
        [JsonPropertyName("token")]
        public String Token { get; set; }
        public LoginResponseDTO(UserModel user)
        {
            if (user == null)
                return;

            Name = user.Name;
            Role = user.Role;
            Token = user.Token;

        }
    }
}