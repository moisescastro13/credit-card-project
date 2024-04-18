namespace CreditCardApi.Domain.Entities;
public class Entity<T>
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeleteAt { get; set; }
    public DateTime? UpdateAt { get; set; }

    public Entity()
    {
    }
}
public interface BaseRecordID
{
    Guid value { get; }
}
