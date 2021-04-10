import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TableVirtualScrollDataSource } from 'ng-table-virtual-scroll';
import { Podcaster } from 'src/app/Classes/podcaster';
import { AliciaService } from 'src/app/services/alicia.service';

@Component({
  selector: 'app-bank-table',
  templateUrl: './bank-table.component.html',
  styleUrls: ['./bank-table.component.css']
})
export class BankTableComponent implements OnInit {

  constructor(private aliciaService: AliciaService) { }

  @Input() podcasters: Array<Podcaster>;
  @Output() updatedBux: EventEmitter<Podcaster> = new EventEmitter()

  columns: string[] = ["podcaster", "balance", "control"];

  public isAdmin: boolean = false;
  public disableControl: boolean = false;

  dataSource = new TableVirtualScrollDataSource([]);

  ngOnInit(): void {
    this.dataSource = new TableVirtualScrollDataSource(this.podcasters);
  }
  public giveBux(anon: Podcaster)
  {
    this.disableControl = true;
    this.aliciaService.putGiveBuxByID(anon.podcasterID).subscribe(res => {
      this.updatedBux.emit(res);
    });
  }
  public takeBux(anon: Podcaster)
  {
    this.disableControl = true;
    this.aliciaService.putTakeBuxByID(anon.podcasterID).subscribe(res => {
      this.updatedBux.emit(res);
    });
  }
}
