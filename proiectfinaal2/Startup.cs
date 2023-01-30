using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using proiectfinaal2.data;
using proiectfinaal2.Models.Constants;
using proiectfinaal2.Models.entities;
using proiectfinaal2.Models.entities2;
using proiectfinaal2.Repositories;
using proiectfinaal2.Repositories.AnimalRepository;
using proiectfinaal2.Repositories.MedicamentRepository;
using proiectfinaal2.Repositories.StapanRepository;
using proiectfinaal2.Seed;
using proiectfinaal2.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectfinaal2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "proiectfinaal2", Version = "v1" });
            });
            services.AddDbContext<Context>(options => options.UseSqlServer("Data Source=DESKTOP-LRCPFES;Initial Catalog=ProiectFinal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();


            
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoleType.Admin, policy => policy.RequireRole(UserRoleType.Admin));
                options.AddPolicy(UserRoleType.User, policy => policy.RequireRole(UserRoleType.User));
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for auth")),
                    ValidateIssuerSigningKey = true

                };
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = Helpers.SessionTokenValidator.ValidateSessionToken
                };
            });

            services.AddScoped<SeedDb>();
            services.AddScoped<IUserServices, UserService>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<IStapanRepository, StapanRepository>();
            services.AddTransient<IMedicamentRepository, MedicamentRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();


            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,SeedDb seed, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "proiectfinaal2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            try
            {
                seed.SeedRoles().Wait();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
