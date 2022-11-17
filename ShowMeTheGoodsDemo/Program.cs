using ShowMeTheGoodsDemo.Data.Repositories;
using ShowMeTheGoodsDemo.Data;
using ShowMeTheGoodsDemo.Data.Entities;
using ShowMeTheGoodsDemo.Data.Reposotories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ShowMeTheGoodsDemo.Auth.Model;
using ShowMeTheGoodsDemo.Auth;
using Videogadon.Data;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddIdentity<SiteRestUser, IdentityRole>()
    .AddEntityFrameworkStores<ShowMeTheGoodsDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddDbContext<ShowMeTheGoodsDbContext>();



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters.ValidAudience = builder.Configuration["JWT:ValidAudience"]; // for who token is
        options.TokenValidationParameters.ValidIssuer = builder.Configuration["JWT:ValidIssuer"]; // who gives token
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])); // hashing
    });



builder.Services.AddTransient<IEventsTypeRepository, EventsTypeRepository>();
builder.Services.AddTransient<IEventsRepository, EventsRepository>();
builder.Services.AddTransient<ICommentsRepository, CommentsRepository>();

builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<AuthDbSeeder>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyNames.ResourceOwner, policy => policy.Requirements.Add(new ResourceOwnerRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, ResourceOwnerAuthorizationHandler > ();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ShowMeTheGoodsDbContext>();
dbContext.Database.Migrate();

var dbSeeder = scope.ServiceProvider.GetRequiredService<AuthDbSeeder>();
await dbSeeder.SeedAsync();

app.Run();
