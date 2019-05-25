using System.Threading.Tasks;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.ApiResponse;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _CompanyRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public CompanyService(IUnitOfWork UnitOfWork, IRepository<Company> CompanyRepository)
        {
            _UnitOfWork = UnitOfWork;
            _CompanyRepository = CompanyRepository;
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

        public async Task<string> GetDetail()
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
                return ApiResponse.Error();
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
    }
}
