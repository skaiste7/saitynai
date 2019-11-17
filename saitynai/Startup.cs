﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using saitynai.Models;

namespace saitynai
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<UserContext>(options =>
            options.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = MyShop; Trusted_Connection = True; MultipleActiveResultSets = True;"));

            services.AddDbContext<ItemContext>(options =>
            options.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = MyShop; Trusted_Connection = True; MultipleActiveResultSets = True;"));

            services.AddDbContext<OrderContext>(options =>
            options.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = MyShop; Trusted_Connection = True; MultipleActiveResultSets = True;"));

            services.AddDbContext<WorkerContext>(options =>
            options.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = MyShop; Trusted_Connection = True; MultipleActiveResultSets = True;"));

            services.AddDbContext<AdminContext>(options =>
            options.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = MyShop; Trusted_Connection = True; MultipleActiveResultSets = True;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
