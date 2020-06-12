using PampaDesvs.Registration.Domain.ValueObjects;
using System;

namespace PampaDesvs.Registration.Domain.Models
{
    public class User
    {

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Job { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public Contact Contact { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
    }
}
