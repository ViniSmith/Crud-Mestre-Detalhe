using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Estoque : BaseModel
    {
        public string Nome { get; set; } = "";

        public string? Fornecedor { get; set; }

        public string? Descricao { get; set; }
    }
}
