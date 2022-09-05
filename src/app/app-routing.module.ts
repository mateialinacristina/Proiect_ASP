import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "./auth.guard";
import { LoginComponent } from "./login/login/login.component";
import { MainComponent } from "./main/main.component";
import { MyRecipesComponent } from "./recipes/my-recipes/my-recipes.component";
import { RecipesDetailComponent } from "./recipes/recipes-list/recipes-detail/recipes-detail.component";
import { RecipesComponent } from "./recipes/recipes.component";
import { ShoppingListComponent } from "./shopping-list/shopping-list.component";
const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'recipes', component: RecipesComponent,
        loadChildren: () => import('src/app/recipes/recipes/recipes.module').then(m => m.RecipesModule)
      }
    ]
  },
  {
    path: 'login', component: LoginComponent,
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule)
  },
  // { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainComponent },
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
