﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Actio.Services.Identity.Domain.Services;
using Actio.Services.Identity.Services;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Common.Mongo;
using Actio.Services.Identity.Handler;
using Actio.Common.Commands;
using Actio.Common.Auth;

namespace Actio.Services.Identity
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
            services.AddLogging();
            services.AddMongoDB(Configuration);
            services.AddJwt(Configuration);
            services.AddSingleton<IEncrypter, Encrypter>();
            services.AddTransient<ICommandHandler<CreateUser>, CreateUserHandler>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
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
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<IDatabaseInitializer>().InitializeAsync();
            }
        }
    }
}
