namespace Pattern.Nanoservice.Domain.Interface
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
