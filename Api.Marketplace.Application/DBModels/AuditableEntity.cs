namespace Api.Marketplace.Application.DBModels;

public class AuditableEntity
{
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
}
