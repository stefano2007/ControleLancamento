using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Occupation { get; private set; }
    public string CellPhone { get; private set; }

    public User(string name, string email, string password, string occupation, string cellPhone)
    {
        ValidateDomain(name, email, password, occupation, cellPhone);
    }

    public User(int id, string name, string email, string password, string occupation, string cellPhone)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name, email, password, occupation, cellPhone);
    }
    public void Delete()
    {
        SetInactive();
    }
    public void ValidateDomain(string name, string email, string password, string occupation, string cellPhone)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Campo name é requerido");

        DomainExceptionValidation.When(name.Length < 3,
           "name inválido mínimo de 3 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "Campo email é requerido");

        DomainExceptionValidation.When(email.Length < 3,
           "email inválido mínimo de 3 caracteres");

        Name = name;
        Email = email;
        Password = password;
        Occupation = occupation;
        CellPhone = cellPhone;
    }
}