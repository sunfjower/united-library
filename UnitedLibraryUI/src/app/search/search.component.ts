import { Component, ViewChild } from "@angular/core";
import { Book } from "../models/book";
import { Writer } from "../models/writer";
import { Library } from "../models/library";
import { BookService } from "../services/book.service";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from "@angular/router";
import { CdkStep, CdkStepper } from '@angular/cdk/stepper';
import { SearchStepperComponent } from "../search-stepper/search-stepper.component";
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CdkStepperModule } from '@angular/cdk/stepper';

@Component({
    imports: [ CommonModule, 
        ReactiveFormsModule, 
        SearchStepperComponent,
        CdkStepperModule
    ],
    standalone: true,
    selector: 'search-app',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css']
})

export class SearchComponent {

    books: Book[] = [];
    writers: Writer[] = [];
    libraries: Library[] = [];
    bookDetails!: Book;
    //searchText!: string;
    

    constructor(
        private bookService: BookService, 
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        let searchText = this.route.snapshot.paramMap.get('searchText')
        if(searchText != null) {
            this.bookList.controls.search.setValue(searchText);
        }
    }

    userLocation = new FormGroup({
        state: new FormControl('', Validators.required),
        city: new FormControl('', Validators.required)
    });

    bookList = new FormGroup({
        search: new FormControl('')
    });
    
    @ViewChild('stepper') stepper!: CdkStepper;
    @ViewChild('step1') step1!: CdkStep;
    @ViewChild('step2') step2!: CdkStep;
    @ViewChild('step3') step3!: CdkStep;
    @ViewChild('step4') step4!: CdkStep;
    @ViewChild('step5') step5!: CdkStep;

    loadBooks(): void {
        let novel = this.bookList.value.search;
        let state = this.userLocation.value.state!;
        let city = this.userLocation.value.city!;

        if(novel != undefined && novel != "") {
            this.bookService
                .getBooksByLocationAndNovel(state, city, novel)
                .subscribe(books => this.books = books);
        }
    }

    showDetails(book: Book) {
        this.bookDetails = book;
        this.bookService
            .getWritersByBookId(book.id)
            .subscribe(writers => this.writers = writers);
    }

    showLibraries() {
        let state = this.userLocation.value.state!;
        let city = this.userLocation.value.city!;
        this.bookService
            .getLibrariesByLocationAndBookId(state, city, this.bookDetails.id)
            .subscribe(libraries => this.libraries = libraries);
    }

 }