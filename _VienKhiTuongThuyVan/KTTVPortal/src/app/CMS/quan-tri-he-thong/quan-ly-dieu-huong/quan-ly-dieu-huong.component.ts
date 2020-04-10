import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-quan-ly-dieu-huong',
  templateUrl: './quan-ly-dieu-huong.component.html',
  styleUrls: ['./quan-ly-dieu-huong.component.css']
})
export class QuanLyDieuHuongComponent implements OnInit {

  constructor() { }

  public pageTitle = 'Quản lý điều hướng';
  public warning = {
    title: "Cảnh báo",
    content: `Panel này chỉ dành cho các kỹ thuật viên nắm bắt về hệ thống. 
    Cấu hình trong panel này khi được thay đổi sẽ có khả năng không thể phục hồi và ảnh hưởng đển sự hoạt động của hệ thống.`
  }

  public tree_menu: Array<any> = [];
  
  
  
  ngOnInit() {
  }

}
