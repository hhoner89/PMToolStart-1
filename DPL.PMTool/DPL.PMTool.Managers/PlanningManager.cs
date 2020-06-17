using System;
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
            
            // you will need to copy properties across to the database versions of project / activity
            // var saved = projectAccess.SaveProject(dbProject);
            // return saved;
            
            // you will need to return a project, not throw an exception.
            throw new NotImplementedException();
        }
    }
}