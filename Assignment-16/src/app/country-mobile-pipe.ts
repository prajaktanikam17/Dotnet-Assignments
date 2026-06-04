import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'countryMobile',
  standalone: true
})
export class CountryMobilePipe implements PipeTransform {

  transform(mobile: string, country: string): string {

    if (!mobile) {
      return '';
    }

    switch (country) {
      case 'India':
        return '+91 ' + mobile;

      case 'USA':
        return '+1 ' + mobile;

      case 'UK':
        return '+44 ' + mobile;

      case 'Australia':
        return '+61 ' + mobile;

      default:
        return mobile;
    }
  }
}