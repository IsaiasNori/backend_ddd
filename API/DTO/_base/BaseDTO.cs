using System;
using System.Text.Json.Serialization;
using Domain.Core.Models;

namespace Api.DTO
{
    public class BaseDTO
    {
        [JsonPropertyName("id")]
        public String Id { get; set; }

        public BaseDTO()
        {

        }
        public BaseDTO(BaseModel model)
        {
            Id = model.Id;
        }

    }

}