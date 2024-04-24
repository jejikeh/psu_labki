namespace ProjectManager.Domain;

public class ProjectReports
{
    public Guid ProjectId { get; set; }
    public Guid ReportId { get; set; }
    public Project Project { get; set; } = null!;
    public Report Report { get; set; } = null!;
}