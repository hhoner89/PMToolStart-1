import { Injectable } from '@angular/core';
import { Project } from '../dtos/Project';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlanningService {

  constructor() { }

  public async newProject(): Promise<Project> {
    const promise = new Promise<Project>((resolve, reject) => {
      resolve({
        id: 1,
        name: 'eCommerce',
        startDate: new Date(),
        activities: [{
          id: 1,
          taskName: 'Setup DB',
          start: new Date(),
          finish: new Date(),
          estimate: 1.0,
          predecessor: 1,
          resource: 'Doug',
          priority: 500 
        }, 
        {
          id: 2,
          taskName: 'Catalog Access',
          start: new Date(),
          finish: new Date(),
          estimate: 1.0,
          predecessor: 1,
          resource: 'Doug',
          priority: 500 
        },
        {
          id: 3,
          taskName: 'Order Access',
          start: new Date(),
          finish: new Date(),
          estimate: 1.0,
          predecessor: 1,
          resource: 'Doug',
          priority: 500 
        }]
      });
    });
  
    return promise;
  }
}
