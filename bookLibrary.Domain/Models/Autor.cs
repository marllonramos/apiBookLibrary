using System;

namespace bookLibrary.Domain.Models
{
    public class Autor : Entity
    {
        public string Nome { get; private set; }
        public Nullable<DateTime> DataNascimento { get; private set; }
        public string? Descricao { get; private set; }
        public Livro Livros { get; private set; }

        public Autor(string nome, DateTime? dataNascimento = null, string descricao = null)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Descricao = descricao;
        }
    }
}