namespace WebApplication1.Model.Base;

public interface IModel
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}