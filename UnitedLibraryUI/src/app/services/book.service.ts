import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { debounce, debounceTime, from } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book';
import { Writer } from '../models/writer';
import { Novel } from '../models/novel';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) {}


  public getBooks1() {
    return from(fetch('https://localhost:44361/api/Book/1/21/1'));
  }

  public  getBooks() : Observable<Book[]> {
    return this.http.get<Book[]>('https://localhost:44361/api/Book/1/21/1');
  }

  public getWriters() : Observable<Writer[]> {
    return this.http.get<Writer[]>('https://localhost:44361/api/Writer');
  }
  
  novels = new Novel();

  public getTestBooks() : Book[] {
    let book = new Book();
    book.id = 1;
    book.title = "1984";

    return [book];
  }
}