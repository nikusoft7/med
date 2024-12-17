using MediSez.Models;
using MediSez.Data.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MediSez.Data.Services
{
    public class SearchService : ISearch
    {
        public AppSettings _appSettings { get; }
        public SearchService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<string> GetActiveCities()
        {
            var sqlParams = new Dictionary<string, object>
            {

            };
            return await DBUtility.GetjsonData(_appSettings.ConnectionString, SqlConstants.ActiveCities, sqlParams).ConfigureAwait(false);
        }

        public async Task<string> GetUserTypesByCity(int cityid)
        {
            var sqlParams = new Dictionary<string, object>
            {                
                {"CityId" ,cityid},
            };
            return await DBUtility.GetjsonData(_appSettings.ConnectionString, SqlConstants.UserTypesByCity, sqlParams).ConfigureAwait(false);
        }

        public async Task<string> GetSearchDataByCityAndUserType(int cityId, int userType)
        {
            var sqlParams = new Dictionary<string, object>
            {
                {"userType" ,userType},
                {"cityId" ,cityId},
            };
            return await DBUtility.GetjsonData(_appSettings.ConnectionString, SqlConstants.SearchDataByCityAndUserType, sqlParams).ConfigureAwait(false);
        }

        public async Task<string> SearchTypes()
        {
            var sqlParams = new Dictionary<string, object>
            {
               
            };
            return await DBUtility.GetjsonData(_appSettings.ConnectionString, SqlConstants.SearchTypes, sqlParams).ConfigureAwait(false);
        }

        public async Task<string> DefaultSearchData(int SearchType,int CityId)
        {
            var sqlParams = new Dictionary<string, object>
            {
                {"SearchType" ,SearchType},
                {"CityId" ,CityId},
            };
            return await DBUtility.GetjsonData(_appSettings.ConnectionString, SqlConstants.DefaultSearchData, sqlParams).ConfigureAwait(false);
        }

    }
}
