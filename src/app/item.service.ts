import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  getAllItemsUrl = 'assets/json/items.json';
  constructor(
    private httpClient: HttpClient
  ) { }
  getAllItems(){
    return this.httpClient.get(this.getAllItemsUrl);
  }
}
