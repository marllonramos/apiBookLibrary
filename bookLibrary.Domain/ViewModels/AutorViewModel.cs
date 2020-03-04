using System;

namespace bookLibrary.Domain.ViewModels
{
    public class AutorViewModel
    {
        public string Nome { get; set; }
        public Nullable<DateTime> DataNascimento { get; set; }
        public string? Descricao { get; set; }
        public LivroViewModel Livros { get; set; }
    }
}