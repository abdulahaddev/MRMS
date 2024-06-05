import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { Company } from '../../../models/common/company';
import { Country } from '../../../models/common/country';
import { Demand } from '../../../models/demandSection/demand';
import { CompanyService } from '../../../services/common/company.service';
import { CountryService } from '../../../services/common/country.service';
import { DemandService } from '../../../services/demandSection/demand.service';
import { NotificationService } from '../../../services/Shared/notification.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-company-view',
  templateUrl: './company-view.component.html',
  styleUrls: ['./company-view.component.css']
})
export class CompanyViewComponent {
  country: Country[] = [];
  company: Company[] = [];
  dataSource: MatTableDataSource<Company> = new MatTableDataSource(this.company);

  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;

  columnList: string[] = ["name", "details", "address", "email", "phone", "countryId", "actions"];

  constructor(
    private countrySvc: CountryService,
    private companySvc: CompanyService,
    private notificationSvc: NotificationService,
    private dialog: MatDialog
  ) { }

  confirmDelete(data: Company) {
   //console.log(data);
   this.dialog.open(ConfirmDialogComponent, {
     width: '450px',
     enterAnimationDuration: '800ms'
   }).afterClosed()
     .subscribe(result => {
       //console.log(result);
       if (result) {
         this.companySvc.delete(data)
           .subscribe({
             next: r => {
               this.notificationSvc.message('Demand removed', 'DISMISS');
               this.dataSource.data = this.dataSource.data.filter(c => c.companyId != data.companyId);
             },
             error: err => {
               this.notificationSvc.message('Failed to delete data', 'DISMISS');
               throwError(() => err);
             }
           })
       }
     })
  }

  getCountryName(id: number) {
    let c = this.country.find(c => c.countryId == id);
    return c ? c.name : '';
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit(): void {
    this.countrySvc.get()
     .subscribe(x => {
       //console.log(x);
       this.country = x;
     }, err => {
       this.notificationSvc.message("Failed to load country data!!!", "DISMISS");
     });

    this.companySvc.get()
      .subscribe(x => {
        this.company = x;
        //console.log(this.company);
        this.dataSource.data = this.company;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, err => {
        this.notificationSvc.message("Failed to load company data!!!", "DISMISS");
      });

  }
}
