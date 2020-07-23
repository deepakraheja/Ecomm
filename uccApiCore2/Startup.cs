using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using uccApiCore2.BAL;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Repository;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appSettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyOrigin()
                .WithOrigins("http://ecom.uccnoida.com", "http://adminecom.uccnoida.com", "http://localhost:4100", "http://localhost:4200", "http://localhost:4000", "http://localhost:4300", "http://localhost:5000", "http://localhost:5100", "http://localhost:5200", "http://localhost:4500");
            }));
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin",
            //        options => options.AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowAnyMethod());
            //});
            services.AddSignalR();
            services.AddMvc();

            services.AddTransient<ICategoryBAL, CategoryBAL>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ISubCategoryBAL, SubCategoryBAL>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

            services.AddTransient<IBrandBAL, BrandBAL>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddTransient<IProductBAL, ProductBAL>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddTransient<ISupplierBAL, SupplierBAL>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddTransient<IUsersBAL, UsersBAL>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddTransient<ILookupBAL, LookupBAL>();
            services.AddScoped<ILookupRepository, LookupRepository>();

            services.AddTransient<IFabricBAL, FabricBAL>();
            services.AddScoped<IFabricRepository, FabricRepository>();

            services.AddTransient<ILookupTagBAL, LookupTagBAL>();
            services.AddScoped<ILookupTagRepository, LookupTagRepository>();

            services.AddTransient<ICartBAL, CartBAL>();
            services.AddScoped<ICartRepository, CartRepository>();

            services.AddTransient<IBillingAddressBAL, BillingAddressBAL>();
            services.AddScoped<IBillingAddressRepository, BillingAddressRepository>();

            services.AddTransient<IOrderBAL, OrderBAL>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); // For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProductImage")),
                RequestPath = "/ProductImage"

            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProductImage")),
                RequestPath = "/ProductImage"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                 Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Json")),
                RequestPath = "/Json"
            });

            //app.UseCors(options => options
            //.AllowAnyOrigin()
            //.AllowAnyHeader()
            //.AllowAnyMethod());
            app.UseCors("CorsPolicy");
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotifyHub>("/notify");
            });
            app.UseMvc();
        }
    }
}
