using Equinox.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Application.SearchModels
{
    public class CompanySearchModel : BaseSearchModel
    {
        /// <summary>
        /// Gets or sets the name of the admin user.
        /// </summary>
        /// <value>
        /// The name of the admin user.
        /// </value>
        public string AdminUserName { get; set; }

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
    }
}
