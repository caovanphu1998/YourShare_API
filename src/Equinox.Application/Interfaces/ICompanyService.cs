using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<string> GetDetail();
    }
}
