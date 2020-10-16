using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Data;
using Service.Interfaces;
using Service.Services;
using WebAPI;
using WebAPI.Controllers;
using Xunit;

namespace WebAPITest
{
    [Collection("Integration Tests")]
    public class MachinesControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public MachinesControllerTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
         public async Task Get_AllMachines_ReturnsSuccessStatusCode()
         {
            var response = await _httpClient.GetAsync("/api/machines");

            response.EnsureSuccessStatusCode();
         }

        [Fact]
        public async Task Get_AllMachines_ReturnsContent()
        {
            var response = await _httpClient.GetAsync("/api/machines");

            Assert.NotNull(response.Content);
            Assert.True(response.Content.Headers.ContentLength > 0); 
        }

        [Fact]
        public async Task Get_Machine_ReturnsSuccessStatusCode()
        {
            var response = await _httpClient.GetAsync("/api/machines/machine/1");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_Machine_ReturnsContent()
        {
            var response = await _httpClient.GetAsync("/api/machines/machine/1");

            Assert.NotNull(response.Content);
            Assert.True(response.Content.Headers.ContentLength > 0);
        }

        [Fact]
        public async Task Get_TotalProduction_ReturnsSuccessStatusCode()
        {
            var response = await _httpClient.GetAsync("/api/machines/machine/totalproduction/1");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_TotalProduction_ReturnsContent()
        {
            var response = await _httpClient.GetAsync("/api/machines/machine/totalproduction/1");

            Assert.NotNull(response.Content);
            Assert.True(response.Content.Headers.ContentLength > 0);
        }


        [Fact]
        public async Task Get_Delete_ReturnsSuccessStatusCode()
        {
            var response = await _httpClient.DeleteAsync("/api/machines/machine/1");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Delete_MachineTotalProduction_ReturnsContent()
        {
            var response = await _httpClient.DeleteAsync("/api/machines/machine/1");

            Assert.NotNull(response.Content);
            Assert.True(response.Content.Headers.ContentLength > 0);
        }
    }
}