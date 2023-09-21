using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class UserAccount : Entity
{
    public int AccountId { get; private set; }
    public Account Account { get; set; }
    public int UserId { get; private set; }
    public User user { get; set; }

    public UserAccount(int accountId, int userId)
    {
        ValidateDomain(accountId, userId);
    }
    public UserAccount(int id, int accountId, int userId)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(accountId, userId);
    }
    public void Update(int accountId, int userId)
    {
        ValidateDomain(accountId, userId);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(int accountId, int userId)
    {
        DomainExceptionValidation.When(accountId <= 0,
             "Campo CategoryId é requerido");

        DomainExceptionValidation.When(userId <= 0,
            "Campo CategoryId é requerido");

        AccountId = accountId;
        UserId = userId;
    }
}

