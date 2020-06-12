using System;
using System.Collections.Generic;
using System.Text;

namespace PampaDesvs.Shared.DomainObjects
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
