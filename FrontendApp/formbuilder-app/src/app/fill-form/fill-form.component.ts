import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { FormDefinition } from '../models/formDefinition';
import { FormGroup } from '@angular/forms';
import { toFormGroup } from 'src/app/shared.functions';

@Component({
  selector: 'app-fill-form',
  templateUrl: './fill-form.component.html',
  styleUrls: ['./fill-form.component.scss']
})
export class FillFormComponent implements OnInit {

  public formDefinition: FormDefinition = {} as FormDefinition;
  public form: FormGroup = new FormGroup({});
  constructor(private route: ActivatedRoute, private api: ApiService) { }


  public ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.api.getFormDefinition(id).subscribe(x => {
      this.formDefinition = x;
      this.form = toFormGroup(x.fields.map(f => ({ ...f, value: '' })));
    });
  }
  public onSubmit() {

  }

}
