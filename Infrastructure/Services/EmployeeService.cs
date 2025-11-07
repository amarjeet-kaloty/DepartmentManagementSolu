using AutoMapper;
using Domain.Models;
using Domain.Service;
using System.Net.Http.Json;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public EmployeeService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeExternalData>> GetEmployeesByDepartmentIdAsync(Guid departmentId)
        {
            var uri = $"api/Employee/ByDepartment?departmentId={departmentId}";
            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var apiRecords = await response.Content.ReadFromJsonAsync<IEnumerable<EmployeeExternalData>>();
                return _mapper.Map<IEnumerable<EmployeeExternalData>>(apiRecords);
            }
            else 
            {
                return Enumerable.Empty<EmployeeExternalData>();
            }
        }
    }
}
