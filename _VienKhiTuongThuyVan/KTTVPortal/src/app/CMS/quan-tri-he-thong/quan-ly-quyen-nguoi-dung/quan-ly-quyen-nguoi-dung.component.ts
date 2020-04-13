import { Component, OnInit } from '@angular/core';
import { IdmRight, IdmRightCreateRequestModel, IdmRightUpdateRequestModel, IdmRightFilter } from '../../services/idm-right/idm-right.model';
import { IdmRightService } from '../../services/idm-right/idm-right.service';
import { DemoUserId } from 'src/app/app.config';
import { Status } from 'src/app/_layout/utils/common-classes';
import { NotificationService } from 'src/app/_layout/services/notification.service'
import { ITreeOptions, TreeNode } from 'angular-tree-component';

// interface RightNode {
//   data: IdmRight;
//   children?: RightNode[];
// }

@Component({
  selector: 'app-quan-ly-quyen-nguoi-dung',
  templateUrl: './quan-ly-quyen-nguoi-dung.component.html',
  styleUrls: ['./quan-ly-quyen-nguoi-dung.component.css']
})
export class QuanLyQuyenNguoiDungComponent implements OnInit {

  constructor(
    private IdmRightService: IdmRightService,
    private NotificationService: NotificationService) { }

  public model = new IdmRight();
  public data = {};
  public nodes = [];
  public treeOptions: ITreeOptions = {
    idField: 'RightId',
    displayField: 'RightName',
    childrenField: 'InverseGroupIdNavigation',
    actionMapping: {},

    //isExpandedField: 'IsGroup',
    //getChildren: this.getChildren.bind(this),

  }
  public isUpdate = false;
  public button = {
    Refresh: {
      Click: () => {
        //debugger;
        this.getData();
        //this.model = new IdmRight();
      }
    },
    Add: {
      Click: (form) => {
        this.isUpdate = false;
        this.getData();
        this.model = new IdmRight();
        
        form.form.markAsPristine();
        form.form.markAsUntouched();
      }
    },
  };

  Submit(form) {
    //debugger;
    if (form.invalid || !form.dirty) {
      return;
    }
    else {
      if (this.isUpdate) {
        let model = new IdmRightUpdateRequestModel();
        model = this.model;
        model.LastModifiedByUserId = DemoUserId;
        this.IdmRightService.Update(model).subscribe(response => {
          if (response['Status'] == Status.SUCCESS) {
            this.NotificationService.ForUpdate(true);
            this.getData(model.RightId);
            form.form.markAsPristine();
          }
          else {
            this.NotificationService.ForUpdate(false);
          }
        });
      }
      else {
        let model = new IdmRightCreateRequestModel();
        debugger;
        model = this.model;
        model.CreatedByUserId = DemoUserId;
        this.IdmRightService.Create(model).subscribe(response => {
          if (response['Status'] == Status.SUCCESS) {
            this.NotificationService.ForCreate(true);
            this.button.Refresh.Click();
            form.resetForm();
          }
          else {
            this.NotificationService.ForCreate(false);
          }
        });
      }
    }
  }

  getData(rightId?: string, form?: any) {

    let filter = new IdmRightFilter();

    this.IdmRightService.GetFilter(filter).subscribe(response => {
      this.data = response;
      this.nodes = this.data['Data'];
      if (rightId != undefined && rightId && rightId != '') {
        this.isUpdate = true;
        filter:
        for (let i = 0; i < this.nodes.length; i++) {
          for (let j = 0; j < this.nodes[i].InverseGroupIdNavigation.length; j++) {
            if (this.nodes[i].InverseGroupIdNavigation[j].RightId == rightId) {
              this.model = this.nodes[i].InverseGroupIdNavigation[j];
              break filter;
            }
          }
        }
      }
      else {
        this.model = new IdmRight();
      }
      if (form != undefined) {
        form.form.markAsPristine();
        form.form.markAsUntouched();
      }
    });
  }

  public searchText = '';
  emptySearch() {
    this.searchText = '';
  }

  ngOnInit() {
    this.getData();
  }

}
