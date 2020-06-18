import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/dtos/Project';
import { ProjectListItem } from 'src/app/dtos/ProjectListItem';
import { Router } from '@angular/router';

@Component({
  selector: 'app-plan-list',
  templateUrl: './plan-list.component.html',
  styleUrls: ['./plan-list.component.scss']
})
export class PlanListComponent implements OnInit {

  projects: ProjectListItem[];

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.projects = [{
      id: 1,
      name: 'project 1',
    }, {
      id: 2,
      name: 'project 2',
    }
    ];
  }

  openProject(id: number) {
    this.router.navigate(['/plan/' + id]);
  }

}
