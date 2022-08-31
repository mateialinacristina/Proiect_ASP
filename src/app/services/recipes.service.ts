import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TitleStrategy } from "@angular/router";
import { Recipe } from "../recipes/recipes.model";

@Injectable()
export class RecipesService {
    private apiUrl = "";
    recipes: Recipe[] = [
        new Recipe(1, 'A Test Recipe', 'This is simply a test', 'https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chorizo-mozarella-gnocchi-bake-cropped-9ab73a3.jpg' ),
        new Recipe(2, 'Shakshuka Recipe', 'The best idea for a consistent breakfast', 'https://i2.wp.com/www.downshiftology.com/wp-content/uploads/2018/12/Shakshuka-19.jpg' ),
        new Recipe(3, 'Zuchinni Tomato Bake Recipe', 'Easy, healthy, and delicious!', 'https://hips.hearstapps.com/del.h-cdn.co/assets/16/21/1464124561-shot-1-033.jpg'),
        new Recipe(4, 'Cucumber Peach Salad', 'Combine your cucumbers with the sweetnes of peaches and get those vitamins in', 'https://assets.bonappetit.com/photos/5d236b1f31740d000880adf7/5:4/w_1405,h_1124,c_limit/Aug-Cucumber-Peach-Salad-with-Herbs.jpg')
      ];
      
    constructor(private httpClient: HttpClient) {}


    getAllRecipes() {
        return this.httpClient.get(this.apiUrl);
    }

    getMockRecipes() {
        return this.recipes;
    }

    getRecipeDetails(recipeId: number) {
        return this.recipes.find(r => r.id == recipeId);
    }
    
}