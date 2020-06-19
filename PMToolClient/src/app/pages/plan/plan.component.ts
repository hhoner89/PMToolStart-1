import { Component, OnInit } from '@angular/core';
import { PlanningService } from 'src/app/services/planning.service';
import { Project } from 'src/app/dtos/Project';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-plan',
  templateUrl: './plan.component.html',
  styleUrls: ['./plan.component.scss']
})
export class PlanComponent implements OnInit {

  project: Project = {
    id: 0,
    name: '',
    start: new Date(),
    activities: []
  };
  headers: Array<string>;

  constructor(
    private route: ActivatedRoute,
    private planningService: PlanningService) {
    this.headers = ['Id', 'Task Name', 'Estimate', 'Predecessors', 'Resource', 'Priority', 'Start', 'Finish'];
  }

  async ngOnInit() {
    this.route.params.subscribe(async params => {
      console.log(params.id);
      if (params.id > 0) {
        // load a project
        this.project = await this.planningService.getProject(params.id);

      } else {
        // new project
        this.project = await this.planningService.newProject();
      }
    });
  }

  async saveProject() {
    this.project = await this.planningService.saveProject(this.project);
    //console.log(this.project);
  }

  async addRow() {
    this.project.activities.push({
      id: 0,
      taskName: 'NEW',
      start: new Date(),
      finish: new Date(),
      estimate: 1.0,
      predecessors: '1',
      resource: 'Doug',
      priority: 500,
      projectId: 1,
    });
  }
}
