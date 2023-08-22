import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CdkStepper} from '@angular/cdk/stepper';

@Component({
    imports: [CommonModule],
    standalone: true,
    selector: "app-search-stepper",
    templateUrl: "./search-stepper.component.html",
    providers: [{ provide: CdkStepper, useExisting: SearchStepperComponent }]
  })
  export class SearchStepperComponent extends CdkStepper implements OnInit {
    
    ngOnInit(){
        this.steps
    }
  }