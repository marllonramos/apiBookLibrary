using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using bookLibrary.Domain.Shared;
using bookLibrary.Infra.Contexts;
using bookLibrary.Infra.Repositories;
using bookLibrary.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace bookLibrary.API
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
            //1. Cors adicionado
            services.AddCors();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllers();

            //2. Conexão com 'InMemory'                     
            //services.AddDbContext<DbBookContext>(opt => opt.UseInMemoryDatabase("dbBook"));

            //5. Adicionando injeção de dependência
            services.AddScoped<IResultCommand, ResultCommand>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IPublishingCompanyRepository, PublishingCompanyRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IExemplaryRepository, ExemplaryRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<BookHandler, BookHandler>();
            services.AddScoped<ReaderHandler, ReaderHandler>();
            services.AddScoped<CategoryHandler, CategoryHandler>();
            services.AddScoped<AuthorHandler, AuthorHandler>();
            services.AddScoped<PublishingCompanyHandler, PublishingCompanyHandler>();
            services.AddScoped<ExemplaryHandler, ExemplaryHandler>();
            services.AddScoped<RoleHandler, RoleHandler>();
            services.AddScoped<DbSqlAdoContext, DbSqlAdoContext>();
            services.AddScoped<TokenService, TokenService>();

            //6. Conexao com SqlServer(usando para Entity Framework)
            services.AddDbContext<DbBookContext>(
                opt => opt.UseSqlServer(
                    Configuration.GetConnectionString("connectionString")
                ));

            //6. Conexao com SqlServer(usando para ADO.Net)
            Settings.ConnectionString = Configuration.GetConnectionString("connectionString");

            // Configure Authentication JWT
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("SecretKey").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //3. Habilitei o uso do Cors
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            //4. Habilitei o uso da autorização
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
