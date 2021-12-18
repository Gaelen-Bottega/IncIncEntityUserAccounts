using System;
using IncIncEntityUserAccounts.Areas.Identity.Data;
using IncIncEntityUserAccounts.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IncIncEntityUserAccounts.Areas.Identity.IdentityHostingStartup))]
namespace IncIncEntityUserAccounts.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IncIncEntityUserAccountsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IncIncEntityUserAccountsContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IncIncEntityUserAccountsContext>();
            });
        }
    }
}