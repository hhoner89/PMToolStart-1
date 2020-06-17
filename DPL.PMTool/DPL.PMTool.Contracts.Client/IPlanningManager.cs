using DPL.PMTool.Accessors.Shared.EntityFramework;

namespace DPL.PMTool.Managers
{
    public interface IPlanningManager
    {
        TestMeResponse TestMe();

        
        Project SaveProject(Project project);
    }
}