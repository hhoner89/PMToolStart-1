using DPL.PMTool.Accessors.Shared.EntityFramework;

namespace DPL.PMTool.Managers
{
    public interface IPlanningManager
    {
        TestMeResponse TestMe();

        Project Project(int id);
        Project SaveProject(Project project);
        
        Project GetProject(int id);
        ProjectListItem[] GetAllProjects();
    }
}