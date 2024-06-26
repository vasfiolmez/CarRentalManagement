 using CarRentalManagement.Application.Features.CQRS.Handlers.AboutHandlers;
using CarRentalManagement.Application.Features.CQRS.Handlers.BannerHandlers;
using CarRentalManagement.Application.Features.CQRS.Handlers.BlogCategoryHandlers;
using CarRentalManagement.Application.Features.CQRS.Handlers.BrandHandlers;
using CarRentalManagement.Application.Features.CQRS.Handlers.CarHandlers;
using CarRentalManagement.Application.Features.CQRS.Handlers.ContactHandlers;
using CarRentalManagement.Application.Features.RepositoryPattern;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Application.Interfaces.BlogInterfaces;
using CarRentalManagement.Application.Interfaces.CarDescriptionInterfaces;
using CarRentalManagement.Application.Interfaces.CarFeatureInterfaces;
using CarRentalManagement.Application.Interfaces.CarInterfaces;
using CarRentalManagement.Application.Interfaces.CarPricingInterfaces;
using CarRentalManagement.Application.Interfaces.RentACarInterfaces;
using CarRentalManagement.Application.Interfaces.ReservationInterfaces;
using CarRentalManagement.Application.Interfaces.ReviewInterfaces;
using CarRentalManagement.Application.Interfaces.StatisticsInterfaces;
using CarRentalManagement.Application.Interfaces.TagCloudInterfaces;
using CarRentalManagement.Application.Services;
using CarRentalManagement.Application.Tools;
using CarRentalManagement.Persistence.Context;
using CarRentalManagement.Persistence.Repositories;
using CarRentalManagement.Persistence.Repositories.BlogRepositories;
using CarRentalManagement.Persistence.Repositories.CarDescriptionRepositories;
using CarRentalManagement.Persistence.Repositories.CarFeatureRepositories;
using CarRentalManagement.Persistence.Repositories.CarPricingRepositories;
using CarRentalManagement.Persistence.Repositories.CarRepositories;
using CarRentalManagement.Persistence.Repositories.CommentRepositories;
using CarRentalManagement.Persistence.Repositories.RentACarRepository;
using CarRentalManagement.Persistence.Repositories.ReservationRepositories;
using CarRentalManagement.Persistence.Repositories.ReviewRepositories;
using CarRentalManagement.Persistence.Repositories.StatisticsRepositories;
using CarRentalManagement.Persistence.Repositories.TagCloudRepositories;
using CarRentalManagement.WebApi.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();


builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyHeader()
		.AllowAnyMethod()
		.SetIsOriginAllowed((host) => true)
		.AllowCredentials();
	});
});
builder.Services.AddSignalR();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.RequireHttpsMetadata = false;
	opt.TokenValidationParameters = new TokenValidationParameters
	{
		ValidAudience = JwtTokenDefaults.ValidAudience,
		ValidIssuer = JwtTokenDefaults.ValidIssuer,
		ClockSkew = TimeSpan.Zero,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true
	};
});

// Add services to the container.
builder.Services.AddScoped<CarRentalContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository),typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository),typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository),typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IRentACarRepository),typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository),typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository),typeof(ReviewRepository));
builder.Services.AddScoped(typeof(IStatisticsRepository),typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IReservationRepository),typeof(ReservationRepositories));


builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandsQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);


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
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");

app.Run();
