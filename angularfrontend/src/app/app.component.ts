import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ItemService } from './item.service';
import { Item } from './item';

@Component({
  selector: 'ondotnet-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit {
  title = 'ondotnetangularfrontend';
  constructor(
    private itemService: ItemService,
    private titleService:Title) {
    this.titleService.setTitle('on dotNET');
  }
  ngOnInit() {
    this.itemService.getAllItems().subscribe(
      (allItems: Array<Item>) => {
        console.log(allItems[0]);
      });
  }
}
