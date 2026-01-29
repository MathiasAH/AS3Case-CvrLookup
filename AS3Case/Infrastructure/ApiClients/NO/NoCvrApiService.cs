using AS3Case.Application.Contracts.Dto;
using AS3Case.Application.Contracts.Interfaces;
using AS3Case.Infrastructure.ApiClients.NO.Dto;
using Newtonsoft.Json;

namespace AS3Case.Infrastructure.ApiClients.NO
{
    public class NoCvrApiService : ICompanyLookupProvider
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseAddress;
        public NoCvrApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "AS3 - AS3 Software Developer Case - Mathias Ancher Harringer +45 20473276");
            _baseAddress = new Uri($"https://cvrapi.dk/api?");
        }
        public async Task<ApiResult> Search(string search)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=no&search={search}");
            if (responseString is null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ApiResult>(responseString);
        }
        public async Task<ApiResult> GetByProductionUnit(int productionUnitNumber)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=no&produ={productionUnitNumber}");
            if (responseString is null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ApiResult>(responseString);
        }
        public async Task<ExternalCompanyData> LookupByRegistrationNumberAsync(string registrationNumber)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=no&vat={registrationNumber}");
            if (responseString is null)
            {
                return null;
            }
            ApiResult result = JsonConvert.DeserializeObject<ApiResult>(responseString);
            if (result is null)
            {
                return null;
            }
            return new ExternalCompanyData
            {
                Name = result.Name,
                Address = result.Address,
                City = result.City,
                ZipCode = result.Zipcode,
                PhoneNumber = result.Phone
            };
        }
        public async Task<ExternalCompanyData> LookupByNameAsync(string name)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=no&name={name}");

            if (responseString is null)
            {
                return null;
            }
            ApiResult result = JsonConvert.DeserializeObject<ApiResult>(responseString);
            if (result is null)
            {
                return null;
            }
            return new ExternalCompanyData
            {
                Name = result.Name,
                Address = result.Address,
                City = result.City,
                ZipCode = result.Zipcode,
                PhoneNumber = result.Phone
            };
        }
        public async Task<ExternalCompanyData> LookupByPhoneNumberAsync(string phoneNumber)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=no&phone={phoneNumber}");
            if (responseString is null)
            {
                return null;
            }
            ApiResult result = JsonConvert.DeserializeObject<ApiResult>(responseString);
            if (result is null)
            {
                return null;
            }
            return new ExternalCompanyData
            {
                Name = result.Name,
                Address = result.Address,
                City = result.City,
                ZipCode = result.Zipcode,
                PhoneNumber = result.Phone
            };
        }
    }
}