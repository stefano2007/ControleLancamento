using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class ContaUsuario : EntidadeBase
{
    public int ContaId { get; private set; }
    public Conta Conta { get; set; }
    public int UsuarioId { get; private set; }
    public Usuario Usuario { get; set; }

    public ContaUsuario(int contaId, int usuarioId)
    {
        ValidarDominio(contaId, usuarioId);
    }
    public ContaUsuario(int id, int contaId, int usuarioId)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidarDominio(contaId, usuarioId);
    }
    public void Atualiza(int contaId, int usuarioId)
    {
        ValidarDominio(contaId, usuarioId);
    }
    public void Deleta()
    {
        TornaInativo();
    }
    private void ValidarDominio(int contaId, int usuarioId)
    {
        DomainExceptionValidation.When(contaId <= 0,
             "Campo CategoriaId é requerido");

        DomainExceptionValidation.When(usuarioId <= 0,
            "Campo CategoriaId é requerido");

        ContaId = contaId;
        UsuarioId = usuarioId;
    }
}

