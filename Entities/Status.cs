using System;

namespace AgeOfTechAPI.Entities
{
    public class Status
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Estado {get;set;}

    }
}