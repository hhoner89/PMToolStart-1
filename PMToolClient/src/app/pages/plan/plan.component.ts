import { Component, OnInit } from '@angular/core';
import { PlanningService } from 'src/app/services/planning.service';
import { Project } from 'src/app/dtos/Project';

@Component({
  selector: 'app-plan',
  templateUrl: './plan.component.html',
  styleUrls: ['./plan.component.scss']
})
export class PlanComponent implements OnInit {

  project: Project;
  headers: Array<string>;

  constructor(private planningService: PlanningService) { 
    this.headers = ['Id', 'Task Name', 'Estimate', 'Predecessors', 'Resource', 'Priority', 'Start', 'Finish'];
  }

  async ngOnInit() {
    this.project = await this.planningService.newProject();
  }

  async saveProject() {
    alert('save project. call the planning service.');
  }

  async addRow() {
    this.project.activities.push({
      id: 0,
      taskName: 'NEW',
      start: new Date(),
      finish: new Date(),
      estimate: 1.0,
      predecessor: 1,
      resource: 'Doug',
      priority: 500
    });
  }
}
