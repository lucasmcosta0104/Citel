using Newtonsoft.Json;

namespace Citel.Application.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
