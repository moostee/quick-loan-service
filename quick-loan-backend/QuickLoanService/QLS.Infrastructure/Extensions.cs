using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QLS.Application.Contracts;
using QLS.Domain;
using QLS.Domain.Entity;
using QLS.Infrastructure.Data;
using QLS.Infrastructure.Data.Repository;
using QLS.Infrastructure.Data.UnitOfWork;

namespace QLS.Infrastructure;


public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:DefaultConnection"];
        services.AddDbContext<QLSContext>(options =>
            options.UseSqlServer(connectionString, b =>
            {
                b.MigrationsAssembly(typeof(QLSContext).Assembly.FullName);
                b.EnableRetryOnFailure();
            })
        );

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IWalletRepository, WalletRepository>();
        services.AddTransient<ILoanRepaymentRepository, LoanRepaymentRepository>();
        services.AddTransient<ILoanRepository, LoanRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}