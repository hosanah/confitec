 namespace Confitec.Models
 {
 public class HistoricoEscolar
    {
        public int Id { get; set; }
        public FormatoType Formato { get; set; }
        public string Nome { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
 }