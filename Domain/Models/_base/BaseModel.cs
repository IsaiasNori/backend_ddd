using System;

namespace Domain.Core.Models
{
    public class BaseModel
    {
        public String Id { get; set; }
        public String CreatedBy { get; set; }
        public String UpdatedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public BaseModel()
        {
        }


    }

}