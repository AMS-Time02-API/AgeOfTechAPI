using System;

namespace AgeOfTechAPI.Model
{
    public class StatusModel
    {
         public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Estado {get;set;}
    }
}