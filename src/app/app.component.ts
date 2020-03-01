import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'ondotnet-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'ondotnetangularfrontend';
  constructor(private titleService:Title) {
    this.titleService.setTitle('on dotNET');
  }
}
