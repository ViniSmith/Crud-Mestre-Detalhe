
namespace Server.Models
{
    public class Produto : BaseModel
    {

        public Produto() { }

        public Produto(Estoque estoque) 
        {
            this.estoque = estoque;
        }

        public float Preco { get; set; }

        public string? EstoqueID
        {
            get => estoque == null ? estoqueID : estoque.Id;
            set => estoqueID = value;
        }

        public DateTime Validade { get; set; }

        public string? ImageId { get; set; }

        private string? estoqueID = null;

        private Estoque? estoque;
    }
}
