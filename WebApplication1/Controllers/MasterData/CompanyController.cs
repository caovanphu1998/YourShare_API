using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinox.Application.Interfaces;
using Equinox.Application.Services;
using Equinox.Infra.Data.UoW;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.MasterData
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _customerAppService;
        public CompanyController(ICompanyService companyService)
        {
            _customerAppService = companyService;
        }
        // GET api/values
        [HttpGet]
        [Route("api/demo")]
        public async Task<string> Get()
        {
            string a = await _customerAppService.GetDetail();
            return a;
        }
    }
}