using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.DAOs
{
    public class EstoqueDAO : AutoDAO<Estoque>
    {
        protected override string Tabela => "estoque";
    }
}