using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models; // ESSENCIAL para corrigir o erro do OpenApiInfo
using Student.API.Context;
using Student.API.Repository;
using Student.API.Repository.Interface;
using Student.API.Service;
using Student.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Student.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddControllers();

            // VOLTAMOS AO PADRÃO (Agora funciona pois os pacotes são v12.0.1)
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                // Certifique-se que o 'using Microsoft.OpenApi.Models;' está lá em cima
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student.API", Version = "v1" });
            });

            var sqlConnection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(sqlConnection));

            // Configuração JWT
            var jwtSettings = Configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Injeção de Dependências
            services.AddScoped<ISolicitacaoProjetoRepository, SolicitacaoProjetoRepository>();
            services.AddScoped<ISolicitacaoProjetoService, SolicitacaoProjetoService>();
            services.AddScoped<IPerfilUserRepository, PerfilUserRepository>();
            services.AddScoped<IPerfilUserService, PerfilUserService>();
            services.AddScoped<IPropostaSolicitacaoProjetoRepository, PropostaSolicitacaoProjetoRepository>();
            services.AddScoped<IPropostaSolicitacaoProjetoService, PropostaSolicitacaoProjetoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student.API v1"));

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}