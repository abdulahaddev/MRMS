import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from 'src/app/models/Product/Product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent {

    @Input() productData : Product = new Product();
    @Output() productDataChange = new EventEmitter<Product>();

  updateProductData() {
    this.productDataChange.emit(this.productData);
  }

}
