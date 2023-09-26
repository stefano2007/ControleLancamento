namespace ControleLancamento.Domain.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
    public DateTime DateCreate { get; protected set; } = DateTime.Now;
    public bool Active { get; private set; } = true;
    public void SetInactive()
    {
        Active = false;
    }
}