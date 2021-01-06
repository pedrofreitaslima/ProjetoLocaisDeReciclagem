using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLocaisDeReciclagem.Models
{
    public class LocaisReciclagem
    {
        [Key]
        public int LocalReciclagemId { get; set; }

        [Required(ErrorMessage="Esse campo é obrigatório")]
        [MaxLength(100, ErrorMessage="Este campo pode conter no máximo 100 caracteres")]
        public string Identificacao { get; set; }

        [MaxLength(10, ErrorMessage="Este campo pode conter no máximo 10 caracteres")]
        public string CEP { get; set; }

        [MaxLength(100, ErrorMessage="Este campo pode conter no máximo 100 caracteres")]
        public string Logradouro { get; set; }

        [MaxLength(10, ErrorMessage="Este campo pode conter no máximo 10 caracteres")]
        public string NumeroEndereco { get; set; }

        [MaxLength(30, ErrorMessage="Este campo pode conter no máximo 30 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage="Esse campo é obrigatório")]
        [MaxLength(50, ErrorMessage="Este campo pode conter no máximo 50 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage="Esse campo é obrigatório")] 
        [MaxLength(50, ErrorMessage="Este campo pode conter no máximo 50 caracteres")] 
        public string Cidade { get; set; }

        [Required(ErrorMessage="Esse campo é obrigatório")]
        [MaxLength(2, ErrorMessage="Este campo pode conter no máximo 2 caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage="Esse campo é obrigatório")]
        [Range(1, float.MaxValue, ErrorMessage="Capacidade inválida")]
        public float Capacidade { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}