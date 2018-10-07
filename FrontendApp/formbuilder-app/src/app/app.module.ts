import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { NgSelectModule } from '@ng-select/ng-select';
import { NotifierModule } from 'angular-notifier';
import { MatTableModule } from '@angular/material/table';
import { BearerInterceptor } from './services/bearerInterceptor';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatListModule } from '@angular/material/list';
import { MatRadioModule } from '@angular/material/radio';
import { AccessDeniedComponent } from './components/error_pages/access-denied/access-denied.component';
import { FillFormComponent } from './components/fill-form/fill-form.component';
import { FieldWrapperComponent } from './components/field-wrapper/field-wrapper.component';
import { OopsComponent } from './components/error_pages/oops/oops.component';
import { NotfoundComponent } from './components/error_pages/notfound/notfound.component';
import { EnteredValuesComponent } from './components/entered-values/entered-values.component';
import { ValidationErrorsComponent } from './components/validation-errors/validation-errors.component';
import { InitializerComponent } from './components/initializer/initializer.component';
import { FormsListComponent } from './components/forms-list/forms-list.component';
export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}
@NgModule({
  declarations: [
    AppComponent,
    InitializerComponent,
    FormsListComponent,
    AccessDeniedComponent,
    FillFormComponent,
    FieldWrapperComponent,
    OopsComponent,
    NotfoundComponent,
    ValidationErrorsComponent,
    EnteredValuesComponent
  ],
  imports: [
    NotifierModule.withConfig({
      theme: 'material',
      behaviour: {
        autoHide: 5000
      }
    }),
    MatRadioModule,
    MatCheckboxModule,
    MatListModule,
    NgSelectModule,
    MatTableModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatStepperModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: BearerInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
