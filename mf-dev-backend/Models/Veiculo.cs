﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {

        //Criando atributos para as tabelas
        [Key]
        public int Id { get; set; }

        [Required( ErrorMessage = "Obrigatório informar o nome!")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a placa!")]

        public string Placa { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Ano de Fabricação!")]
        [Display(Name = "Ano de Fabricação")]

        public int AnoFabricacao { get; set; } 

        [Required(ErrorMessage = "Obrigatório informar o Ano do Modelo!")]
        [Display(Name = "Ano do Modelo")]

        public int AnoModelo { get; set; }
    }
}
