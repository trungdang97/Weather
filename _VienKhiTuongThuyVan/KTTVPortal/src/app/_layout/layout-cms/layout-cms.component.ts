import { Component, OnInit, OnDestroy, Inject, Renderer2, ViewChild } from '@angular/core';
import { DOCUMENT } from '@angular/common';
@Component({
  selector: 'app-layout-cms',
  templateUrl: './layout-cms.component.html',
  styleUrls: ['./layout-cms.component.css']
})
export class LayoutCmsComponent implements OnInit, OnDestroy {
  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2,
  ) { }

  ngOnInit() {
    this.renderer.addClass(this.document.body, 'sidebar-mini');
  }

  ngOnDestroy() {
    this.renderer.removeClass(this.document.body, 'sidebar-mini');
  }
}
