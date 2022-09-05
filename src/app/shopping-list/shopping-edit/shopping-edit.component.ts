import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit {

  ingredientsForm = new FormGroup({
    ingredientName: new FormControl('', [Validators.required]),
    ingredientAmount: new FormControl('', Validators.required),
  });

  constructor() { }

  ngOnInit(): void {
  }

}
