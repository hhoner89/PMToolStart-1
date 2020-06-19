import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/dtos/Project';
import { ProjectListItem } from 'src/app/dtos/ProjectListItem';
import { Router } from '@angular/router';
import { PlanningService } from 'src/app/services/planning.service';

@Component({
  selector: 'app-plan-list',
  templateUrl: './plan-list.component.html',
  styleUrls: ['./plan-list.component.scss']
})
export class PlanListComponent implements OnInit {

  projects: ProjectListItem[];

  constructor(
    private router: Router,
    private planningService: PlanningService) { }

  async ngOnInit() {
  
    // this.projects = [{
    //   id: 1,
    //   name: 'project 1',
    // }, {
    //   id: 2,
    //   name: 'project 2',
    // }
    // ];
    
    this.projects = await this.planningService.getAllProjects();

  }

  openProject(id: number) {
    this.router.navigate(['/plan/' + id]);
  }

}
