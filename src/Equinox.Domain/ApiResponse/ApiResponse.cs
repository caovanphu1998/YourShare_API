using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Equinox.Domain.ApiResponse
{
    public static class ApiResponse
    {
        public static string Ok(Object Object, long? count)
        {
            var response = new Response();
            response.Data = Object;
            response.Count = count == null ? 0 : count;
            response.IsSuccess = true;
            return JsonConvert.SerializeObject(response, Formatting.Indented);
        }
        public static string Ok()
        {
            var response = new Response();
            response.IsSuccess = true;
            return JsonConvert.SerializeObject(response, Formatting.Indented);
        }

        public static string Error()
        {
            var response = new Response();
            response.Count = 0;
            response.IsSuccess = false;
            return JsonConvert.SerializeObject(response, Formatting.Indented);
        }
    }
}
