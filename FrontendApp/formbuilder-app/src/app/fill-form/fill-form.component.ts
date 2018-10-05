import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { FormDefinition } from '../models/formDefinition';

@Component({
  selector: 'app-fill-form',
  templateUrl: './fill-form.component.html',
  styleUrls: ['./fill-form.component.scss']
})
export class FillFormComponent implements OnInit {

  public formDefinition: FormDefinition = {} as FormDefinition;
  constructor(private route: ActivatedRoute, private api: ApiService) { }


  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.api.getFormDefinition(id).subscribe(x => this.formDefinition = x);
  }

}
