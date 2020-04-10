import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import * as moment from 'moment';

@Component({
  selector: 'app-layout-main',
  templateUrl: './layout-main.component.html',
  styleUrls: ['./layout-main.component.css']
})
export class LayoutMainComponent implements OnInit {

  public logoHeight: string = "50px";
  public clock: string = "";
  public categories = ['Thủy văn','Hải văn','Thủy văn đặc biệt','Phổ biến kiến thức','Hỏi đáp về KTTV','Nghiên cứu KH'];
  public constructor(private titleService: Title) { }

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  public AddClock() {
    let weekdays = ['Chủ Nhật', 'Thứ Hai', 'Thứ Ba', 'Thứ Tư', 'Thứ Năm', 'Thứ Sáu', 'Thứ Bảy'];
    let day = weekdays[moment().day()];
    let date = moment().format("DD/MM/YYYY, HH:mm");
    let offset = moment().utcOffset() / 60;
    return day + ' ' + date + ' (GMT+' + offset + ')';
  }

  ngOnInit() {
    setInterval(this.AddClock, 500);
  }

}
