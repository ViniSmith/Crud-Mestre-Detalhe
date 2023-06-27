using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.DAOs;
using Server.Models;
using BlazorApp.Shared.DOs;

namespace Server.Controllers.Extensoes
{
    public static class ExtensoesModelDO
    {
        public static ProdutoDO ToDO(this Produto obj)
        {
            return new ProdutoDO
            {
                Id = obj.Id,
                EstoqueID = obj.EstoqueID,
                Preco= obj.Preco,
                Validade = obj.Validade,
                ImageId = obj.ImageId,
            };
        }

        public static IList<ProdutoDO> ToDO(this IList<Produto> listaModels)
        {
            var lista = new List<ProdutoDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }
        
        public static async Task<Produto> ToModel(this ProdutoDO objDO)
        {
                Produto? obj = null;

                if (objDO.Id != null)
                {
                    var dao = new ProdutoDAO();
                    obj = await dao.RetornarPorIdAsync(objDO.Id);
                }

                if (obj == null)
                    obj = new Produto();

                obj.EstoqueID = objDO.EstoqueID;
                obj.Preco = objDO.Preco;
                obj.Validade = objDO.Validade;
                obj.ImageId = objDO.ImageId;

                return obj;
        }

        public static async Task<IList<Produto>> ToModel(this IList<ProdutoDO> listaDO)
        {
            var lista = new List<Produto>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }

        public static EstoqueDO ToDO(this Estoque obj)
        {
            return new EstoqueDO
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Fornecedor = obj.Fornecedor,
                Descricao = obj.Descricao
            };
        }

        public static IList<EstoqueDO> ToDO(this IList<Estoque> listaModels)
        {
            var lista = new List<EstoqueDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }

        public static async Task<Estoque> ToModel(this EstoqueDO objDO)
        {
            Estoque? obj = null;

            if (objDO.Id != null)
            {
                var dao = new EstoqueDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new Estoque();

            obj.Nome = objDO.Nome;
            obj.Fornecedor = objDO.Fornecedor;
            obj.Descricao = objDO.Descricao ?? "";

            return obj;
        }

        public static async Task<IList<Estoque>> ToModel(this IList<EstoqueDO> listaDO)
        {
            var lista = new List<Estoque>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }
    }
}
