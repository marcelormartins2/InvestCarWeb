using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestCarWeb.Models
{
    public class Parceiro : IdentityUser
    {

        public string Nome { get; set; }
        public string Celular { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

    }
}
