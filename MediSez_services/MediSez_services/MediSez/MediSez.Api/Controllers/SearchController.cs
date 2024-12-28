using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediSez.Data.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Options;
using MediSez.Models;

namespace MediSez.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
       ISearch _search;
       AppSettings _appSettings;
        public SearchController(ISearch search, IOptions<AppSettings> options)
        {
            _search = search;
            _appSettings = options.Value;
        }

        [HttpPost("ActiveCities")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(200)]
        public async Task<string> GetActiveCities()
        {
            try
            {
                return await _search.GetActiveCities().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("UserTypesByCity")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(200)]
        public async Task<string> GetUserTypesByCity(int cityId)
        {
            try
            {
                return await _search.GetUserTypesByCity(cityId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("SearchDataByCityAndUsertype")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(200)]
        public async Task<string> GetSearchDataByCityAndUserType(int cityId, int userType)
        {
            try
            {
                return await _search.GetSearchDataByCityAndUserType(cityId, userType).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("DoctorShortProfiles")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(200)]
        public async Task<string> GetDoctorShortProfiles(string cityName, string displayUrlName)
        {
            try
            {
                return await _search.GetDoctorShortProfiles(cityName, displayUrlName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("HospitalShortProfiles")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(200)]
        public async Task<string> GetHospitalShortProfiles(string cityName, string displayUrlName)
        {
            try
            {
                return await _search.GetHospitalShortProfiles(cityName, displayUrlName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //[HttpPost("SearchTypes")]
        //[EnableCors("AllowOrigin")]
        //[ProducesResponseType(200)]      
        //public async Task<string> SearchTypes()
        //{
        //    try
        //    {               
        //        return await _search.SearchTypes().ConfigureAwait(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost("DefaultSearchData")]
        //[EnableCors("AllowOrigin")]
        //[ProducesResponseType(200)]
        //public async Task<string> DefaultSearchData(int SearchType, int CityId)
        //{
        //    try
        //    {
        //        return await _search.DefaultSearchData(SearchType, CityId).ConfigureAwait(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

    }
}
