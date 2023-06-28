using DataAccess.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.IngredientCategoryModule;
using Repository.IngredientCategoryModule.Interface;
using Repository.IngredientModule;
using Repository.IngredientModule.Interface;
using Repository.RecipeDetailModule;
using Repository.RecipeDetailModule.Interface;
using Repository.RecipeModule;
using Repository.RecipeModule.Interface;
using Repository.StepModule;
using Repository.StepModule.Interface;
using System.Collections.Generic;

namespace Recipez
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
            services.AddRazorPages();
            services.AddSession();
            services.AddMemoryCache();
            services
                .AddSignalR(e =>
                {
                    e.EnableDetailedErrors = true;
                    e.MaximumReceiveMessageSize = 102400000;
                });
            //Add scope and dependency injection
            //Recipe Module
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
            //Ingredient Module
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IIngredientService, IngredientService>();
            //Ingredient Category Module
            services.AddScoped<IIngredientCategoryRepository, IngredientCategoryRepository>();
            services.AddScoped<IIngredientCategoryService, IngredientCategoryService>();
            //Step Module
            services.AddScoped<IStepRepository, StepRepository>();
            services.AddScoped<IStepService, StepService>();
            //Recipe Detail Module
            services.AddScoped<IRecipeDetailRepository, RecipeDetailRepository>();
            services.AddScoped<IRecipeDetailService, RecipeDetailService>();
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.LoginPath = "/Authentication/Login";
                opt.AccessDeniedPath = "/Denied";
            });

            services.Configure<List<Account>>(Configuration.GetSection("admin"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
