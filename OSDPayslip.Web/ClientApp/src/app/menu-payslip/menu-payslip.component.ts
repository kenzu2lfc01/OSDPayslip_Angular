import { Component, OnInit,ViewChild } from '@angular/core';
import { IgxNavigationDrawerComponent } from "igniteui-angular";

@Component({
  selector: 'app-menu-payslip',
  templateUrl: './menu-payslip.component.html',
  styleUrls: ['./menu-payslip.component.css']
})
export class MenuPayslipComponent implements OnInit {
  public navItems = [
    { name: "home", text: "Home",pages:"homes" },
    { name: "view_carousel", text: "Request",pages:"requests" },
  ];
  public selected = "Home";
  @ViewChild(IgxNavigationDrawerComponent, { static: true })
  public drawer: IgxNavigationDrawerComponent;

  public drawerState = {
    miniTemplate: false,
    open: true,
    pin: true
  };

  public navigate(item) {
    this.selected = item.text;
    if (!this.drawer.pin) {
      this.drawer.close();
    }
  }
  ngOnInit() {
  }

}
