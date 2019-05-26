using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Equinox.Application.Interfaces;
using Equinox.Application.SearchModels;
using Equinox.Application.ViewModels;
using Equinox.Domain.ApiResponse;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Domain.Util;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _CompanyRepository;
        private readonly IRepository<Administrator> _AdministratorRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public CompanyService(IUnitOfWork UnitOfWork
                                , IRepository<Company> CompanyRepository
                                , IRepository<Administrator> AdministratorRepository)
        {
            _UnitOfWork = UnitOfWork;
            _CompanyRepository = CompanyRepository;
            _AdministratorRepository = AdministratorRepository;
        }

        public async Task<string> CreateCompany(CompanyCreateModel model)
        {
            var company = new Company();
            company.CompanyName = model.CompanyName;
            company.Address = model.Address;
            company.Capital = model.Capital;
            company.TotalShares = model.TotalShares;
            company.OptionPoll = model.OptionPoll;
            _CompanyRepository.Insert(company);
            await _UnitOfWork.CommitAsyn();
            return ApiResponse.Ok();
        }

        public async Task<string> GetAllCompany()
        {
            var test = _CompanyRepository.GetAll();
            int count = await test.CountAsync();
            return ApiResponse.Ok(test, count);
        }

        public async Task<string> UpdateCompany(CompanyUpdateModel model)
        {
            var company = _CompanyRepository.GetById(model.CompanyId);
            if (company == null)
            {
                return ApiResponse.Error("Company Not Exits");
            }
            company.CompanyName = model.CompanyName;
            company.Address = model.Address;
            company.Capital = model.Capital;
            company.TotalShares = model.TotalShares;
            company.OptionPoll = model.OptionPoll;
            _CompanyRepository.Insert(company);
            await _UnitOfWork.CommitAsyn();
            return ApiResponse.Ok();
        }

        public async Task<string> SearchCompany(CompanySearchModel model)
        {
            string defaultSort = "CompanyName ASC";
            string sortType = model.IsSortDesc ? "DESC" : "ASC";
            string sortField = ValidateUtils.IsNullOrEmpty(model.SortField) ? defaultSort : $"{model.SortField} {sortType}";
            var query = _AdministratorRepository.GetManyAsNoTracking(x =>
                            (ValidateUtils.IsNullOrEmpty(model.AdminUserName) || x.UserName == model.AdminUserName))
                        .Select(x => new
                        {
                            x.Id,
                            x.UserName,
                        })
                        .Join(_CompanyRepository.GetManyAsNoTracking(x =>
                                (ValidateUtils.IsNullOrEmpty(model.Address) || x.Address.ToUpper().Contains(model.AdminUserName.ToUpper()))
                                && (ValidateUtils.IsNullOrEmpty(model.Capital) || x.Capital.ToUpper().Contains(model.Capital.ToUpper()))
                                && (ValidateUtils.IsNullOrEmpty(model.CompanyName) || x.CompanyName.ToUpper().Contains(model.CompanyName.ToUpper()))
                        ), x => x.Id, y => y.AdminId, (x, y) => new CompanyViewSearchModel
                        {
                            AdminUserName = x.UserName,
                            Address = y.Address,
                            Capital = y.Capital,
                            CompanyId = y.Id,
                            CompanyName = y.CompanyName,
                            OptionPoll = y.OptionPoll,
                            TotalShares = y.TotalShares
                        }).OrderBy(sortField);
            var count = await query.CountAsync();
            var result = query.Skip((model.Page - 1) * model.PageSize)
                               .Take(model.PageSize)
                               .ToList();
            return ApiResponse.Ok(result, count);
        }

        public async Task<string> GetCompanyById(Guid id)
        {
            var company = _CompanyRepository.GetById(id);
            if (company == null)
            {
                return ApiResponse.Error("Company Not Exits");
            }
            return ApiResponse.Ok(company, 1);
        }
    }
}
