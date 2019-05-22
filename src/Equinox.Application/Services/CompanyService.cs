using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equinox.Application.Interfaces;
using Equinox.Domain.ApiResponse;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Repository;
using Equinox.Infra.Data.UoW;
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

        public async Task<string> GetDetail()
        {
            var test = _CompanyRepository.GetAll();
            int count = await test.CountAsync();
            await _UnitOfWork.CommitAsyn();
            return ApiResponse.Ok(test,count);
        }
    }
}
