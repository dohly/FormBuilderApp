import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { NotifierService } from 'angular-notifier';
import { TranslateService } from '@ngx-translate/core';
import { MatStepper } from '@angular/material/stepper';
import { User } from 'src/app/models/user';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

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
  public testUsers: Observable<User[]>;
  constructor(private _formBuilder: FormBuilder,
    private translate: TranslateService,
    private auth: AuthService,
    private api: ApiService, private notify: NotifierService) { }

  ngOnInit() {
    this.apiAddessForm = this._formBuilder.group({
      apiUrl: [this.api.apiHost, Validators.required]
    });
    this.loginForm = this._formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  public connect(apiHost: string) {
    this.connecting = true;
    this.api.configureAndConnect(apiHost)
      .subscribe(
        () => {
          this.stepper.selectedIndex = 1;
          this.testUsers = this.auth.TestUsers;
        },
        (err) => {
          console.error(err);
          this.connectError();
        }).add(() => this.connecting = false);
  }
  public login = () => this.auth.login(this.loginForm.value).subscribe(
    () => this.stepper.next(),
    (err) => {
      if (err && err.status === 401) {
        this.notify.notify('error', this.translate.instant('INVALID_CREDENTIALS'));
      } else {
        this.connectError();
      }
    })
  public selectTestUser(selectedUser: User) {
    if (selectedUser) {
      const { login, password } = selectedUser;
      this.loginForm.patchValue({ login, password });
    } else {
      this.loginForm.patchValue({ login: '', password: '' });
    }
  }
  private connectError = () => this.notify.notify('error', this.translate.instant('CONNECT_ERROR'));
}
