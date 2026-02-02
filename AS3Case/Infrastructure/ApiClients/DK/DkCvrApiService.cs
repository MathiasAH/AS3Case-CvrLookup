using AS3Case.Application.CompanyLookup.Contracts.Dto.ExternalData;
using AS3Case.Application.CompanyLookup.Contracts.Interfaces;
using AS3Case.Infrastructure.ApiClients.DK.Dto;
using Newtonsoft.Json;

namespace AS3Case.Infrastructure.ApiClients.DK
{
    public class DkCvrApiService : ICompanyLookupProvider
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseAddress;
        public DkCvrApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "AS3 - AS3 Software Developer Case - Mathias Ancher Harringer +45 20473276");
            _baseAddress = new Uri($"https://cvrapi.dk/api?");
        }
        public async Task<ApiResult> Search(string search)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=dk&search={search}");
            if (responseString is null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ApiResult>(responseString);
        }
        public async Task<ApiResult> GetByProductionUnit(int productionUnitNumber)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=dk&produ={productionUnitNumber}");
            if (responseString is null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ApiResult>(responseString);
        }
        public async Task<ExternalCompanyData> LookupByRegistrationNumberAsync(string registrationNumber)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=dk&vat={registrationNumber}");
            ApiResult result = JsonConvert.DeserializeObject<ApiResult>(responseString);
            if (result is null)
            {
                throw new Exception("Company not found");
            }
            return DkCvrApiMapper.ToExternalCompanyData(result);
        }
        public async Task<ExternalCompanyData> LookupByNameAsync(string name)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=dk&name={name}");

            ApiResult result = JsonConvert.DeserializeObject<ApiResult>(responseString);
            if (result is null)
            {
                throw new Exception("Company not found");
            }
            return DkCvrApiMapper.ToExternalCompanyData(result);
        }
        public async Task<ExternalCompanyData> LookupByPhoneNumberAsync(string phoneNumber)
        {
            string responseString = await _httpClient.GetStringAsync(_baseAddress + $"country=dk&phone={phoneNumber}");
            ApiResult result = JsonConvert.DeserializeObject<ApiResult>(responseString);
            if (result is null)
            {
                throw new Exception("Company not found");
            }
            return DkCvrApiMapper.ToExternalCompanyData(result);
        }
    }
}