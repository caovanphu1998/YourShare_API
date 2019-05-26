using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConfigName
{
    public class Company : Attribute
    {
        public const string SearchCompany = "companys/company";

        public const string GetAllCompany = "company/getall";

        public const string GetByID = "company/getbyid";

        public const string Create = "company/create";

        public const string Update = "company/update";
    }
}
