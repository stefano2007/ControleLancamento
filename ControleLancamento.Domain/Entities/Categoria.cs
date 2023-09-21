using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class Categoria : EntidadeBase
{    
    public string Nome { get; private set; }
    public string Cor { get; private set; }
    public string Icone { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public Categoria(string nome, string cor, string icone, DateTime dataCriacao)
    {
        Nome = nome;
        Cor = cor;
        Icone = icone;
        DataCriacao = dataCriacao;
    }
    public Categoria(int id, string nome, string cor, string icone, DateTime dataCriacao)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Id = id;

        ValidarDominio(nome, cor, icone, dataCriacao);
    }
    public void Atualiza(string nome, string cor, string icone, DateTime dataCriacao)
    {
        ValidarDominio(nome, cor, icone, dataCriacao);
    }
    public void Deleta()
    {
        TornaInativo();
    }
    private void ValidarDominio(string nome, string cor, string icone, DateTime dataCriacao)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Invalid name.Name is required");

        DomainExceptionValidation.When(nome.Length < 3,
           "Invalid name, too short, minimum 3 characters");

        Nome = nome;
        Cor = cor;
        Icone = icone;
        DataCriacao = dataCriacao;
    }
}
