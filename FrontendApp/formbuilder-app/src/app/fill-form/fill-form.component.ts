import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { FormDefinition } from '../models/formDefinition';
import { FormGroup } from '@angular/forms';
import { toFormGroup } from 'src/app/shared.functions';
import { Location } from '@angular/common';

@Component({
  selector: 'app-fill-form',
  templateUrl: './fill-form.component.html',
  styleUrls: ['./fill-form.component.scss']
})
export class FillFormComponent implements OnInit {

  public formDefinition: FormDefinition = {} as FormDefinition;
  public form: FormGroup = new FormGroup({});
  errors: string[] = [];
  constructor(private route: ActivatedRoute, private location: Location, private api: ApiService) { }

  public back = () => this.location.back();
  public ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.api.getFormDefinition(id).subscribe(x => {
      this.formDefinition = x;
      this.form = toFormGroup(x.fields.map(f => ({ ...f, value: '' })));
    });
  }
  public onSubmit() {
    this.api.saveForm(this.formDefinition.id, this.form.value).subscribe(() => this.back());
  }

}
