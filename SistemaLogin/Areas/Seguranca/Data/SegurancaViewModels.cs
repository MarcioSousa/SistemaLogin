using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaLogin.Areas.Seguranca.Data
{
    public class SegurancaViewModels
    {
    }

    public class UsuarioViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }

    //LoginViewModel
    public class Login
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }
    }
    public class PapelEditModel
    {
        public Papel Role { get; set; }
        public IEnumerable<Usuario> Membros { get; set; }
        public IEnumerable<Usuario> NaoMenbros { get; set; }
    }

    public class PapelModificationModel
    {
        [Required]
        public string NomePapel { get; set; }
        public string[] IdsParaAdicionar { get; set; }
        public string[] IdsParaRemover { get; set; }
    }

}