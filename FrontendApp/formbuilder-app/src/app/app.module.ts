import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { InitializerComponent } from './initializer/initializer.component';
import { FormsListComponent } from './forms-list/forms-list.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
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
import { BearerInterceptor } from './bearerInterceptor';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { FillFormComponent } from './fill-form/fill-form.component';
export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}
@NgModule({
  declarations: [
    AppComponent,
    InitializerComponent,
    FormsListComponent,
    PageNotFoundComponent,
    AccessDeniedComponent,
    FillFormComponent
  ],
  imports: [
    NotifierModule.withConfig({
      theme: 'material',
      behaviour: {
        autoHide: 5000
      }
    }),
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
