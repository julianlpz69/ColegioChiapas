using API.Helpers;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using Persistencia.Data.Configurations;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.AddJWT(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddAppServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization(opts =>
{
    opts.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().AddRequirements(new GlobalVerbRolRequirement()).Build();
});
builder.Services.AddDbContext<ColegioDBContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("ConexMysql");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.MapControllers();
app.UseAuthentication(); //AUTENTICACION PRIMERO 
app.UseAuthorization();

app.Run();