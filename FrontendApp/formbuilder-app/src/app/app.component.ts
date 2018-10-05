import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public languages = [
    { id: 'en', name: 'English' },
    { id: 'ru', name: 'Русский' }
  ];
  public get selectedLang() {
    return this.translate.currentLang;
  }
  public set selectedLang(lang) {
    this.translate.use(lang);
  }
  public isLoggedIn = () => this.auth.isAuthenticated();
  public logout = () => this.auth.logout();
  public getUserName = () => this.auth.getUserName();
  constructor(private translate: TranslateService, private auth: AuthService) {
    // this language will be used as a fallback when a translation isn't found in the current language
    translate.setDefaultLang('en');
    // the lang to use, if the lang isn't available, it will use the current loader to get them
    translate.use('ru');
  }
}
