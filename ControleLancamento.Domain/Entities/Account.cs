using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class Account : Entity
{
    public int AccountTypeId { get; private set; }
    public string Name { get; private set; }
    public AccountType AccountType { get; private set; }

    private readonly List<Launch> _launchs;
    public IReadOnlyCollection<Launch> Launchs => _launchs;
    public Account(int accountTypeId, string name)
    {
        ValidateDomain(accountTypeId, name);
    }
    public Account(int id, int accountTypeId, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(accountTypeId, name);
    }
    public void Update(int accountTypeId, string name)
    {
        ValidateDomain(accountTypeId, name);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(int accountTypeId, string name)
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

