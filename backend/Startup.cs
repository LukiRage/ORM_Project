using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.ServiceModel;
using SoapCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ORM_Projekt.jwt_seed.Services.Users;

namespace ORM_Projekt
{
    public class Startup
    {
        private IConfiguration Configuration
        {
            get;
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddScoped<IUserService, UserServiceImpl>();

            services.AddDbContext<DataContext>(options =>
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), serverVersion);
            });

            // Dodanie obsługi usług SOAP za pomocą biblioteki SoapCore
            services.AddSoapCore();
            services.AddScoped<IDataService, DataService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.UseSoapEndpoint<IDataService>("/DataService", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });
        }
    }
}
