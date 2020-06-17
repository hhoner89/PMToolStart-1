using Microsoft.AspNetCore.Mvc;
using DPL.PMTool.Managers;
using DPL.PMTool.Common.Contracts;

namespace DPL.PMTool.Client.Web.Controllers
{
    public class PlanningController : Controller
    {
        private AmbientContext _context;
        private ManagerFactory _managerFactory;
        private IPlanningManager _planningManager;
        
        public PlanningController()
        {
            _context = new AmbientContext();
            _managerFactory = new ManagerFactory(_context);
            _planningManager = _managerFactory.CreateManager<IPlanningManager>();
        }
         
        public TestMeResponse Test()
        {
            return _planningManager.TestMe();
        }

        [HttpPost]
        public Project SaveProject(Project project)
        {
            return _planningManager.SaveProject(project);
        }
    }
}