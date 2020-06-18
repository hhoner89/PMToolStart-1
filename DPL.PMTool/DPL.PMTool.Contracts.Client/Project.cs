using System;

namespace DPL.PMTool.Managers
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }

        public Activity[] Activities { get; set; }
    }
}