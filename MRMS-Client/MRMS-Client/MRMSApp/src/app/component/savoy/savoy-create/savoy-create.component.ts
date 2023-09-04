import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/Product/Product';
import { Company } from 'src/app/models/common/company';
import { Companies } from 'src/app/models/company/companies';
import { ProductService } from 'src/app/services/Product/product.service';
import { NotificationService } from 'src/app/services/Shared/notification.service';

@Component({
  selector: 'app-savoy-create',
  templateUrl: './savoy-create.component.html',
  styleUrls: ['./savoy-create.component.css']
})
export class SavoyCreateComponent implements OnInit {
  company: Company = new Company();
  companyForm: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    details: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    phone: new FormControl('', null),
    countryId: new FormControl('', Validators.required)
  });

  savoyData : Product[] = [];

  // f() {
  //   return this.companyForm.controls;
  // }
  constructor(
    private notificationSvc: NotificationService,
    private productService : ProductService,
    private router: Router
  ) { }
  insert(): void {
    // if (this.companyForm.invalid) return;
    // console.log(this.companyForm.value);

    // Object.assign(this.company, this.companyForm.value);
    // console.log(this.company);

    // this.companySvc.insert(this.company)
    //   .subscribe(r => {
    //     this.notificationSvc.message("Data saved successfully!!!", "DISMISS");
    //     this.router.navigate(['/company']);
    //     this.companyForm.reset({});
    //     console.log(r);
    //   }, err => {
    //     this.notificationSvc.message("Failed to save data!!!", "DISMISS");
    //   })
  }
  ngOnInit(): void {
    this.productService.getProductsWithEja(Companies.Savoy)
      .subscribe(r => {
        this.savoyData = r;
      }, err => {
        this.notificationSvc.message("Failed to load Company", "DISMISS");
      })
  }

    updateProduct(updatedProduct: Product, index: number) {
    // Assuming that you want to update the specific product in the array
    this.savoyData[index] = updatedProduct;
  }

    trackByProduct(index: number, product: Product): any {
      return product.productId;
    }

}