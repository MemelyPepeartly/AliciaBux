import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NewPodcasterModel } from '../Classes/ApiModels/new-podcaster-model';
import { Podcaster } from '../Classes/podcaster';
import { AliciaService } from '../services/alicia.service';

@Component({
  selector: 'app-bank',
  templateUrl: './bank.component.html',
  styleUrls: ['./bank.component.css']
})
export class BankComponent implements OnInit {

  constructor(private aliciaService: AliciaService, private changeDetectorRefs: ChangeDetectorRef,
    private formBuilder: FormBuilder) { }

  public podcasterFormGroup: FormGroup;

  public podcasters: Array<Podcaster> = []

  public showBankTable: boolean = false;
  public postingNewPodcaster: boolean = false;

  get podcasterFormControls()
  {
    return this.podcasterFormGroup.controls;
  }

  ngOnInit(): void {
    this.formSetup();
    this.aliciaService.getAllPodcasters().subscribe(podcasters => {
      this.podcasters = podcasters;
      this.showBankTable = true;
    });
  }
  public formSetup()
  {
    this.podcasterFormGroup = this.formBuilder.group({
      podcasterName: ['', [Validators.required, Validators.maxLength(50)]]
    });
  }
  public async postNewPodcaster()
  {
    this.postingNewPodcaster = true;
    
    let newCaster: NewPodcasterModel = 
    {
      podcasterName: this.podcasterFormControls.podcasterName ? this.podcasterFormControls.podcasterName.value : "Error"
    };
    await this.aliciaService.postNewPodcaster(newCaster).toPromise();
    this.refreshPodcasters();
    this.postingNewPodcaster = false;
  }
  public async refreshPodcasters()
  {
    this.aliciaService.getAllPodcasters().subscribe(res => {
      this.podcasters = res
      this.showBankTable = true;
    });
  }
}
