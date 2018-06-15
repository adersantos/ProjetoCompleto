﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AS.ProjetoCompleto.Application.ViewModels
{
    public class ClienteViewModel
    {

        public ClienteViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Nome obrigatório")]
        [MaxLength(150, ErrorMessage ="Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage ="Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Email obrigatório")]
        [MaxLength(150, ErrorMessage ="Máximo 100 caracteres")]
        [EmailAddress(ErrorMessage ="Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage ="CPF obrigatório")]
        [MaxLength(11, ErrorMessage ="Máximo 11 caracteres")]
        public string CPF { get; set; }

        [Display(Name ="Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage ="Data em formato inválido")]
        public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Excluido { get; set; }

        public IEnumerable<EnderecoViewModel> Enderecos { get; set; }
    }
}
