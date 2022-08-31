import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login/login.component";
import { MainComponent } from "./main/main.component";
import { MyRecipesComponent } from "./recipes/my-recipes/my-recipes.component";
import { RecipesDetailComponent } from "./recipes/recipes-list/recipes-detail/recipes-detail.component";
import { RecipesComponent } from "./recipes/recipes.component";
import { ShoppingListComponent } from "./shopping-list/shopping-list.component";
const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: '', redirectTo: '/main', pathMatch: 'full' },
    { path: 'main', component: MainComponent},
    { path: 'recipes', component: RecipesComponent },
    { path: 'recipe/:id', component: RecipesDetailComponent },
    { path: 'my-recipes', component: MyRecipesComponent },
    { path: 'shopping-list', component: ShoppingListComponent }
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