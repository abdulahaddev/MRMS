import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';
import { Company } from '../../../models/common/company';
import { Demand } from '../../../models/demandSection/demand';
import { CompanyService } from '../../../services/common/company.service';
import { DemandService } from '../../../services/demandSection/demand.service';
import { NotificationService } from '../../../services/Shared/notification.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-demand-view',
  templateUrl: './demand-view.component.html',
  styleUrls: ['./demand-view.component.css']
})
export class DemandViewComponent {
  demand: Demand[] = [];
  company: Company[] = [];
  dateRange = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });
  dataSource: MatTableDataSource<Demand> = new MatTableDataSource(this.demand);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["title", "date", "company", "actions"];

  constructor(
    private demandSvc: DemandService,
    private companySvc:CompanyService,
    private notificationSvc: NotificationService,
    private dialog: MatDialog
  ) { }
  confirmDelete(data: Demand) {
    //console.log(data);
    this.dialog.open(ConfirmDialogComponent, {
      width: '450px',
      enterAnimationDuration: '800ms'
    }).afterClosed()
      .subscribe(result => {
        //console.log(result);
        if (result) {
          this.demandSvc.delete(data)
            .subscribe({
              next: r => {
                this.notificationSvc.message('Demand removed', 'DISMISS');
                this.dataSource.data = this.dataSource.data.filter(c => c.demandId != data.demandId);
              },
              error: err => {
                this.notificationSvc.message('Failed to delete data', 'DISMISS');
                throwError(() => err);
              }
            })
        }
      })
  }

  getCompanyNames(id: number) {
    let c = this.company.find(c => c.companyId == id);
    return c ? c.name : '';
  }

  getCompanyName(id: number) {
    let c = this.company.find(c => c.companyId == id);
    return c ? c.name : '';
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  filterDate(queryDate: any) {
    //getTimezoneOffset() method to get the difference between the timezone of the computer and UTC time, in minutes
    var offset = queryDate.getTimezoneOffset() * 60 * 1000;
    var utcDate = new Date(queryDate.getTime() - offset);
    var data = utcDate.toISOString().split('T')[0];
    this.dataSource.filter = data;
    this.demand;
  }

  filterDateRange(startDate: any, endDate: any) {
    const start = new Date(startDate);
    const end = new Date(endDate);
    const startUtc = new Date(Date.UTC(start.getFullYear(), start.getMonth(), start.getDate()));
    const endUtc = new Date(Date.UTC(end.getFullYear(), end.getMonth(), end.getDate()));
    const startIso = startUtc.toISOString().split('T')[0];
    const endIso = endUtc.toISOString().split('T')[0];
    this.dataSource.filter = `${startIso}:${endIso}`;
  }

  ngOnInit(): void {
    this.companySvc.get()
      .subscribe(x => {
        this.company = x;
      }, err => {
        this.notificationSvc.message("Failed to load Company data!!!", "DISMISS");
      });

    this.demandSvc.get().
      subscribe(x => {

        x.forEach(x => {
          const id = x.companyId ?? 0;
          x.companyName = this.getCompanyName(id);
        });
        this.demand = x;
        //console.log(x);
        this.dataSource.data = this.demand;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, err => {
        this.notificationSvc.message("Failed to load Demand data", "DISMISS");
      });
  }

  //ngOnInit(): void {
  //  this.demandSvc.get().
  //    subscribe(x => {
  //      this.demand = x;
  //      console.log(x);
  //      this.dataSource.data = this.demand;
  //      this.dataSource.paginator = this.paginator;
  //      this.dataSource.sort = this.sort;
  //    }, err => {
  //      this.notificationSvc.message("Failed to load Demand data", "DISMISS");
  //    });
  //  this.companySvc.get()
  //    .subscribe(x => {
  //      this.company = x;
  //    }, err => {
  //      this.notificationSvc.message("Failed to load Demand data!!!", "DISMISS");
  //    })
  //}
}
