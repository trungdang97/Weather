import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-quan-ly-nguoi-dung',
  templateUrl: './quan-ly-nguoi-dung.component.html',
  styleUrls: ['./quan-ly-nguoi-dung.component.css']
})
export class QuanLyNguoiDungComponent implements OnInit {

  constructor() { }
  public searchText = "";
  public headers = [
    {
      Name: "Tên tài khoản",
      Class: "text-center",
      IsVisible: true
    },
    {
      Name: "Trạng thái",
      Class: "text-center",
      IsVisible: false
    },
    {
      Name: "Tên người dùng",
      Class: "text-center",
      IsVisible: true
    },
    {
      Name: "Email",
      Class: "text-center",
      IsVisible: true
    },
    {
      Name: "Thao tác",
      Class: "text-center",
      IsVisible: true
    },
  ];
  public button = {
    Refresh: {
      Click: () => {
        this.searchText = "";
      }
    },
    Add: {
      Click: () => {

      }
    }
  };

  getData() {

  }

  ngOnInit() {
  }

}
