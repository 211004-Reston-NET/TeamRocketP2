
using BL;
using DL;
using DL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2WebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "P2WebApi", Version = "v1" });
            });

            services.AddDbContext<P3ApiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ReferenceToDB")));
            services.AddScoped<IUserRepo, UserCloudRepo>();
            services.AddScoped<IUserBL, UsersBL>();
            services.AddScoped<IPostRepo, PostCloudRepo>();
            services.AddScoped<IPostBL, PostBL>();
            services.AddScoped<IReplyRepo, ReplyCloudRepo>();
            services.AddScoped<IReplyBL, ReplyBL>();
            services.AddScoped<IEventRepo, EventCloudRepo>();
            services.AddScoped<IEventBL, EventBL>();
            services.AddScoped<IForumRepo, ForumCloudRepo>();
            services.AddScoped<IForumBL, ForumBL>();
            services.AddScoped<IInviteRepo, InviteCloudRepo>();
            services.AddScoped<IInviteBL, InviteBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "P2WebApi v1"));
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
