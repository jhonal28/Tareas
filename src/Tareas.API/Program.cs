using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tareas.Domain.Interfaces;
using Tareas.Domain.UseCase;
using Tareas.Infrastructure.Repositories;
using Tareas.Infrastructure.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(c => c.AddPolicy("MyPolicy", x =>
{
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Works");
builder.Services.AddDbContext<SqlDbContext>(options =>
        options.UseSqlServer(connectionString));

//Componentes propios
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryUseCase, CategoryUseCase>();
builder.Services.AddScoped<IWorkUseCase, WorkUseCase>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    SqlDbContext context = scope.ServiceProvider.GetRequiredService<SqlDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
