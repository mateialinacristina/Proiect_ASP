import { Ingredient } from "../shared/ingredient.model";

export class Recipe {
    public id?: number;
    public name?: string;
    public description?: string;
    public imagePath?: string;
    public prepTime?: number;
    public cookTime?: number;
    public totalTime?: number;
    public servings?: number;
    public ingredients?: Ingredient[];
    public preparationDetails?: string;


    constructor(id: number, name: string, desc: string, imagePath: string, prepTime: number, cookTime: number, totalTime: number, servings: number, ingredients: Ingredient[], preparationDetails?: string) {
        this.id = id;
        this.name = name;
        this.description = desc;
        this.imagePath  = imagePath;
        this.prepTime = prepTime;
        this.cookTime = cookTime;
        this.totalTime = totalTime;
        this.servings = servings;
        this.ingredients = ingredients;
        this.preparationDetails = preparationDetails;
    }
}