import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { Agency } from '../../../models/AgencySection/agency';
import { Applicant } from '../../../models/ApplicantSection/applicant';
import { Application } from '../../../models/applicationSection/application';
import { Trade } from '../../../models/demandSection/trade';
import { issueStatus } from '../../../models/shared/enum-list';
import { AgencyService } from '../../../services/AgencySection/agency.service';
import { ApplicantService } from '../../../services/ApplicantSection/applicant.service';
import { ApplicationService } from '../../../services/applicationSection/application.service';
import { TradeService } from '../../../services/demandSection/trade.service';
import { NotificationService } from '../../../services/Shared/notification.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-application-view',
  templateUrl: './application-view.component.html',
  styleUrls: ['./application-view.component.css']
})
export class ApplicationViewComponent {


  application: Application[] = [];
  trade: Trade[] = [];
  applicant: Applicant[] = [];
  agency: Agency[] = [];
  dataSource: MatTableDataSource<Application> = new MatTableDataSource(this.application);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["tradeId", "applicantId", "agencyId", "applicationDate", "status","actions"];

  constructor(
    private applicationSvc: ApplicationService,
    private tradeSvc: TradeService,
    private applicantSvc : ApplicantService,
    private agencySvc : AgencyService,

    private notificationSvc: NotificationService,
    private dialog: MatDialog
  ) { }
  getStatusName(v: number): string {
    return issueStatus[v];
  }

  confirmDelete(data: Application) {
    //console.log(data);
    this.dialog.open(ConfirmDialogComponent, {
      width: '450px',
      enterAnimationDuration: '800ms'
    }).afterClosed()
      .subscribe(result => {
        //console.log(result);
        if (result) {
          this.applicationSvc.delete(data)
            .subscribe({
              next: r => {
                this.notificationSvc.message('Application removed', 'DISMISS');
                this.dataSource.data = this.dataSource.data.filter(c => c.applicationId != data.applicationId);
              },
              error: err => {
                this.notificationSvc.message('Failed to delete data', 'DISMISS');
                throwError(() => err);
              }
            })
        }
      })
  }

  
  getTradeNames(id: number) {
    let c = this.trade.find(c => c.tradeId == id);
    return c ? c.jobTitle : '';
  }

  getApplicantNames(id: number) {
    let c = this.applicant.find(c => c.applicantId == id);
    return c ? c.passsportNo : '';
  }
  getAgencyNames(id: number) {
    let c = this.agency.find(c => c.agencyId == id);
    return c ? c.name : '';
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  filterDate(queryDate: any) {
    //const filterDate = new Date(queryDate);
    this.dataSource.filter = queryDate.toISOString().split('T')[0];
    this.application;
  }

  
  ngOnInit(): void {

    this.tradeSvc.get()
      .subscribe(x => {
        this.trade = x;
      }, err => {
        this.notificationSvc.message("Failed to load Trade data!!!", "DISMISS");
      });
    this.applicantSvc.get()
      .subscribe(x => {
        this.applicant = x;
      }, err => {
        this.notificationSvc.message("Failed to load Application data!!!", "DISMISS");
      });
    this.agencySvc.get()
      .subscribe(x => {
        this.agency = x;
      }, err => {
        this.notificationSvc.message("Failed to load Agency data!!!", "DISMISS");
      });

    this.applicationSvc.get().
      subscribe(x => {

        x.forEach(x => {
          const id = x.tradeId ?? 0;
          x.jobTitle = this.getTradeNames(id);
        });
        x.forEach(x => {
          const id = x.applicantId ?? 0;
          x.passsportNo = this.getApplicantNames(id);
        });
        x.forEach(x => {
          const id = x.agencyId ?? 0;
          x.name = this.getAgencyNames(id);
        });
        this.application = x;
        console.log(x);
        this.dataSource.data = this.application;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, err => {
        this.notificationSvc.message("Failed to load Application data", "DISMISS");
      });
  }


}
