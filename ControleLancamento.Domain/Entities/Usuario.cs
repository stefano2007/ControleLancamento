using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class Usuario : EntidadeBase
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string Profissao { get; private set; }
    public string Celular { get; private set; }

    public Usuario(string nome, string email, string senha, string profissao, string celular)
    {
        ValidarDominio(nome, email, senha, profissao, celular);
    }

    public Usuario(int id, string nome, string email, string senha, string profissao, string celular)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidarDominio(nome, email, senha, profissao, celular);
    }
    public void Deleta()
    {
        TornaInativo();
    }
    public void ValidarDominio(string nome, string email, string senha, string profissao, string celular)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Campo nome é requerido");

        DomainExceptionValidation.When(nome.Length < 3,
           "nome inválido mínimo de 3 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "Campo email é requerido");

        DomainExceptionValidation.When(email.Length < 3,
           "email inválido mínimo de 3 caracteres");

        Nome = nome;
        Email = email;
        Senha = senha;
        Profissao = profissao;
        Celular = celular;
    }
}