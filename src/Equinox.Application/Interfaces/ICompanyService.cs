using Equinox.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface ICompanyService
    {
        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <returns></returns>
        Task<string> GetDetail();

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<string> CreateCompany(CompanyCreateModel model);

        Task<string> UpdateCompany(CompanyUpdateModel model);
    }
}
