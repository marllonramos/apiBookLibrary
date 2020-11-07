using System;
using System.Data;
using System.Threading.Tasks;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.Data.SqlClient;
using bookLibrary.Domain.Enums;

namespace bookLibrary.Infra.Repositories
{
    public class ExemplaryRepository : IExemplaryRepository
    {
        private readonly DbSqlAdoContext _context;

        public ExemplaryRepository(DbSqlAdoContext context)
        {
            _context = context;
        }

        public async Task<Exemplary> GetExemplary(Guid id)
        {
            try
            {
                string query = @"SELECT id, idLeitor, idLivro, status, inicioDataLeitura, fimDataLeitura, ultimaDataParalisacao, paralisacao
                                    FROM exemplares WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                Exemplary exemplary = null;

                using (SqlDataReader dr = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    DateTime dateParsed;

                    while (dr.Read())
                    {
                        exemplary = new Exemplary(Guid.Parse(dr["idLivro"].ToString()), Guid.Parse(dr["idLeitor"].ToString()));
                        exemplary.FillExemplaryId(id);
                        exemplary.PutStatus((EStatusExemplary)Enum.Parse(typeof(EStatusExemplary), dr["status"].ToString()));
                        exemplary.PutStartDateReading(DateTime.TryParse(dr["inicioDataLeitura"].ToString(), out dateParsed) ? (DateTime?)dateParsed : null);
                        exemplary.PutEndDateReading(DateTime.TryParse(dr["fimDataLeitura"].ToString(), out dateParsed) ? (DateTime?)dateParsed : null);
                        exemplary.PutLastDateParalisation(DateTime.TryParse(dr["ultimaDataParalisacao"].ToString(), out dateParsed) ? (DateTime?)dateParsed : null);
                        exemplary.PutParalisation(int.Parse(dr["paralisacao"].ToString()));
                    }
                }

                return exemplary;                
            }
            catch
            {
                throw;
            }
        }

        public async Task<Exemplary> GetExemplaryByBookAndReader(Guid bookId, Guid readerId)
        {
            try
            {
                string query = @"SELECT id, idLeitor, idLivro, status, inicioDataLeitura, fimDataLeitura, ultimaDataParalisacao, paralisacao
                                    FROM exemplares WHERE idLeitor = @idLeitor
                                    AND idLivro = @idLivro";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@idLeitor", readerId),
                    new SqlParameter("@idLivro", bookId)
                };

                Exemplary exemplary = null;

                using (SqlDataReader dr = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    DateTime dateParsed;

                    while (dr.Read())
                    {
                        exemplary = new Exemplary(Guid.Parse(dr["idLivro"].ToString()), Guid.Parse(dr["idLeitor"].ToString()));
                        exemplary.FillExemplaryId(Guid.Parse(dr["id"].ToString()));
                        exemplary.PutStatus((EStatusExemplary)Enum.Parse(typeof(EStatusExemplary), dr["status"].ToString()));
                        exemplary.PutStartDateReading(DateTime.TryParse(dr["inicioDataLeitura"].ToString(), out dateParsed) ? (DateTime?)dateParsed : null);
                        exemplary.PutEndDateReading(DateTime.TryParse(dr["fimDataLeitura"].ToString(), out dateParsed) ? (DateTime?)dateParsed : null);
                        exemplary.PutLastDateParalisation(DateTime.TryParse(dr["ultimaDataParalisacao"].ToString(), out dateParsed) ? (DateTime?)dateParsed : null);
                        exemplary.PutParalisation(int.Parse(dr["paralisacao"].ToString()));
                    }
                }

                return exemplary;                
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateExemplary(Exemplary exemplary)
        {
            try
            {
                string query = @"INSERT INTO exemplares(id, idLeitor, idLivro, status, inicioDataLeitura, fimDataLeitura, ultimaDataParalisacao, paralisacao) 
                                    VALUES(@id, @idLeitor, @idLivro, @status, @dataInicioLeitura, @dataFimLeitura, @dataUltimaParalisacao, @paralisacao)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", exemplary.Id),
                    new SqlParameter("@idLeitor",exemplary.IdReader),
                    new SqlParameter("@idLivro", exemplary.IdBook),
                    new SqlParameter("@status", exemplary.Status),
                    new SqlParameter("@dataInicioLeitura", exemplary.StartDateReading),
                    new SqlParameter("@dataFimLeitura", exemplary.EndDateReading),
                    new SqlParameter("@dataUltimaParalisacao", exemplary.LastDateParalisation),
                    new SqlParameter("@paralisacao", exemplary.Paralisation)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);                
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateExemplary(Exemplary exemplary)
        {
            try
            {
                string query = @"UPDATE exemplares SET 
                                    status = @status, 
                                    inicioDataLeitura = @dataInicioLeitura, 
                                    fimDataLeitura = @dataFimLeitura, 
                                    ultimaDataParalisacao = @dataUltimaParalisacao, 
                                    paralisacao = @paralisacao
                                WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", exemplary.Id),
                    new SqlParameter("@status", exemplary.Status),
                    new SqlParameter("@dataInicioLeitura", exemplary.StartDateReading),
                    new SqlParameter("@dataFimLeitura", exemplary.EndDateReading),
                    new SqlParameter("@dataUltimaParalisacao", exemplary.LastDateParalisation),
                    new SqlParameter("@paralisacao", exemplary.Paralisation)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);                
            }
            catch
            {
                throw;
            }
        }
    }
}