using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class CategoryType : Entity
{
    public string Name { get; private set; }
    
    public CategoryType(string name, DateTime dateCreate)
    {
        ValidateDomain(name, dateCreate);
    }

    public CategoryType(int id, string name, DateTime dateCreate)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name, dateCreate);
    }
    public void Update(string name)
    {
        ValidateDomain(name, DateCreate);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(string name, DateTime dateCreate)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Campo name é requerido");

        DomainExceptionValidation.When(name.Length < 3,
           "name inválido mínimo de 3 caracteres");

        Name = name;
        DateCreate = dateCreate;
    }
}

