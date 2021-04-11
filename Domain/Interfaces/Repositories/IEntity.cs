using System;
using Domain.Models;

namespace Domain.Interfaces.Entities
{
    public interface IEntity
    {
        String GetId();
        String GetCreatedBy();
        String GetUpdatedBy();
        DateTimeOffset GetCreatedAt();
        DateTimeOffset GetUpdatedAt();
        DateTimeOffset? GetDeletedAt();

    }
}