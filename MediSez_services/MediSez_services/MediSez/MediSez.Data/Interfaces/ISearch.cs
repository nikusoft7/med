namespace MediSez.Data.Interfaces
{
    public interface ISearch
    {
        Task<string> GetActiveCities();
        Task<string> GetUserTypesByCity(int cityid);
        Task<string> GetSearchDataByCityAndUserType(int cityId, int userType);
        Task<string> GetHospitalShortProfiles(string cityName, string displayUrlName);
        Task<string> GetDoctorShortProfiles(string cityName, string displayUrlName);

        Task<string> SearchTypes();
        Task<string> DefaultSearchData(int SearchType, int CityId);
    }
}
