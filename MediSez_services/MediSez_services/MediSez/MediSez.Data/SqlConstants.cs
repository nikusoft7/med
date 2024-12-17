using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediSez.Data
{
    public static class SqlConstants
    {
        public static string ActiveCities = "Usp_Api_GetActiveCities";
        public static string UserTypesByCity = "Usp_Api_GetUserTypesByCity";
        public static string SearchDataByCityAndUserType = "USP_Api_GetSearchDataByCityAndUserType";
        public static string SearchTypes = "ApiSearchTypes";
        public static string DefaultSearchData = "ApiDefaultSearchData";
    }
}
