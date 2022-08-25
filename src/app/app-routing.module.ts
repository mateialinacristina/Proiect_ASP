import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login/login.component";
import { RecipesComponent } from "./recipes/recipes.component";
import { ShoppingListComponent } from "./shopping-list/shopping-list.component";
const routes: Routes = [
    { path: 'login', component: LoginComponent },
    {
      path: '', component: RecipesComponent,
      children: [
        { path: 'shopping-list', component: ShoppingListComponent },
       
      ],
    },
  ];
  
  
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { useHash: false })
      ],
      exports: [
        RouterModule
      ],
})

export class AppRoutingModule { }