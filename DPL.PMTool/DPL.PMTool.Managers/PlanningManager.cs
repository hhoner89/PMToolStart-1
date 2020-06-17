using DPL.PMTool.Accessors;
using DPL.PMTool.Accessors.Shared.EntityFramework;
using DPL.PMTool.Managers.Shared;

namespace DPL.PMTool.Managers
{
    public class PlanningManager : ManagerBase, IPlanningManager
    {
        public TestMeResponse TestMe()
        {
            return new TestMeResponse()
            {
                Message = "TestMe"
            };
        }

        public Project SaveProject(Project project)
        {
            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            var saved = projectAccess.SaveProject(project);
            return saved;
        }
    }
}