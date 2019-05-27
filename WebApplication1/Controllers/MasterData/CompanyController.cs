using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiConfigName;
using Equinox.Application.Interfaces;
using Equinox.Application.SearchModels;
using Equinox.Application.Services;
using Equinox.Application.ViewModels;
using Equinox.Infra.Data.UoW;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.MasterData
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        #region 
        private readonly ICompanyService _customerAppService;
        #endregion

        #region Contructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyController"/> class.
        /// </summary>
        /// <param name="companyService">The company service.</param>
        public CompanyController(ICompanyService companyService)
        {
            _customerAppService = companyService;
        }
        #endregion

        #region Search Company        
        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Company.SearchCompany)]
        public async Task<string> SearchCompany([FromQuery] CompanySearchModel model)
        {
            return await _customerAppService.SearchCompany(model);
        }
        #endregion

        #region GetAllCompany        
        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Company.GetAllCompany)]
        public async Task<string> GetAllCompany()
        {
            return await _customerAppService.GetAllCompany();
        }
        #endregion
        
        #region GetCompanyById        
        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Company.GetByID)]
        public async Task<string> GetCompanyById(Guid Id)
        {
            return await _customerAppService.GetCompanyById(Id);
        }
        #endregion

        #region Create Company
        /// <summary>
        /// Creates the company.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route(Company.Create)]
        public async Task<string> CreateCompany([FromBody]CompanyCreateModel model)
        {
            return await _customerAppService.CreateCompany(model);
        }
        #endregion

        #region Updates the company 
        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        [Route(Company.Update)]
        public async Task<string> UpdateCompany([FromBody]CompanyUpdateModel model)
        {
            return await _customerAppService.UpdateCompany(model);
        }
        #endregion

        #region DeleteCompanyById        
        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route(Company.Delete)]
        public async Task<string> DeleteCompanyById(Guid Id)
        {
            return await _customerAppService.DeleteById(Id);
        }
        #endregion
    }
}