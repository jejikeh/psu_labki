namespace ProjectManager.Domain;

public class Report
{
    public Guid Id { get; set; }
    
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }

    public string Info { get; set; } = string.Empty;
 
    public IList<ProjectReports> ProjectReports { get; set; } = [];
}