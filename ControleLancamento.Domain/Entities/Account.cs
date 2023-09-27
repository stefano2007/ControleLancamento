using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class Account : Entity
{
    public string Name { get; private set; }
    public int AccountTypeId { get; private set; }
    public AccountType AccountType { get; set; }

    public Account(string name, int categoryId)
    {
        ValidateDomain(name, categoryId);
    }
    public Account(int id, string name, int accountTypeId)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name, accountTypeId);
    }
    public void Update(string name, int accountTypeId)
    {
        ValidateDomain(name, accountTypeId);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(string name, int accountTypeId)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name is requerid");

        DomainExceptionValidation.When(name.Length < 3,
           "Invalid name minimum de 3 caracters");

        DomainExceptionValidation.When(accountTypeId <= 0,
            "Invalid CategoryId is requerid");

        Name = name;
        AccountTypeId = accountTypeId;
    }
}

