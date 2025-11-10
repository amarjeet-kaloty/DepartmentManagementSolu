using AutoMapper;
using Dapr.Client;
using Domain.Models;
using Domain.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http.Json;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DaprClient _daprClient;
        private readonly IMapper _mapper;
        private const string MANAGEMENT_APP_ID = "employeeservice";
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(DaprClient daprClient, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _daprClient = daprClient;
            _mapper = mapper;
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
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                 response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                string statusCode = response.StatusCode.ToString();
                _logger.LogWarning(
                "Service call to {AppId} for Department {DepartmentId} failed due to security: StatusCode: {StatusCode}. Token provided: {HasToken}",
                    MANAGEMENT_APP_ID,
                    departmentId,
                    statusCode,
                    !string.IsNullOrEmpty(userToken)
                );
                return Enumerable.Empty<EmployeeExternalData>();
            }
            else 
            {
                return Enumerable.Empty<EmployeeExternalData>();
            }
        }
    }
}
