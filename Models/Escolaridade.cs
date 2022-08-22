namespace Confitec.Models
{
 public class Escolaridade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}