using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class Category : Entity
{    
    public string Name { get; private set; }
    public string? Color { get; private set; }
    public string? Icon { get; private set; }

    public Category(string name, string color, string icon)
    {
        ValidateDomain(name, color, icon);
    }
    public Category(int id, string name, string color, string icon)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;

        ValidateDomain(name, color, icon);
    }
    public void Update(string name, string color, string icon)
    {
        ValidateDomain(name, color, icon);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(string name, string color, string icon)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name is required");

        DomainExceptionValidation.When(name.Length < 3,
           "Invalid name, too short, minimum 3 characters");

        DomainExceptionValidation.When(name.Length > 100,
           "Invalid name, too large, maximum 100 characters");

        DomainExceptionValidation.When(!string.IsNullOrEmpty(color) && color.Length > 7,
           "Invalid color, too large, maximum 7 characters");

        DomainExceptionValidation.When(!string.IsNullOrEmpty(icon) && icon.Length > 20,
           "Invalid icon, too large, maximum 20 characters");

        Name = name;
        Color = color;
        Icon = icon;
    }
}
