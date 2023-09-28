using ControleLancamento.Application.Interfaces;
using ControleLancamento.Application.Mappings;
using ControleLancamento.Application.Services;
using ControleLancamento.Domain.Interfaces;
using ControleLancamento.Infra.Data.Context;
using ControleLancamento.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ControleLancamento.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration){

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            options.LogTo((s) => Debug.Write(s), LogLevel.Information);
        });

        //Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryTypeRepository, CategoryTypeRepository>();
        services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ILaunchRepository, LaunchRepository>();

        //Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryTypeService, CategoryTypeService>();
        services.AddScoped<IAccountTypeService, AccountTypeService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ILaunchService, LaunchService>();


        services.AddAutoMapper(typeof(MappingProfile));

        var myhandlers = AppDomain.CurrentDomain.Load("ControleLancamento.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

        return services;
    }
}
