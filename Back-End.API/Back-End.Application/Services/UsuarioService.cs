using Back_End.Application.Commands;
using Back_End.Application.Interface.Repositories;
using Back_End.Application.Interface.Services;
using Back_End.Application.Queries;
using Back_End.Domain.Models;

namespace Back_End.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task AdicionarUsuarioAsync(UsuarioCommand usuarioCommand)
        {
            if (string.IsNullOrWhiteSpace(usuarioCommand.Email))
                throw new ArgumentException("O email do usuário não pode ser vazio.");

            if (!Usuario.ValidarFormatoEmail(usuarioCommand.Email))
                throw new ArgumentException("O formato do e-mail é inválido.");

            if (string.IsNullOrWhiteSpace(usuarioCommand.Senha))
                throw new ArgumentException("A senha do usuário não pode ser vazia.");

            if (usuarioCommand.CodigoGenero <= 0)
                throw new ArgumentException("O Código do genero é inválido.");

            var novoUsuario = Usuario.MapearDadosUsuario(usuarioCommand.Email, usuarioCommand.Senha, usuarioCommand.CodigoGenero);

            await _usuarioRepository.AdicionarUsuarioAsync(novoUsuario);
        }

        public async Task AtualizarUsuarioAsync(UsuarioCommand usuarioCommand, int codigoUsuario)
        {
            if (string.IsNullOrWhiteSpace(usuarioCommand.Email))
                throw new ArgumentException("O email do usuário não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(usuarioCommand.Senha))
                throw new ArgumentException("A senha do usuário não pode ser vazia.");

            if (usuarioCommand.CodigoGenero <= 0)
                throw new ArgumentException("O Código do genero é inválido.");

            var dadosUsuario = Usuario.MapearDadosUsuario(usuarioCommand.Email, usuarioCommand.Senha, usuarioCommand.CodigoGenero, codigoUsuario);

            await _usuarioRepository.AtualizarUsuarioAsync(dadosUsuario);
        }

        public async Task<IEnumerable<UsuarioQuery>> RecuperarTodosUsuariosAsync()
        {
            return await _usuarioRepository.RecuperarTodosUsuariosAsync();
        }

        public async Task<UsuarioQuery> RecuperarUsuarioAsync(int codigoUsuario)
        {
            return await _usuarioRepository.RecuperarUsuarioAsync(codigoUsuario);
        }
    }
}
