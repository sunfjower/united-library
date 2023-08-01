import { Novel } from "./novel";
import { HttpClient } from "@angular/common/http";

export class Book {
    constructor (private http: HttpClient){
        
    }
    title: string = '';
}