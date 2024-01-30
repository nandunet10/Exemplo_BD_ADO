﻿using System.ComponentModel.DataAnnotations;

namespace APIBancoDeDados.Models
{
    public class LoginRespostaModel
    {
        public string Usuario { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
