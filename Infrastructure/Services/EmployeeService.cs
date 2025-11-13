using AutoMapper;
using Dapr.Client;
using Domain.Models;
using Domain.Service;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DaprClient _daprClient;
        private const string MANAGEMENT_APP_ID = "employeeservice";
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(DaprClient daprClient, ILogger<EmployeeService> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        public async Task<IEnumerable<EmployeeExternalData>> GetEmployeesByDepartmentIdAsync(Guid departmentId, string? userToken)
        {
            var methodPath = $"api/Employee/ByDepartment?departmentId={departmentId}";
            var invokableClient = _daprClient.CreateInvokableHttpClient(MANAGEMENT_APP_ID);
            var request = new HttpRequestMessage(HttpMethod.Get, methodPath);
            _logger.LogInformation($"Delegating employee detail query to App ID '{MANAGEMENT_APP_ID}' at path '{methodPath}' for ID: {departmentId}");

            if (!string.IsNullOrEmpty(userToken))
            {
                request.Headers.Add("Authorization", userToken);
            }

            var response = await invokableClient.SendAsync(request, CancellationToken.None);
            if (response.IsSuccessStatusCode)
            {
                var employeeRecords = await response.Content.ReadFromJsonAsync<IEnumerable<EmployeeExternalData>>();
                return employeeRecords!;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                string statusCode = response.StatusCode.ToString();
                _logger.LogWarning(
                "Service call to {AppId} for Department {DepartmentId} failed due to security: StatusCode: {StatusCode}. Token provided: {HasToken}",
                    MANAGEMENT_APP_ID,
                    departmentId,
                    statusCode,
                    !string.IsNullOrEmpty(userToken)
                );
                throw new UnauthorizedAccessException($"Unauthorized access when fetching employees.");
            }
            else 
            {
                throw new HttpRequestException($"Failed to fetch employees. Status code: {response.StatusCode}");
            }
        }
    }
}
