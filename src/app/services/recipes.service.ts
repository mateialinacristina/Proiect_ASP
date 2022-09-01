import { Ingredient } from './../shared/ingredient.model';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TitleStrategy } from "@angular/router";
import { Recipe } from "../recipes/recipes.model";

@Injectable()
export class RecipesService {
    private apiUrl = "https://localhost:5001/api";
    ingredientList: Ingredient[] = [];
    recipes: Recipe[] = [
        new Recipe(1, 'A Test Recipe', 'This is simply a test', 'https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chorizo-mozarella-gnocchi-bake-cropped-9ab73a3.jpg', 20, 30, 50, 6, 
        [
            new Ingredient('Greek yogurt', 4, 'cups'),
            new Ingredient('mayonnaise', 4, 'cups'),
            new Ingredient('crumbled blue cheese', 4, 'cups'),
            new Ingredient('ground black pepper', null, 'pinch'),
            new Ingredient('hot sauce', null, 'dash'),

        ], 'In a medium bowl toss florets with salt, chili powder, and garlic powder. In a separate small bowl, add eggs and water and whisk together. Add the egg mixture to the bowl with the cauliflower and toss to coat. Once the cauliflower is coated with the egg mixture, toss with breadcrumbs and coat well.'),
        new Recipe(2, 'Shakshuka Recipe', 'The best idea for a consistent breakfast', 'https://i2.wp.com/www.downshiftology.com/wp-content/uploads/2018/12/Shakshuka-19.jpg', 10, 30, 40, 6,
        [
            new Ingredient('Greek yogurt', 4, 'cups'),
            new Ingredient('mayonnaise', 4, 'cups'),
            new Ingredient('crumbled blue cheese', 4, 'cups'),
            new Ingredient('ground black pepper', null, 'pinch'),
            new Ingredient('hot sauce', null, 'dash'),

        ]),
        new Recipe(3, 'Zuchinni Tomato Bake Recipe', 'Easy, healthy, and delicious!', 'https://hips.hearstapps.com/del.h-cdn.co/assets/16/21/1464124561-shot-1-033.jpg', 20, 30, 50, 5,
        [
            new Ingredient('Greek yogurt', 4, 'cups'),
            new Ingredient('mayonnaise', 4, 'cups'),
            new Ingredient('crumbled blue cheese', 4, 'cups'),
            new Ingredient('ground black pepper', null, 'pinch'),
            new Ingredient('hot sauce', null, 'dash'),

        ]),
        new Recipe(4, 'Cucumber Peach Salad', 'Combine your cucumbers with the sweetnes of peaches and get those vitamins in', 'https://assets.bonappetit.com/photos/5d236b1f31740d000880adf7/5:4/w_1405,h_1124,c_limit/Aug-Cucumber-Peach-Salad-with-Herbs.jpg', 15, 45, 60, 6,
        [
            new Ingredient('Greek yogurt', 4, 'cups'),
            new Ingredient('mayonnaise', 4, 'cups'),
            new Ingredient('crumbled blue cheese', 4, 'cups'),
            new Ingredient('ground black pepper', null, 'pinch'),
            new Ingredient('hot sauce', null, 'dash'),

        ])
      ];
      
    constructor(private httpClient: HttpClient) {}


    // getAllRecipes() {
    //     return this.httpClient.get(this.apiUrl);
    // }

    getMockRecipes() {
        return this.recipes;
    }

    getRecipeDetails(recipeId: number) {
        return this.recipes.find(r => r.id == recipeId);
    }

    getAllRecipes() {
        return this.httpClient.get<Recipe[]>(this.apiUrl + '/Details');
    }

    createRecipe(recipe: Recipe) {
        return this.httpClient.post<Recipe>(this.apiUrl + '/Details/create-a-detail', recipe);
    }

    updateRecipe(recipe: Recipe) {
        return this.httpClient.put<Recipe>(this.apiUrl + '/Details/update-a-detail', recipe);
    }

    deleteRecipe(recipeId: number) {
        return this.httpClient.delete<Recipe>(this.apiUrl + '/Details/delete-by-recipe-id/' + recipeId);
    }
    
}