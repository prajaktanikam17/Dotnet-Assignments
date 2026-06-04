import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CountryMobilePipe } from './country-mobile-pipe';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, CountryMobilePipe],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  mobile = '';
  country = 'India';

  getMaxLength(): number {

    switch (this.country) {

      case 'India':
        return 10;

      case 'USA':
        return 10;

      case 'UK':
        return 11;

      case 'Australia':
        return 9;

      default:
        return 10;
    }
  }
}