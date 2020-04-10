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
    idField: 'RightCode',
    displayField: 'RightName',
    childrenField: 'InverseGroupCodeNavigation',
    
    //isExpandedField: 'IsGroup',
    //getChildren: this.getChildren.bind(this),

  }
  public isUpdate = false;
  public button = {
    Refresh: {
      Click() {
        this.getData();
      }
    },
    Add: {
      Click() {
        this.isUpdate = false;

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
          }
          else {
            this.NotificationService.ForUpdate(false);
          }
        });
      }
      else {
        let model = new IdmRightCreateRequestModel();
        model = this.model;
        model.CreatedByUserId = DemoUserId;
        this.IdmRightService.Create(model).subscribe(response => {
          if (response['Status'] == Status.SUCCESS) {
            this.NotificationService.ForCreate(true);
          }
          else {
            this.NotificationService.ForCreate(false);
          }
        });
      }
    }
  }

  getData(rightCode?: string) {
    this.model = new IdmRight();
    let filter = new IdmRightFilter();
    if (rightCode != undefined && rightCode && rightCode != '') {
      filter.RightCode = rightCode;
    }
    this.IdmRightService.GetFilter(filter).subscribe(response => {
      this.data = response;
      this.nodes = this.data['Data'];
      //console.log(response);
    });
  }

  ngOnInit() {
    this.getData();
  }

}
