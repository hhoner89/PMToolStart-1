using System;

namespace DPL.PMTool.Managers
{
    public class Activity
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public decimal Estimate { get; set; }
        public string Predecessors { get; set; }
        public string Resource { get; set; }
        public string Priority { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ProjectId { get; set; }
    }
}