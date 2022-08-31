import { Recipe } from './../../recipes.model';
import { RecipesService } from './../../../services/recipes.service';
import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-recipes-detail',
  templateUrl: './recipes-detail.component.html',
  styleUrls: ['./recipes-detail.component.css']
})
export class RecipesDetailComponent implements OnInit {
  
  recipe: Recipe;
  recipeId: number;

  constructor(private recipesService: RecipesService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.forEach((params: Params) => {
      this.recipeId = params['id'];
      this.recipe = this.recipesService.getRecipeDetails(this.recipeId);
    });
  }

  close() {
  }

}