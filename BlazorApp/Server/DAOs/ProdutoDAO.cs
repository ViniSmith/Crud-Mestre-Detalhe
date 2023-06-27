using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.DAOs
{
    public class ProdutoDAO : AutoDAO<Produto>
    {
        protected override string Tabela => "produto";

        protected override string? NomeCampoIdMestre => "EstoqueID";
    }
}