using System;
using DPL.PMTool.Accessors;
using DPL.PMTool.Managers.Shared;
using DPL.PMTool.Accessors.Shared.EntityFramework;
using System.Linq;
using System.Collections.Generic;

namespace DPL.PMTool.Managers
{
    public class PlanningManager : ManagerBase, IPlanningManager
    {
        public TestMeResponse TestMe()
        {
            return new TestMeResponse()
            {
                Message = "Hi Chad"
            };
        }

        public Project Project(int id)
        {
            // this should load from the ProjectAccess service.
            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            var dbProject = projectAccess.Project(id);
            var dbActivities = projectAccess.ActivitiesForProject(id);

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
            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();

            int projectId = project.Id;
            string projectName = project.Name;
            DateTime projectStart = project.Start;
            Activity[] activitiesList = project.Activities;
            List<Activity> newActivitiesList = new List<Activity>();


            // UPDATING/SAVING PROJECT
            DPL.PMTool.Accessors.Shared.EntityFramework.Project dbProject = projectAccess.Project(projectId);
            
            if (dbProject == null)
            {
                dbProject = new DPL.PMTool.Accessors.Shared.EntityFramework.Project();
                dbProject.CreatedAt = DateTime.Now;
            }
            dbProject.Id = projectId;
            dbProject.Name = projectName;
            dbProject.Start = projectStart;
            dbProject.UpdatedAt = DateTime.Now;

            DPL.PMTool.Accessors.Shared.EntityFramework.Project returnedDbProject = projectAccess.SaveProject(dbProject);


            // UPDATING/SAVING ACTIVITIES
            
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

            // UPDATE PROJECT OBJECT BEFORE RETURNING IT
            project.Id = returnedDbProject.Id;
            project.Name = returnedDbProject.Name;
            project.Start = returnedDbProject.Start;
            for (int i = 0; i < newActivitiesList.Count; i++)
            {
                activitiesList[i] = newActivitiesList[i];
            }
            project.Activities = activitiesList;

            return project;
        }
    }
}