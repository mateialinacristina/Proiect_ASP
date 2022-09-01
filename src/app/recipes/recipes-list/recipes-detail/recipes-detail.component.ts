import { ShoppingListService } from './../../../services/shopping-list.service';
import { Recipe } from './../../recipes.model';
import { RecipesService } from './../../../services/recipes.service';
import { Component, Inject, OnDestroy, OnInit, Optional } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-recipes-detail',
  templateUrl: './recipes-detail.component.html',
  styleUrls: ['./recipes-detail.component.css']
})
export class RecipesDetailComponent implements OnInit, OnDestroy {
  
  recipe: Recipe;
  recipeId: number;
  private subscriptions = new Subscription();

  constructor(private recipesService: RecipesService, private activatedRoute: ActivatedRoute, private shoppinglistService: ShoppingListService) { }

  ngOnInit(): void {
    this.activatedRoute.params.forEach((params: Params) => {
      this.recipeId = params['id'];
      this.recipe = this.recipesService.getRecipeDetails(this.recipeId);
    });

    this.subscriptions.add(
      this.recipesService.getAllRecipes().subscribe(
        data => {
          // this.recipe = data;
        }
      )
    )
  }
  ngOnDestroy(): void {
    if (this.subscriptions){
      this.subscriptions.unsubscribe();
    }
  }

  addToShoppingList(ingredient) {
    this.shoppinglistService.addToShoppingList(ingredient);
  }

}