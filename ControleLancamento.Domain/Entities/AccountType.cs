using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class AccountType : Entity
{
    public string Name { get; private set; }
    
    public AccountType(string name)
    {
        ValidateDomain(name);
    }

    public AccountType(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name);
    }
    public void Update(string name)
    {
        ValidateDomain(name);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Campo name é requerido");

        DomainExceptionValidation.When(name.Length < 3,
           "Invalid name, too short, minimum 3 characters");

        DomainExceptionValidation.When(name.Length > 100,
           "Invalid name, too short, maximum 100 characters");

        Name = name;
    }
}

