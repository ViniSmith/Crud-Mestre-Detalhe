using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.DOs
{
    public class ProdutoDO : BaseDO
    {

        [Range(0.10, 10000,
        ErrorMessage = "O preço do produto deve ser maior que R$ 10 (10 centavos) e menor que R$ 10000 (10 mil).")]
        public float Preco { get; set; }

        [StringLength(100, ErrorMessage = "Estoque ID não encontrado.")]
        public string? EstoqueID { get; set; }

        public DateTime Validade { get; set; }

        [StringLength(100, ErrorMessage = "Imagem não encontrada.")]
        public string? ImageId { get; set; }
    }
}
