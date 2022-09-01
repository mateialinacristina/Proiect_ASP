import { Ingredient } from './../shared/ingredient.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class ShoppingListService {

    
    private _shoppingList;
    shoppingList$: Observable<Ingredient[]>;
    shoppingList: Ingredient[] = [];

    constructor(private HttpClient: HttpClient) {
        this.shoppingList = this.getShoppingList();
        this._shoppingList = new BehaviorSubject<Ingredient[]>(this.shoppingList);
        this.shoppingList$ = this._shoppingList.asObservable();
    }

    getShoppingList() {
        return this.shoppingList = [
            new Ingredient('Apples', 5),
            new Ingredient('Tomatoes', 10),
        ];
    }

    addToShoppingList(item: Ingredient) {
        this.shoppingList.push(item);
        this._shoppingList.next(this.shoppingList);
    }

}