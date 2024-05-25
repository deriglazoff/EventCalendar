using EventCalendar.Api.Domain;
using EventCalendar.Api.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace EventCalendar.Api;
public class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddControllers();
		builder.Services.AddSwaggerGen();
		builder.Services.AddHealthChecks();
		builder.Services.AddDbContext<EventsRepository>(options =>
		  options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresDbContext")), ServiceLifetime.Singleton);
		builder.Services.AddSingleton<IEventsRepository, EventsRepository>();
		builder.Services.AddTransient<PublishService>();
		builder.Services.AddHostedService<WorkingBackgroundService>();
		builder.Services.AddMassTransit(x =>
		{
			x.AddConsumer<NotificationCommandConsumer>();
			x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));
			//x.UsingRabbitMq((context, cfg) =>
			//{
			//    cfg.Host("rabbitmq", "/", h =>
			//    {
			//        h.Username("guest");
			//        h.Password("guest");
			//    });
			//    cfg.ConfigureEndpoints(context);
			//});
		});

		var app = builder.Build();
		var rep = app.Services.CreateScope().ServiceProvider.GetService<EventsRepository>();
		rep.Database.EnsureDeleted();
		rep.Database.EnsureCreated();

		rep.Events.AddRange(rep._items.ToArray());
		rep.SaveChanges();
		app.UseSwagger();
		app.UseSwaggerUI();
		app.MapControllers();
		app.MapHealthChecks("check");
		app.Start();
	}
}
