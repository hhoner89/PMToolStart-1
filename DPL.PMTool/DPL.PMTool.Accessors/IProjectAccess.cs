using DPL.PMTool.Accessors.Shared.EntityFramework;

namespace DPL.PMTool.Accessors
{
    public interface IProjectAccess
    {
        Project[] Projects();
        Project Project(int id);
        Project SaveProject(Project project);


        Activity Activity(int id);
        Activity SaveActivity(Activity activity);
        Activity[] ActivitiesForProject(int projectId);
    }
}