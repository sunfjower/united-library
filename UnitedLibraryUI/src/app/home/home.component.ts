import { Component } from "@angular/core";
import { Router, Routes } from "@angular/router";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { RouterModule } from '@angular/router';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';

@Component({
    standalone: true,
    imports: [FontAwesomeModule, RouterModule],
    selector: 'home-app',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent {

  searchIcon = faMagnifyingGlass;

    constructor(private router: Router) {
    }

  
    handleClick(value: string) {
      this.router.navigate(['/search', {searchText: value}]);
      console.log(value);
    }

}