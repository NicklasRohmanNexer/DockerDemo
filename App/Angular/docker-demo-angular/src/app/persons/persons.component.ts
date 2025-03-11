import { Component, OnInit } from '@angular/core';
import { PersonsService } from './persons.service';
import { PersonDto } from './person.model';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css'],
})
export class PersonsComponent implements OnInit {
  persons: PersonDto[] = [];

  constructor(private readonly personsService: PersonsService) {}

  ngOnInit(): void {
    this.personsService.getAllPersons().subscribe({
      next: (data) => (this.persons = data),
      error: (error) => console.error('Error fetching persons:', error),
    });
  }
}
