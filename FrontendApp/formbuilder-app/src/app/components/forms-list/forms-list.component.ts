import { Component, OnInit } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { FormDefinition } from 'src/app/models/formDefinition';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-forms-list',
  templateUrl: './forms-list.component.html',
  styleUrls: ['./forms-list.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0', display: 'none' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class FormsListComponent implements OnInit {

  columnsToDisplay = ['name', 'fieldsCount', 'objectsCount', 'actions'];
  expandedElement: FormDefinition;
  dataSource = this.api.getFormDefinitions();
  constructor(private api: ApiService) { }

  ngOnInit() {
  }

}
