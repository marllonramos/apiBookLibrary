using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Queries;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;

namespace bookLibrary.Infra.Repositories
{
    public class PublishingCompanyRepository : IPublishingCompanyRepository
    {
        private readonly DbSqlAdoContext _context;

        public PublishingCompanyRepository(DbSqlAdoContext context)
        {
            _context = context;
        }

        public async Task Create(PublishingCompany publishingCompany)
        {
            try
            {
                var query = @"INSERT INTO editoras(id, nome) VALUES(@id, @nome)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", publishingCompany.Id),
                    new SqlParameter("@nome", publishingCompany.Name)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(PublishingCompany publishingCompany)
        {
            try
            {
                var query = @"UPDATE editoras SET nome = @nome WHERE id = @id";

                var parameters = new SqlParameter[]{
                    new SqlParameter("@id", publishingCompany.Id),
                    new SqlParameter("@nome", publishingCompany.Name)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var query = @"DELETE FROM editoras WHERE id = @id";

                var parameters = new SqlParameter[]{
                    new SqlParameter("@id", id)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);                
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PublishingCompany>> GetAll(int qtdItems, int page)
        {
            try
            {
                List<PublishingCompany> publishiesCompanies = null;

                var query = @"SELECT TOP (@qtdItems) id, nome " +
                                "FROM (SELECT ROW_NUMBER() OVER(ORDER BY nome) AS linha, id, nome FROM editoras WITH(NOLOCK)) as paginado " +
                                "WHERE linha > @qtdItems * (@page - 1)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@qtdItems", qtdItems),
                    new SqlParameter("@page", page)
                };

                using (var result = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    publishiesCompanies = new List<PublishingCompany>();

                    while (result.Read())
                    {
                        var publisher = new PublishingCompany(result[1].ToString());
                        publisher.FillIdPublishingCompany(result[0].ToString());

                        publishiesCompanies.Add(publisher);
                    }
                }  

                return publishiesCompanies;              
            }
            catch
            {
                throw;
            }
        }

        public async Task<PublishingCompany> GetById(Guid id)
        {
            try
            {
                PublishingCompany publisher = null;

                var query = @"SELECT id, nome FROM editoras WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                using (var result = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    while (result.Read())
                    {
                        publisher = new PublishingCompany(result[1].ToString());
                        publisher.FillIdPublishingCompany(result[0].ToString());
                    }
                }

                return publisher;
            }
            catch
            {
                throw;
            }
        }
    }
}
