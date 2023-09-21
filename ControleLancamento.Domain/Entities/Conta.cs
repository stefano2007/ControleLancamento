using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class Conta : EntidadeBase
{
    public string Nome { get; private set; }
    public int TipoContaId { get; private set; }
    public TipoConta TipoConta { get; set; }

    public Conta(string nome, int categoriaId)
    {
        ValidarDominio(nome, categoriaId);
    }
    public Conta(int id, string nome, int tipoContaId)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidarDominio(nome, tipoContaId);
    }
    public void Atualiza(string nome, int tipoContaId)
    {
        ValidarDominio(nome, tipoContaId);
    }
    public void Deleta()
    {
        TornaInativo();
    }
    private void ValidarDominio(string nome, int tipoContaId)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Campo nome é requerido");

        DomainExceptionValidation.When(nome.Length < 3,
           "nome inválido mínimo de 3 caracteres");

        DomainExceptionValidation.When(tipoContaId <= 0,
            "Campo CategoriaId é requerido");

        Nome = nome;
        TipoContaId = tipoContaId;
    }
}

