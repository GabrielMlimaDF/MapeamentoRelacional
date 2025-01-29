namespace Models.Models
{
    public class Operador
    {
        public int Id { get; set; } // Chave primária
        public string Nome { get; set; } // Nome do operador
        public int StatusOperadorId { get; set; } // Chave estrangeira
        public StatusOperador StatusOperador { get; set; } // Relacionamento
    }
}