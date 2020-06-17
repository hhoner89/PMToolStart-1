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

}
