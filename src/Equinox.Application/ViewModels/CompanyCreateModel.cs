﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Application.ViewModels
{
    public class CompanyCreateModel
    {
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the capital.
        /// </summary>
        /// <value>
        /// The capital.
        /// </value>
        public string Capital { get; set; }

        /// <summary>
        /// Gets or sets the total shares.
        /// </summary>
        /// <value>
        /// The total shares.
        /// </value>
        public long TotalShares { get; set; }

        /// <summary>
        /// Gets or sets the option poll.
        /// </summary>
        /// <value>
        /// The option poll.
        /// </value>
        public long OptionPoll { get; set; }
    }
}
