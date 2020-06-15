using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestCarWeb.Models
{
    public class Parceiro : IdentityUser
    {
        public Parceiro()
        {
            Participacao = new HashSet<Participacao>();
            Responsavel = new HashSet<Responsavel>();
            //IdentityUserRole = new HashSet<IdentityUserRole<string>>();
        }


        public string Nome { get; set; }
        public string Celular { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public ICollection<Participacao> Participacao { get; set; }
        public ICollection<Responsavel> Responsavel { get; set; }
        //public ICollection<IdentityUserRole<string>> IdentityUserRole { get; set; }
    }
}
