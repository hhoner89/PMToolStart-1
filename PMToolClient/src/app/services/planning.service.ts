import { Injectable } from '@angular/core';
import { Project } from '../dtos/Project';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

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
    // note: the data might not match with server.
    return this.httpClient.post<Project>(
      'https://localhost:5001/Planning/SaveProject', project).toPromise();
  }
}
