import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

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

  constructor(private translate: TranslateService) {
    // this language will be used as a fallback when a translation isn't found in the current language
    translate.setDefaultLang('en');
    // the lang to use, if the lang isn't available, it will use the current loader to get them
    translate.use('ru');
  }
}
