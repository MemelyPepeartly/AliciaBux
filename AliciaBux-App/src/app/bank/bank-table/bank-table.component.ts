import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TableVirtualScrollDataSource } from 'ng-table-virtual-scroll';
import { Podcaster } from 'src/app/Classes/podcaster';
import { AliciaService } from 'src/app/services/alicia.service';

@Component({
  selector: 'app-bank-table',
  templateUrl: './bank-table.component.html',
  styleUrls: ['./bank-table.component.css']
})
export class BankTableComponent implements OnInit {

  constructor(private aliciaService: AliciaService, private changeDetectorRefs: ChangeDetectorRef) { }

  @Input() podcasters: Array<Podcaster>;
  @Output() updatedBux: EventEmitter<Podcaster> = new EventEmitter()

  columns: string[] = ["podcaster", "balance", "control"];

  public isAdmin: boolean = false;
  public disableControl: boolean = false;

  ngOnInit(): void {
  }
  public giveBux(anon: Podcaster)
  {
    this.disableControl = true;
    this.aliciaService.putGiveBuxByID(anon.podcasterID).subscribe(res => {
      this.podcasters[this.podcasters.findIndex(p => p.podcasterID == anon.podcasterID)] = res;
      this.changeDetectorRefs.detectChanges();
      this.updatedBux.emit(null);
      this.disableControl = false;
    })
  }
  public takeBux(anon: Podcaster)
  {
    this.disableControl = true;
    this.aliciaService.putTakeBuxByID(anon.podcasterID).subscribe(res => {
      this.podcasters[this.podcasters.findIndex(p => p.podcasterID == anon.podcasterID)] = res;
      this.updatedBux.emit(null);
      this.changeDetectorRefs.detectChanges();
      this.disableControl = false;
    })
  }
  public removePodcaster(anon: Podcaster)
  {
    this.disableControl = true;
    this.aliciaService.deletePodcaster(anon.podcasterID).subscribe(res => {
      this.podcasters.splice(this.podcasters.findIndex(p => p.podcasterID == anon.podcasterID));
      this.changeDetectorRefs.detectChanges();
      this.updatedBux.emit(null);
      this.disableControl = false;
    })
  }
}
