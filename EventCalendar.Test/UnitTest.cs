using EventCalendar.Api.Controller;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace EventCalendar.Test
{
    public class UnitTest
    {
        [Fact]
        public async Task Check_Get_Ok()
        {
            await using var application = new WebApplicationFactory<Program>();

            using var client = application.CreateClient();

            var httpResponse = await client.GetAsync($"check");

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task ControllerEvents_Get_Ok()
        {
            await using var application = new WebApplicationFactory<Program>();

            using var client = application.CreateClient();


            var httpResponse = await client.GetAsync($"events");

            var events = await httpResponse.Content.ReadFromJsonAsync<List<EventModel>>();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task ControllerEvents_Add_Ok()
        {
            await using var application = new WebApplicationFactory<Program>();

            using var client = application.CreateClient();


            var httpResponse = await client.GetAsync($"events");

            var events = await httpResponse.Content.ReadFromJsonAsync<List<EventModel>>();

            httpResponse = await client.PostAsync("events", new StringContent(""));

            httpResponse = await client.GetAsync($"events");
            var events2 = await httpResponse.Content.ReadFromJsonAsync<List<EventModel>>();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}