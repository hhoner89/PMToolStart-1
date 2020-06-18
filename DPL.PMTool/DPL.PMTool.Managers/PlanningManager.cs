using System;
using DPL.PMTool.Accessors;
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

        public Project Project(int id)
        {
            // this should load from the ProjectAccess service.
            // var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            // var dbProject = projectAccess.Project(id);
            // convert db project to client version
            
            return new Project()
            {
                Id =  id,
                Name = "TEST",
                Start = DateTime.Now,
                Activities = new [] {
                    new Activity()
                    {
                        TaskName = "TEST",
                    }
                }
            };
        }
        
        
        public Project SaveProject(Project project)
        {
            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            
            // you will need to copy properties across to the database versions of project / activity
            // var saved = projectAccess.SaveProject(dbProject);
            // return saved;
            
            // you will need to return a project, with data from the database.
            return project; // don't return this version.
        }
    }
}