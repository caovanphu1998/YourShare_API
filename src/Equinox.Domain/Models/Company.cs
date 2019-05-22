using Equinox.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Equinox.Domain.Models
{
    public partial class Company
    {
        // Empty constructor for EF
        public Guid Id { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }
    }
}
