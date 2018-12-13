using System.Collections.Generic;

namespace Domain.Entities
{
    public class Endereco : BaseEntity<Endereco>
    {
        public string Cep { get; set; }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }
        public IEnumerable<Participante> Participante { get; set; }
    }
}