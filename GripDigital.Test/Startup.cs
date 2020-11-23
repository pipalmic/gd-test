using System.Text;
using GripDigital.Test.Authentication;
using GripDigital.Test.Authentication.Interfaces;
using GripDigital.Test.Core.Repositories;
using GripDigital.Test.Core.Repositories.Interfaces;
using GripDigital.Test.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimpleInjector;

namespace GripDigital.Test
{
    public class Startup
    {
        private readonly Container _container = new Container();
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddDefaultPolicy(b => b.WithOrigins("http://localhost:58150").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "GripDigital.Test", Version = "v1"});
            });
            services.AddSignalR();
            services.AddLogging();
            services.AddSimpleInjector(_container, options =>
            {
                options.AddAspNetCore().AddControllerActivation();
                options.AddLogging();
            });

            var authenticationConfig = Configuration.GetSection(nameof(AuthenticationConfig)).Get<AuthenticationConfig>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = authenticationConfig.Audience,
                        ValidIssuer = authenticationConfig.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfig.Key)),
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true
                    };
                });
            
            InitializeContainer();
        }

        private void InitializeContainer()
        {
            _container.Register<IPasswordProvider, PasswordProvider>();
            _container.Register<ITokenProvider, JwtTokenProvider>();
            
            _container.Register<IMatchRepository, MatchRepository>();
            _container.Register<IUserRepository, UserRepository>();
            _container.Register<ILeaderboardRepository, LeaderboardRepository>();

            var authConfig = Configuration.GetSection(nameof(AuthenticationConfig)).Get<AuthenticationConfig>();
            _container.RegisterInstance(authConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GripDigital.Test v1"));
            }
            
            app.UseCors();
            
            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MatchRoomHub>("match/room");
            });
        }
    }
}