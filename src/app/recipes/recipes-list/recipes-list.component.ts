import { RecipesService } from './../../services/recipes.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Recipe } from '../recipes.model';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})
export class RecipesListComponent implements OnInit {
  recipes: Recipe[] = [];

  constructor(private router: Router, private recipesService: RecipesService) { }

  ngOnInit(): void {
    this.recipes = this.recipesService.getMockRecipes();
  }

  saveRecipe(recipeId: number) { }

  likeRecipe(recipeId: number){ }

  viewRecipe(recipeId: number) {
    this.router.navigateByUrl('/recipe/' + recipeId );
  }
}