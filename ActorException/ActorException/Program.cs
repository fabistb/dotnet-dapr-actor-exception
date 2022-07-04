using ActorException.Actors;
using ActorException.Infrastructure;
using ActorException.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IExceptionService, ExceptionService>();
builder.Services.AddTransient<IActorFactory<IExceptionActor>, ActorFactory<IExceptionActor>>();

builder.Services.AddDaprSidekick(builder.Configuration);

builder.Services.AddActors(o =>
{
    o.Actors.RegisterActor<ExceptionActor>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(e =>
{
    e.MapControllers();
    e.MapActorsHandlers();
});

app.Run();