﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppCompletaCurso.Models
{
    public class Fornecedor : Entity
    {
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        // EF Relations - entity entender que o fornecedor tem relação de 1 pra muitos com produtos
        public IEnumerable<Produto> Protudos { get; set; }

    }

    
}
