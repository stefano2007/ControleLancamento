using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class TipoConta : EntidadeBase
{
    public string Nome { get; private set; }
    
    public TipoConta(string nome)
    {
        ValidarDominio(nome);
    }

    public TipoConta(int id, string nome)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidarDominio(nome);
    }
    public void Atualiza(string nome)
    {
        ValidarDominio(nome);
    }
    public void Deleta()
    {
        TornaInativo();
    }
    private void ValidarDominio(string nome)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Campo nome é requerido");

        DomainExceptionValidation.When(nome.Length < 3,
           "nome inválido mínimo de 3 caracteres");

        Nome = nome;
    }
}

