import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InitializerComponent } from './initializer/initializer.component';
import { AuthGuard } from './auth.guard';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { FormsListComponent } from './forms-list/forms-list.component';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { FillFormComponent } from './fill-form/fill-form.component';
const routes: Routes = [
  { path: '', component: FormsListComponent, canActivate: [AuthGuard] },
  { path: 'init', component: InitializerComponent },
  { path: 'fill-form/:id', component: FillFormComponent },
  { path: 'access-denied', component: AccessDeniedComponent },
  { path: '**', component: PageNotFoundComponent }
];
@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
