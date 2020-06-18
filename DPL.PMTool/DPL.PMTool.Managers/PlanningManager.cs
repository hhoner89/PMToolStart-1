using System;
using System.Collections.Generic;
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
            #region Sample code
            // this should load from the ProjectAccess service.
            // var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            // var dbProject = projectAccess.Project(id);
            // convert db project to client version

            //return new Project()
            //{
            //    Id =  id,
            //    Name = "TEST",
            //    Start = DateTime.Now,
            //    Activities = new [] {
            //        new Activity()
            //        {
            //            TaskName = "TEST",
            //        }
            //    }
            //};
            #endregion

            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            Accessors.Shared.EntityFramework.Project dbProject = projectAccess.Project(id);
            Accessors.Shared.EntityFramework.Activity[] dbActivities = projectAccess.ActivitiesForProject(id);

            Project clientProject = new Project();
            Activity[] clientActivities;
            
            if (dbActivities != null)
            {
                clientActivities = new Activity[dbActivities.Length];
                List<Activity> activitiesList = new List<Activity>();

                foreach (DPL.PMTool.Accessors.Shared.EntityFramework.Activity serverActivity in dbActivities)
                {
                    Activity clientActivity = new Activity();
                    clientActivity.Id = serverActivity.Id;
                    clientActivity.TaskName = serverActivity.TaskName;
                    clientActivity.Estimate = serverActivity.Estimate;
                    clientActivity.Predecessors = serverActivity.Predecessors;
                    clientActivity.Resource = serverActivity.Resource;
                    clientActivity.Priority = serverActivity.Priority;
                    clientActivity.Start = serverActivity.Start;
                    clientActivity.Finish = serverActivity.Finish;
                    clientActivity.ProjectId = id;
                    activitiesList.Add(clientActivity);
                }

                for (int i = 0; i < activitiesList.Count; i++)
                {
                    clientActivities[i] = activitiesList[i];
                }
            }
            else
            {
                clientActivities = new Activity[0];
            }
            
            if (dbProject != null)
            {
                clientProject.Id = dbProject.Id;
                clientProject.Name = dbProject.Name;
                clientProject.Start = dbProject.Start;
                clientProject.Activities = clientActivities;
            }

            return clientProject;
        }
        
        
        public Project SaveProject(Project project)
        {
            #region Placeholder code
            /*
            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            
            // you will need to copy properties across to the database versions of project / activity
            // var saved = projectAccess.SaveProject(dbProject);
            // return saved;
            
            // you will need to return a project, with data from the database.
            return project; // don't return this version.
            */
            #endregion

            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();

            #region Updating DB Project object
            DPL.PMTool.Accessors.Shared.EntityFramework.Project dbProject = projectAccess.Project(project.Id);

            if (dbProject == null)
            {
                dbProject = new DPL.PMTool.Accessors.Shared.EntityFramework.Project();
                dbProject.CreatedAt = DateTime.Now;
            }
            dbProject.Id = project.Id;
            dbProject.Name = project.Name;
            dbProject.Start = project.Start;
            dbProject.UpdatedAt = DateTime.Now;

            DPL.PMTool.Accessors.Shared.EntityFramework.Project returnedDbProject = projectAccess.SaveProject(dbProject);
            #endregion

            #region Updating DB Activity objects
            Activity[] activitiesList = project.Activities;
            List<Activity> newActivitiesList = new List<Activity>();
            foreach (Activity activity in activitiesList)
            {
                DPL.PMTool.Accessors.Shared.EntityFramework.Activity dbActivity = new DPL.PMTool.Accessors.Shared.EntityFramework.Activity();

                if (activity.Id != 0)
                {
                    dbActivity = projectAccess.Activity(activity.Id);
                }
                if (dbActivity == null)
                {
                    dbActivity = new DPL.PMTool.Accessors.Shared.EntityFramework.Activity();
                    dbActivity.CreatedAt = DateTime.Now;
                }

                dbActivity.Id = activity.Id;
                dbActivity.TaskName = activity.TaskName;
                dbActivity.Estimate = activity.Estimate;
                dbActivity.Predecessors = activity.Predecessors;
                dbActivity.Resource = activity.Resource;
                dbActivity.Priority = activity.Priority;
                dbActivity.Start = activity.Start;
                dbActivity.Finish = activity.Finish;
                dbActivity.ProjectId = returnedDbProject.Id;
                dbActivity.UpdatedAt = DateTime.Now;

                DPL.PMTool.Accessors.Shared.EntityFramework.Activity returnedDbActivity = projectAccess.SaveActivity(dbActivity);

                activity.Id = returnedDbActivity.Id;
                activity.TaskName = returnedDbActivity.TaskName;
                activity.Estimate = returnedDbActivity.Estimate;
                activity.Predecessors = returnedDbActivity.Predecessors;
                activity.Resource = returnedDbActivity.Resource;
                activity.Priority = returnedDbActivity.Priority;
                activity.Start = returnedDbActivity.Start;
                activity.Finish = returnedDbActivity.Finish;
                activity.ProjectId = returnedDbActivity.Id;

                newActivitiesList.Add(activity);
            }
            #endregion

            #region Update Client Project object
            Project newClientProject = new Project();

            newClientProject.Id = returnedDbProject.Id;
            newClientProject.Name = returnedDbProject.Name;
            newClientProject.Start = returnedDbProject.Start;
            for (int i = 0; i < newActivitiesList.Count; i++)
            {
                activitiesList[i] = newActivitiesList[i];
            }
            newClientProject.Activities = activitiesList;
            #endregion

            return newClientProject;
        }
    }
}