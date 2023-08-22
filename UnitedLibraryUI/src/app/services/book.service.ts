import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book';
import { Writer } from '../models/writer';
import { Library } from '../models/library';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) {}


  public  getBooksByLocationAndNovel(state: string, city: string, novel: string) : Observable<Book[]> {
    return this.http.get<Book[]>(`https://localhost:44361/api/Book/${state}/${city}/${novel}`);
  }

  public getWriters() : Observable<Writer[]> {
    return this.http.get<Writer[]>('https://localhost:44361/api/Writer');
  }

  public getWritersByBookId(bookId: number) : Observable<Writer[]> {
    return this.http.get<Writer[]>(`https://localhost:44361/api/Writer/${bookId}`);
  }

  public getLibrariesByLocationAndBookId(state: string, city: string, bookId: number) : Observable<Library[]> {
    return this.http.get<Library[]>(`https://localhost:44361/api/Library/${state}/${city}/${bookId}`);
  }
}