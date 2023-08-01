import { style } from "@angular/animations";
import { Component } from "@angular/core";

interface Novel
{
  name: string
  isFamous: boolean
}

@Component({
    selector: 'home-app',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent {
    title = 'UnitedLibraryUI';

    novels : Novel[] = [{
      name: "Fisrt novel",
      isFamous: false
    }, {
      name: "Second novel",
      isFamous: true
      }]
  
  
    constructor() {
    }
  
    handleClick(value: any) {
      console.log(value);
    }

}