import { Component, OnInit, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-trang-chu',
  templateUrl: './trang-chu.component.html',
  styleUrls: ['./trang-chu.component.css']
})
export class TrangChuComponent implements OnInit, OnDestroy {

  public constructor(private titleService: Title) { }
  public height = '600px';
  public disasters = [];
  public disasters_exist = false;
  public weather = [];
  public frontNewsCategories = ["Tin nội bộ", "Tin thời tiết", "Tin xã hội", "Tin video"];
  public activeIndex = 0;

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }
  private addTawkToScript() {
    let node = document.createElement('script');
    node.id = "tawk.to"
    node.src = "assets/external_scripts/tawk.to.js";
    node.type = 'text/javascript';
    node.async = true;
    node.charset = 'utf-8';
    document.getElementsByTagName('head')[0].appendChild(node);
  }
  private removeTawkToScript() {
    document.getElementById("tawk.to").remove();
  }

  ngOnInit() {
    this.setTitle("Trang chủ");

    //get disasters

    //get weather

    //get front news' categories
    this.activeIndex = 1;
    this.addTawkToScript();
  }

  ngOnDestroy() {
    this.removeTawkToScript();
  }
}
