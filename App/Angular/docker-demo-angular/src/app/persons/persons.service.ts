import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PersonDto } from './person.model';

@Injectable({
  providedIn: 'root',
})
export class PersonsService {
  private readonly apiUrl = 'http://localhost:23223/Person/getAllPersons';

  constructor(private readonly http: HttpClient) {}

  getAllPersons(): Observable<PersonDto[]> {
    return this.http.get<PersonDto[]>(this.apiUrl);
  }
}
