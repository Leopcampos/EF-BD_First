using System;
using System.Collections.Generic;

namespace FadamiBD_First.Models
{
    public partial class Usuario
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Cpf { get; set; }
        public string? Senha { get; set; }
        public DateTime UltimoAcesso { get; set; } = DateTime.Now;
        public int QtdErroLogin { get; set; }
        public bool BlAtivo { get; set; } = true;
    }
}