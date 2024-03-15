using App.v1.Context;
using App.v1.Middlewares;
using App.v1.Profiles;
using App.v1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StockContext>(opt => opt.UseSqlServer(Configuration.Configuration.ConnectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<CompanyService>();
builder.Services.AddTransient<MailService>();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(CompanyProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors((opt) => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseMiddleware<TokenValidationMiddleware>();

app.MapControllers();

app.Run();
