namespace ControleLancamento.Domain.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
    public DateTime DateCreate { get; private set; }
    public bool Active { get; private set; }
    public void SetInactive()
    {
        Active = false;
    }
}