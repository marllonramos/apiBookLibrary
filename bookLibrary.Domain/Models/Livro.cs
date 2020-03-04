using System;

namespace bookLibrary.Domain.Models
{
    public class Livro : Entity
    {
        public string Titulo { get; private set; }
        public DateTime? DataLancamento { get; private set; }
        public Autor Autores { get; private set; }

        public Livro(string titulo, DateTime? dataLancamento = null)
        {
            Titulo = titulo;
            DataLancamento = dataLancamento;
        }
    }
}