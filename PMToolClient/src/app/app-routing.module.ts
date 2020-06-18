import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestComponent } from './pages/test/test.component';
import { PlanComponent } from './pages/plan/plan.component';
import { PlanListComponent } from './pages/plan-list/plan-list.component';


const routes: Routes = [
  { path: 'test', component: TestComponent},
  { path: 'plan/:id', component: PlanComponent},
  { path: 'planlist', component: PlanListComponent},
  { path: '**', redirectTo: '/planlist'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
