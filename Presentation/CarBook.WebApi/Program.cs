using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarDescriptionRepositories;
using CarBook.Persistence.Repositories.CarFeatureRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Persistence.Repositories.RentACarRepositories;
using CarBook.Persistence.Repositories.ReviewRepositories;
using CarBook.Persistence.Repositories.StatisticsRepositories;
using CarBook.Persistence.Repositories.TagCloudRepositories;
using CarBoook.Application.Features.CQRS.Commands.BannerCommands;
using CarBoook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBoook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBoook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBoook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBoook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBoook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBoook.Application.Features.RepositoryPattern;
using CarBoook.Application.Interfaces;
using CarBoook.Application.Interfaces.BlogInterfaces;
using CarBoook.Application.Interfaces.CarDescriptionInterfaces;
using CarBoook.Application.Interfaces.CarFeatureInterfaces;
using CarBoook.Application.Interfaces.CarInterfaces;
using CarBoook.Application.Interfaces.CarPricingInterfaces;
using CarBoook.Application.Interfaces.RentACarInterfaces;
using CarBoook.Application.Interfaces.ReviewInterfaces;
using CarBoook.Application.Interfaces.StatisticsInterfaces;
using CarBoook.Application.Interfaces.TagCloudInterfaces;
using CarBoook.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Json Web Token(JWT)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // normalize, it should be true.
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = "https://localhost",
        ValidIssuer = "https://localhost",
        ClockSkew = TimeSpan.Zero, // start time
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("carbookcarbook00")),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});


#region Registrations
// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// adding ICarRepository to constructor
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));

// About
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
// Banner
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
// Brand
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
// Car
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
// Category
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
// Contact
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
#endregion

// WITH MEDIATOR DESIGN
// Feature
builder.Services.AddApplicationService(builder.Configuration);

// Fluent Validation
builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
