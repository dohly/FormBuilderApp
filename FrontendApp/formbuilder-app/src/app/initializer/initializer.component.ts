import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ApiService } from '../api.service';
import { NotifierService } from 'angular-notifier';
import { TranslateService } from '@ngx-translate/core';
import { MatStepper } from '@angular/material/stepper';
@Component({
  selector: 'app-initializer',
  templateUrl: './initializer.component.html',
  styleUrls: ['./initializer.component.scss']
})
export class InitializerComponent implements OnInit {
  @ViewChild('stepper') stepper: MatStepper;
  public apiAddessForm: FormGroup;
  public loginForm: FormGroup;
  public connecting = false;
  constructor(private _formBuilder: FormBuilder,
    private translate: TranslateService,
    private api: ApiService, private notify: NotifierService) { }

  ngOnInit() {
    this.apiAddessForm = this._formBuilder.group({
      apiUrl: [this.api.apiHost, Validators.required]
    });
    this.loginForm = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
  }
  public connect(apiHost: string) {
    this.connecting = true;
    this.api.configureAndConnect(apiHost)
      .subscribe(() => this.stepper.selectedIndex = 1,
        (err) => {
          console.error(err);
          this.notify.notify('error', this.translate.instant('CONNECT_ERROR'));
        }).add(() => this.connecting = false);
  }
}
