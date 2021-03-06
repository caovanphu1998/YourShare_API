﻿using System;
using System.Collections.Generic;

namespace Equinox.Domain.Models
{
    public partial class Company
    {
        public Guid Id { get; set; }
        public Guid AdminId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Capital { get; set; }
        public long? TotalShares { get; set; }
        public long? OptionPoll { get; set; }
    }
}
