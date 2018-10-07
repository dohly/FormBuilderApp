import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsListComponent } from './components/forms-list/forms-list.component';
import { AuthGuard } from './services/auth.guard';
import { InitializerComponent } from './components/initializer/initializer.component';
import { FillFormComponent } from './components/fill-form/fill-form.component';
import { EnteredValuesComponent } from './components/entered-values/entered-values.component';
import { AccessDeniedComponent } from './components/error_pages/access-denied/access-denied.component';
import { OopsComponent } from './components/error_pages/oops/oops.component';
import { NotfoundComponent } from './components/error_pages/notfound/notfound.component';
const routes: Routes = [
  { path: '', component: FormsListComponent, canActivate: [AuthGuard] },
  { path: 'init', component: InitializerComponent },
  { path: 'new/:id', component: FillFormComponent, canActivate: [AuthGuard] },
  { path: 'objects/:id', component: EnteredValuesComponent, canActivate: [AuthGuard] },
  { path: 'access-denied', component: AccessDeniedComponent },
  { path: 'oops', component: OopsComponent },
  { path: 'notfound', component: NotfoundComponent },
  { path: '**', component: NotfoundComponent }
];
@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
