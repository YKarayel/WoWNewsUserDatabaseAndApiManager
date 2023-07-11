using FirebaseAdmin.Auth;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoWNewsApi.Firestore.Core;
using WoWNewsApi.Firestore.Repo;
using WoWNewsApi.FirestoreDbManager;
using WoWNewsApi.Repositories;
using WoWNewsApi.Repositories.Contracts;
using WoWNewsApi.Repositories.Repos;
using WoWNewsApi.Services;
using WoWNewsApi.Services.Contracts;
using WoWNewsApi.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddScoped<IUserRepository, UserRepositoriy>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IConnectFirestore, ConnectFirestore>();
builder.Services.AddScoped<IAddFirestoreDataToSql, AddFirestoreDataToSql>();


builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var firestoreManager = scope.ServiceProvider.GetRequiredService<IAddFirestoreDataToSql>();
    await firestoreManager.TakeUserData();
}


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






