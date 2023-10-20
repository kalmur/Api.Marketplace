namespace Api.Marketplace.Application.DBModels;

public class AuditableEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
