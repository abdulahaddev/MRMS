import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { Agency } from '../../../models/AgencySection/agency';
import { AgencyService } from '../../../services/agencySection/agency.service';


import { NotificationService } from '../../../services/Shared/notification.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-agency-view',
  templateUrl: './agency-view.component.html',
  styleUrls: ['./agency-view.component.css']
})
export class AgencyViewComponent {
  agency: Agency[] = [];
  dataSource: MatTableDataSource<Agency> = new MatTableDataSource(this.agency);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["name", "rl", "address", "contactNo", "manager","accountant", "actions"];

  constructor(
    private agencySvc: AgencyService,
    private notificationSvc: NotificationService,
    private dialog: MatDialog
  ) { }
  confirmDelete(data: Agency) {
    //console.log(data);
    this.dialog.open(ConfirmDialogComponent, {
      width: '450px',
      enterAnimationDuration: '400ms'
    }).afterClosed()
      .subscribe(result => {
        //console.log(result);
        if (result) {
          this.agencySvc.delete(data)
            .subscribe({
              next: r => {
                this.notificationSvc.message('Agency removed from the list', 'DISMISS');
                this.dataSource.data = this.dataSource.data.filter(c => c.agencyId != data.agencyId);
              },
              error: err => {
                this.notificationSvc.message('Failed to delete data', 'DISMISS');
                throwError(() => err);
              }
            })
        }
      })
  }



  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  //filterDate(queryDate: any) {
  //  //const filterDate = new Date(queryDate);
  //  this.dataSource.filter = queryDate.toISOString().split('T')[0];
  //  this.medicalCenter;
  //}

  ngOnInit(): void {


    this.agencySvc.get().
      subscribe(x => {
        this.agency = x;
        console.log(x);
        this.dataSource.data = this.agency;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, err => {
        this.notificationSvc.message("Failed to load Agency List", "DISMISS");
      });
  }
}

