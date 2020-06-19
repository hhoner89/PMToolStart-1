import { Injectable } from '@angular/core';
import { Project } from '../dtos/Project';
import { ProjectListItem } from '../dtos/ProjectListItem';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PlanningService {

  constructor(private httpClient: HttpClient) { }

  public async newProject(): Promise<Project> {
    const promise = new Promise<Project>((resolve, reject) => {
      resolve({
        id: 1,
        name: 'eCommerce',
        start: new Date(),
        activities: [{
          id: 1,
          taskName: 'Setup DB',
          start: new Date(),
          finish: new Date(),
          estimate: 1.0,
          predecessors: "1",
          resource: 'Doug',
          priority: 500,
          projectId: 1          
        },
        {
          id: 2,
          taskName: 'Catalog Access',
          start: new Date(),
          finish: new Date(),
          estimate: 1.0,
          predecessors: "1",
          resource: 'Doug',
          priority: 500,
          projectId: 1
        },
        {
          id: 3,
          taskName: 'Order Access',
          start: new Date(),
          finish: new Date(),
          estimate: 1.0,
          predecessors: "1",
          resource: 'Doug',
          priority: 500,
          projectId: 1
        }]
      });
    });
    return promise;
  }

  public async saveProject(project: Project): Promise<Project> {
    //console.log(project.id);
    //alert('save method reached');
    // note: the data might not match with server.
    return this.httpClient.post<Project>(
      'https://localhost:44347/Planning/SaveProject', project).toPromise();
  }

  public async getAllProjects(): Promise<ProjectListItem[]> {
    return this.httpClient.get<ProjectListItem[]>(
      'https://localhost:44347/Planning/GetAllProjects').toPromise();
  }

  public async getProject(projectId: number): Promise<Project> {
    return this.httpClient.get<Project>(
      'https://localhost:44347/Planning/GetProject').toPromise();
  }
}
