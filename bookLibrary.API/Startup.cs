using bookLibrary.Domain.Commands;
using bookLibrary.Domain.Handlers;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using bookLibrary.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddControllers();

            //3. Adicionando inje��o de depend�ncia
            services.AddScoped<IResultCommand, ResultCommand>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IPublishingCompanyRepository, PublishingCompanyRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<BookHandler, BookHandler>();
            services.AddScoped<ReaderHandler, ReaderHandler>();

            //2. Conex�o com 'InMemory'
            //services.AddDbContext<DbBookContext>(opt => opt.UseInMemoryDatabase("dbBook"));

            //4. Conexao com SqlServer
            services.AddDbContext<DbBookContext>(
                opt => opt.UseSqlServer(
                    Configuration.GetConnectionString("connectionString")
                ));
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

            app.UseAuthorization();
            //4. Habilitei o uso da autoriza��o
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
