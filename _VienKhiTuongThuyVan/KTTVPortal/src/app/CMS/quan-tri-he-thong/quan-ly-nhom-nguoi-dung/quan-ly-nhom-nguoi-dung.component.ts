import { Component, OnInit } from '@angular/core';
import { IdmRightService } from '../../services/idm-right/idm-right.service';
import { NotificationService } from 'src/app/_layout/services/notification.service';
import { UserRoleService } from '../../services/roles/user-role.service';
import { UserRoleFilter, UserRole, UserRoleCreateRequestModel, UserRoleUpdateRequestModel } from '../../services/roles/user-role.model';
import { ITreeOptions, ITreeState } from 'angular-tree-component';
import { IdmRight, IdmRightFilter } from '../../services/idm-right/idm-right.model';
import { DemoUserId } from 'src/app/app.config';

@Component({
  selector: 'app-quan-ly-nhom-nguoi-dung',
  templateUrl: './quan-ly-nhom-nguoi-dung.component.html',
  styleUrls: ['./quan-ly-nhom-nguoi-dung.component.css']
})
export class QuanLyNhomNguoiDungComponent implements OnInit {

  constructor(
    private IdmRightService: IdmRightService,
    private NotificationService: NotificationService,
    private UserRoleService: UserRoleService
  ) { }
  public isUpdate = false;
  public right_searchText = "";
  public role_searchText = "";
  public rights: Array<IdmRight> = [];
  public roles: Array<UserRole> = [];
  public data = {};
  public model = new UserRole();
  public rightTreeState: ITreeState;
  public roleTreeOptions: ITreeOptions = {
    idField: 'RoleId',
    displayField: 'RoleName',
    //childrenField: '',
    actionMapping: {},
  };
  public rightTreeOptions: ITreeOptions = {
    idField: 'RightId',
    displayField: 'RightName',
    childrenField: 'InverseGroupIdNavigation',
    actionMapping: {},
    useCheckbox: true,

  };
  private _rightTree;
  initRightTree(tree) {
    this._rightTree = tree;
  }
  rightTreeSelectionChange(form) {
    form.control.markAsTouched();
    form.control.markAsDirty();
  }

  public button = {
    Add: {
      Click: () => {
        this.isUpdate = false;
        this.model = new UserRole();
      }
    },
    Refresh: {
      Click: () => {
        this.model = new UserRole();
        this.isUpdate = false;
        this.getRole();
        this.getRight();
      }
    }
  };

  Submit(form) {
    if (!this.isUpdate) {
      let model = new UserRoleCreateRequestModel();
      model = this.model;
      model.CreatedByUserId = DemoUserId;
      model.RightList = [];
      for (let [id, isSelected] of Object.entries(this.rightTreeState.selectedLeafNodeIds)) {
        if (isSelected) {
          model.RightList.push(id);
        }
      }
      this.UserRoleService.Create(model).subscribe(response => {
        if (response['Status'] == 1) {
          this.NotificationService.ForCreate(true);
        }
        else {
          this.NotificationService.ForCreate(false);
        }
      });
    }
    else {
      let model = new UserRoleUpdateRequestModel();
      model = this.model;
      model.LastModifiedByUserId = DemoUserId;
      model.RightList = [];
      for (let [id, isSelected] of Object.entries(this.rightTreeState.selectedLeafNodeIds)) {
        if (isSelected) {
          model.RightList.push(id);
        }
      }
      this.UserRoleService.Update(model).subscribe(response => {
        if (response['Status'] == 1) {
          this.NotificationService.ForUpdate(true);
          form.control.markAsUntouched();
          form.control.markAsPristine();
        }
        else {
          this.NotificationService.ForUpdate(false);
        }
      });
    }
  }

  getRole(roleId?: string) {
    this.model = new UserRole();
    var filter = new UserRoleFilter();
    if (roleId != undefined) {
      filter.RoleId = roleId;
      this.UserRoleService.GetFilter(filter).subscribe(response => {
        this.model = response['Data'][0];
        this.isUpdate = true;
        let selectedLeafNodeIds = {};
        this.model.IdmRightsInRole.forEach(element => {
          selectedLeafNodeIds[element.RightId] = true;
        });
        this.rightTreeState = {
          ...this.rightTreeState,
          selectedLeafNodeIds
        }
      });
      this._rightTree.treeModel.collapseAll();
    }
    else {
      this.UserRoleService.GetFilter(filter).subscribe(response => {
        this.data = response;
        this.roles = response['Data']
      });
    }
  }

  getRight() {
    var filter = new IdmRightFilter();
    this.IdmRightService.GetFilter(filter).subscribe(response => {
      this.rights = response['Data'];
    });
  }

  ngOnInit() {
    this.getRight();
    this.getRole();
  }

}
