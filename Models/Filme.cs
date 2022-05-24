using System;
using System.Collections.Generic;

namespace API_Filme.Models
{
    public partial class Filme
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int CategoriaId { get; set; }
        public int StreamingId { get; set; }
        public int NacionalidadeId { get; set; }
        public string? Url { get; set; }
    }
}
