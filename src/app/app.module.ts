import { RecipesService } from './services/recipes.service';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { RecipesComponent } from './recipes/recipes.component';
import { RecipesListComponent } from './recipes/recipes-list/recipes-list.component';
import { RecipesDetailComponent } from './recipes/recipes-list/recipes-detail/recipes-detail.component';
import { ShoppingListComponent } from './shopping-list/shopping-list.component';
import { ShoppingEditComponent } from './shopping-list/shopping-edit/shopping-edit.component';
import { LoginComponent } from './login/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon'
import { MyRecipesComponent } from './recipes/my-recipes/my-recipes.component';
import { EditRecipeComponent } from './recipes/my-recipes/edit-recipe/edit-recipe.component';
import { MainComponent } from './main/main.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogConfig, MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShoppingListService } from './services/shopping-list.service';
import { MatDividerModule } from '@angular/material/divider';
import { MarksPipe } from './marks.pipe';
import { ArrowPipe } from './arrow.pipe';


const MATERIAL_MODULES: any[] = [
  MatCardModule, MatButtonModule, MatIconModule, MatTooltipModule,
  MatDialogModule, MatDividerModule
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RecipesComponent,
    RecipesListComponent,
    RecipesDetailComponent,
    ShoppingListComponent,
    ShoppingEditComponent,
    LoginComponent,
    MyRecipesComponent,
    EditRecipeComponent,
    MainComponent,
    MarksPipe,
    ArrowPipe
  ],
  entryComponents: [
    RecipesDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MATERIAL_MODULES
  ],
  exports: [
    MATERIAL_MODULES
  ],
  providers: [
    RecipesService, 
    ShoppingListService
  ],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }