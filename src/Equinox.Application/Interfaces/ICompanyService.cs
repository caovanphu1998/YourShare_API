using Equinox.Application.SearchModels;
using Equinox.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface ICompanyService
    {
        /// <summary>
        /// Searches the company.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<string> SearchCompany(CompanySearchModel model);

        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <returns></returns>
        Task<string> GetAllCompany();

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<string> CreateCompany(CompanyCreateModel model);

        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<string> UpdateCompany(CompanyUpdateModel model);

        /// <summary>
        /// Gets the company by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> GetCompanyById(Guid id);
    }
}
