using EventCalendar.Api;
using EventCalendar.Api.Domain;
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

            var events = await httpResponse.Content.ReadFromJsonAsync<List<EventEntity>>();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task ControllerEvents_Edit_Ok()
        {
            await using var application = new WebApplicationFactory<Program>();

            using var client = application.CreateClient();


            var httpResponse = await client.GetAsync($"events");

            var events = await httpResponse.Content.ReadFromJsonAsync<List<EventEntity>>();

            httpResponse = await client.PutAsync("events", JsonContent.Create(new EventEntity { Id = events.First().Id, Name = "new", Date = DateTime.Now }));

            httpResponse = await client.GetAsync($"events");
            var events2 = await httpResponse.Content.ReadFromJsonAsync<List<EventEntity>>();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
        [Fact]
        public async Task ControllerEvents_Add_Ok()
        {
            await using var application = new WebApplicationFactory<Program>();

            using var client = application.CreateClient();

            var id = Guid.NewGuid();
            var httpResponse = await client.PostAsync("events", JsonContent.Create(new EventEntity { Id = id, Name = "new", Date = DateTime.Now }));

            httpResponse = await client.GetAsync($"events");
            var events = await httpResponse.Content.ReadFromJsonAsync<List<EventEntity>>();
            Assert.Equal("new", actual: events.First(x => x.Id == id).Name);
        }
    }
}