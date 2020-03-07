import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item } from './item';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  getAllItemsUrl = 'assets/json/items.json';
  constructor(
    private httpClient: HttpClient
  ) { }
  getAllItems(): Observable<Array<Item>>{
    return this.httpClient.get<Array<Item>>(this.getAllItemsUrl);
  }
}
