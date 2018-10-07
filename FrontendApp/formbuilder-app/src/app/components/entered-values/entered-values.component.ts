import { Component, OnInit } from '@angular/core';
import { FormDefinition } from 'src/app/models/formDefinition';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs/internal/observable/of';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-entered-values',
  templateUrl: './entered-values.component.html',
  styleUrls: ['./entered-values.component.scss']
})
export class EnteredValuesComponent implements OnInit {
  constructor(private route: ActivatedRoute, private api: ApiService) { }
  metadata: FormDefinition;
  dataSource = [];

  public loading = true;
  public columnsToDisplay = [];
  public ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.api.getObjects(id).subscribe(x => {
      this.metadata = x.formDefinition;
      this.columnsToDisplay = x.formDefinition.fields.map(f => f.fieldKey);
      this.dataSource = x.objects;
      this.loading = false;
    });
  }
  public columnNameByKey = (key) => this.metadata.fields.filter(x => x.fieldKey === key).map(x => x.fieldName)[0];
}
