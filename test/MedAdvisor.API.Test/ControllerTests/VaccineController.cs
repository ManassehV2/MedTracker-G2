using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using MedAdvisor.Api;
// using Xunit;
using System.Net.Http.Json;
using FluentAssertions;
using System.Net.Http.Headers;
using MedAdvisor.Api.DataClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedAdvisor.API.Test
{
    [TestClass]
    public class VaccineIntegrationTest
    {
        public static HttpClient RunApplication()
        {
            var webAppFactory = new WebApplicationFactory<Program>();


            var TestClient = webAppFactory.CreateDefaultClient();

            return TestClient;
        }

        static async Task AuthentiacteUser(HttpClient TestClient)
        {
            var response = await TestClient.PostAsJsonAsync("http://localhost:5260/api/auth/login", new UserDto("test@integration.com", "SomePass1234!"));
            var registrationToken = await response.Content.ReadAsStringAsync();

            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", registrationToken);
        }


        [TestMethod]
        [TestProperty("ExecutionOrder", "1")]
        public async Task Get_Vaccine_With_User_Logged_In_Should_Returns_OK()
        {

            var TestClient = RunApplication();

            await AuthentiacteUser(TestClient);
            var response = await TestClient.GetAsync("http://localhost:5260/api/Vaccine");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
        [TestMethod]
        [TestProperty("ExecutionOrder", "2")]
        public async Task Get_Vaccine_With_Out_User_Logged_In_Should_Return_BadResult()
        {
            var TestClient = RunApplication();

            var response = await TestClient.GetAsync("http://localhost:5260/api/Vaccine");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder", "3")]
        public async Task Get_Vaccine_With_Wrong_JWT_Token_Should_Return_BadRequest()
        {

            var TestClient = RunApplication();

            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Some Invalid Token");

            var response = await TestClient.GetAsync("http://localhost:5260/api/Vaccine");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }


        [TestMethod]
        [TestProperty("ExecutionOrder", "4")]
        public async Task Add_Vaccine_WithOut_Login_Should_Return_BadRequest()
        {

            var TestClient = RunApplication();

            var response = await TestClient.PostAsJsonAsync("http://localhost:5260/api/Vaccine", new VaccineData() { vaccineId = 1 });

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder", "6")]
        public async Task Add_Vaccine_With_Invalid_Token_Should_Return_BadRequest()
        {

            var TestClient = RunApplication();

            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Some Invalid Token");

            var response = await TestClient.PostAsJsonAsync("http://localhost:5260/api/Vaccine", new VaccineData() { vaccineId = 1 });

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder", "7")]
        public async Task Add_Vaccine_With_Invalid_vaccineId_Should_Return_BadRequest()
        {

            var TestClient = RunApplication();

            await AuthentiacteUser(TestClient);
            var InvalidvaccineId = 99;
            var response = await TestClient.PostAsJsonAsync("http://localhost:5260/api/Vaccine", new VaccineData() { vaccineId = InvalidvaccineId });

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder", "5")]
        public async Task Add_Vaccine_With_Logged_In_User_Should_Return_Ok()
        {
            var TestClient = RunApplication();
            await AuthentiacteUser(TestClient);

            var response = await TestClient.PostAsJsonAsync("http://localhost:5260/api/Vaccine", new VaccineData() { vaccineId = 5 });
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder", "8")]
        public async Task Delete_Vaccine_With_Logged_In_User_Should_Return_NoContent()
        {
            var TestClient = RunApplication();

            await AuthentiacteUser(TestClient);

            var response = await TestClient.PostAsJsonAsync("http://localhost:5260/api/Vaccine/delete", new VaccineDeleteData() { vaccineId = new List<int>() { 5 } });


            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder", "8")]
        public async Task Delete_Vaccine_With_Out_Logged_In_User_Should_Return_BadRequest()
        {
            var TestClient = RunApplication();

            var response = await TestClient.PostAsJsonAsync("http://localhost:5260/api/Vaccine/delete", new VaccineDeleteData() { vaccineId = new List<int>() { 5 } });


            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestProperty("ExecutionOrder", "8")]
        public async Task Delete_Vaccine_With_Invalid_Token_Should_Return_BadRequest()
        {
            var TestClient = RunApplication();

            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "Some Invalid Token");

            var response = await TestClient.PostAsJsonAsync("http://localhost:5260/api/Vaccine/delete", new VaccineDeleteData() { vaccineId = new List<int>() { 5 } });


            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


    }
}