import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BankComponent } from './bank/bank.component';


const appRoutes: Routes = [
  {
    path: 'bank',
    component: BankComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes, { scrollPositionRestoration: 'disabled' })],
  exports: [RouterModule],
  providers: [
  ]
})
export class AppRoutingModule { }
