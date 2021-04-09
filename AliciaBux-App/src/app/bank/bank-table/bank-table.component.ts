import { Component, Input, OnInit } from '@angular/core';
import { TableVirtualScrollDataSource } from 'ng-table-virtual-scroll';
import { Podcaster } from 'src/app/Classes/podcaster';

@Component({
  selector: 'app-bank-table',
  templateUrl: './bank-table.component.html',
  styleUrls: ['./bank-table.component.css']
})
export class BankTableComponent implements OnInit {

  constructor() { }

  @Input() podcasters: Array<Podcaster> = []

  columns: string[] = ["podcaster", "balance", "control"];

  public isAdmin: boolean = false;
  dataSource = new TableVirtualScrollDataSource([]);

  ngOnInit(): void {
    let testPod: Podcaster = 
    {
      name: "Anon",
      balance: 123
    }
    this.podcasters.push(testPod);
    this.dataSource = new TableVirtualScrollDataSource(this.podcasters);
  }
}
