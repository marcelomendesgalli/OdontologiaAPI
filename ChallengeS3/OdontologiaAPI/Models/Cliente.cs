using System;
using System.ComponentModel.DataAnnotations;

namespace OdontologiaAPI.Models
{
    public class Cliente
    {
        [Required]
        public Guid Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string NumeroTelefone { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required, StringLength(200)]
        public string NomeCompleto { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required, StringLength(50)]
        public string Usuario { get; set; }

        [Required]
        public Guid EnderecoId { get; set; }
        
    }
}