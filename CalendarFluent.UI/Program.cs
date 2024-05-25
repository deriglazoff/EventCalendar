using CalendarFluent.UI.Components;
using EventCalendar.Api.Domain;
using Microsoft.FluentUI.AspNetCore.Components;

public class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddRazorComponents()
			.AddInteractiveServerComponents();
		builder.Services.AddFluentUIComponents();
		builder.Services.AddHttpClient<IEventsRepository, EventCalendarApiRepository>(x => x.BaseAddress = new Uri("http://eventcalendar.api:8080"));
		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error", createScopeForErrors: true);
		}

		app.UseStaticFiles();
		app.UseAntiforgery();

		app.MapRazorComponents<App>()
			.AddInteractiveServerRenderMode();

		app.Run();
	}
}
