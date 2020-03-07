import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { interval, of, throwError } from 'rxjs';
import { mergeMap, retry } from 'rxjs/operators';

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
    private titleService: Title) {
    this.titleService.setTitle('on dotNET');
  }
  ngOnInit() {
    const source = interval(1000);
    const example = source.pipe(
      mergeMap(val => {
        if (val > 12) {
          return throwError('Error!');
        }
        return of(val);
      }),
      retry(9)
    );
    const subscribe = example.subscribe({
      next: val => console.log(val),
      error: val => console.log(`${val}: Retried 2 times then quit!`)
    });
    this.itemService.getAllItems().subscribe(
      (allItems: Array<Item>) => {
        console.log(allItems[0]);
      });
  }
}
