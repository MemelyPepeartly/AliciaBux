import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map, catchError, tap } from 'rxjs/operators';
import { Podcaster } from '../Classes/podcaster';
import { NewPodcasterModel } from '../Classes/ApiModels/new-podcaster-model';

const endpoint = environment.apiURL;

@Injectable({
  providedIn: 'root'
})
export class AliciaService {

  constructor(private http: HttpClient) { }
  private extractData(res: Response) {
    const body = res;
    return body || { };
  }
  getAllPodcasters(): Observable<any> {
    return this.http.get<Array<Podcaster>>(endpoint + 'Alicia');
  }
  getPodcasterByID(podcasterID: string): Observable<any> {
    return this.http.get<Podcaster>(endpoint + 'Alicia/' + podcasterID);
  }
  postNewPodcaster(requestBody: NewPodcasterModel): Observable<any> {
    return this.http.post<Podcaster>(endpoint + 'Alicia', requestBody)
  }
  putGiveBuxByID(podcasterID: string): Observable<any> {
    return this.http.put<Podcaster>(endpoint + 'Alicia/' + podcasterID + "/GiveBux", null);
  }
  putTakeBuxByID(podcasterID: string): Observable<any> {
    return this.http.put<Podcaster>(endpoint + 'Alicia/' + podcasterID + "/TakeBux", null);
  }
}
