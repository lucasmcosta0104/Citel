using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Citel.Application.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; } 
    }
}
