import { style } from "@angular/animations";
import { Component } from "@angular/core";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';

@Component({
    standalone: true,
    imports: [FontAwesomeModule],
    selector: 'home-app',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent {

  searchIcon = faMagnifyingGlass;

    constructor() {
    }

  
    handleClick(value: any) {
      console.log(value);
    }

}