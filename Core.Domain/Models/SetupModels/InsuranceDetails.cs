namespace Core.Domain.Models.SetupModels;

public class InsuranceDetails:BaseSetup
{
    public int Rate { get; set; }   
    public Guid IndustryId { get; set; }
}