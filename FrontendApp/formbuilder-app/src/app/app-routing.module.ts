import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InitializerComponent } from './initializer/initializer.component';
import { AuthGuard } from './auth.guard';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { FormsListComponent } from './forms-list/forms-list.component';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { FillFormComponent } from './fill-form/fill-form.component';
import { OopsComponent } from './oops/oops.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { EnteredValuesComponent } from './entered-values/entered-values.component';
const routes: Routes = [
  { path: '', component: FormsListComponent, canActivate: [AuthGuard] },
  { path: 'init', component: InitializerComponent },
  { path: 'new/:id', component: FillFormComponent, canActivate: [AuthGuard] },
  { path: 'edit/:id', component: FillFormComponent, canActivate: [AuthGuard] },
  { path: 'objects/:id', component: EnteredValuesComponent, canActivate: [AuthGuard] },
  { path: 'access-denied', component: AccessDeniedComponent },
  { path: 'oops', component: OopsComponent },
  { path: 'notfound', component: NotfoundComponent },
  { path: '**', component: PageNotFoundComponent }
];
@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
