using DropDownFilter.DataAccess.DatabaseContext;
using DropDownFilter.DataAccess.StoredProcedureDbAccess.Abstraction;
using DropDownFilter.DataAccess.StoredProcedureDbAccess.Repository;
using DropDownFilter.Services.Abstraction;
using DropDownFilter.Services.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace DropDownFilter.API
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
            services.AddControllersWithViews();

            // connection service
            services.AddDbContext<DropDownFilterDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), builder => builder.EnableRetryOnFailure());
            });

            services.AddSingleton<Func<DropDownFilterDBContext>>(() =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<DropDownFilterDBContext>();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                var dbContext = new DropDownFilterDBContext(optionsBuilder.Options);
                dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(300));
                return dbContext;
            });

            // store Procedure services
            string connectionstring = Configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IHomeDbRepository>(x => new HomeDbRepository(connectionstring));

            // home service
            services.AddScoped<IHomeHelper, HomeHelper>();

            // swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DropDownFilter.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,

                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                           new string[] {}
                    }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DropDownFilter.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
