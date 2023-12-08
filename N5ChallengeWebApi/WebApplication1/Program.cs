using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using N5ChallengeWebApiApplication.Features.Commands;
using N5ChallengeWebApiApplication.Features.Queries;
using N5ChallengeWebApiApplication.Mappings;
using N5ChallengeWebApiDomain;
using N5ChallengeWebApiDomain.Seeders;
using N5ChallengeWebApiInfrastructure.Persistence.Context.Implementations;
using N5ChallengeWebApiInfrastructure.Persistence.Context.Interfaces;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Implementations;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add logger
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<N5ChallengeDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("N5ChallengeDB")));

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IElasticSearchRepository, ElasticSearchRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(RequestPermissionCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllPermissionsQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(ModifyPermissionCommand).Assembly);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<N5ChallengeDBContext>();
    if (dbContext != null)
    {
        dbContext.Database.Migrate();
        var seeder = new PermissionTypeSeeder();
        seeder.Seed(dbContext);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
