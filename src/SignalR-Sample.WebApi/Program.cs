using SignalR_Sample.WebApi;
using SignalR_Sample.WebApi.Configurations;
using SignalR_Sample.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseSetup(builder.Configuration);
builder.Services.AddJWT(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddCors(options => {
    options.AddPolicy(
  name: "OpenCORSPolicy",
  builder => {
      builder.WithOrigins("http://localhost:3000")
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials();
  });
});
;
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("OpenCORSPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllers();
    endpoints.MapHub<MessageHub>("/messageHub");
});
app.Run();
