using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class UserAccount : Entity
{
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public int UserId { get; set; }
    public User user { get; set; }
    public bool IsUserMain { get; set; }

    public UserAccount(int accountId, int userId, bool isUserMain)
    {
        ValidateDomain(accountId, userId, isUserMain);
    }
    public UserAccount(int id, int accountId, int userId, bool isUserMain)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(accountId, userId, isUserMain);
    }
    public void Update(int accountId, int userId, bool isUserMain)
    {
        ValidateDomain(accountId, userId, isUserMain);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(int accountId, int userId, bool isUserMain)
    {
        DomainExceptionValidation.When(accountId <= 0,
             "Campo CategoryId é requerido");

        DomainExceptionValidation.When(userId <= 0,
            "Campo CategoryId é requerido");

        AccountId = accountId;
        UserId = userId;
        IsUserMain = isUserMain;
    }
}

