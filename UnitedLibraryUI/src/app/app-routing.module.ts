import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NotFoundComponent } from './page-not-found/not-found.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'search', component: SearchComponent},
  { path: '**', component: NotFoundComponent}
];  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
