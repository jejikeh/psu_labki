namespace ProjectManager.Domain;

public class Project
{
    public Guid Id { get; set; }

    public ProjectDetails? ProjectDetails { get; set; }

    public Guid ProjectStageId { get; set; }
    public ProjectStatus ProjectStatus { get; set; } = null!;

    public IList<ProjectStage> Stages { get; set; } = [];
    
    public IList<ProjectReports> Reports { get; set; } = [];
    
    public IList<Team> Teams { get; set; } = [];
}