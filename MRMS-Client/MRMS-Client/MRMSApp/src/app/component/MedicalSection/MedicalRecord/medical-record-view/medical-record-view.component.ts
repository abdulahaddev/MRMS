import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';

import { Agency } from '../../../../models/AgencySection/agency';
import { AgencySyndicate } from '../../../../models/AgencySection/agency-syndicate';
import { Applicant } from '../../../../models/ApplicantSection/applicant';
import { Demand } from '../../../../models/demandSection/demand';
import { MedicalCenter } from '../../../../models/MedicalSection/medical-center';
import { MedicalRecord } from '../../../../models/MedicalSection/medical-record';
import { medicalStatus } from '../../../../models/shared/enum-list';
import { AgencySyndicateService } from '../../../../services/agencySection/agency-syndicate.service';
import { AgencyService } from '../../../../services/agencySection/agency.service';
import { ApplicantService } from '../../../../services/ApplicantSection/applicant.service';
import { DemandService } from '../../../../services/demandSection/demand.service';
import { MedicalCenterService } from '../../../../services/MedicalSection/medical-center.service';
import { MedicalRecordsService } from '../../../../services/MedicalSection/medical-records.service';
import { NotificationService } from '../../../../services/Shared/notification.service';
import { ConfirmDialogComponent } from '../../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-medical-record-view',
  templateUrl: './medical-record-view.component.html',
  styleUrls: ['./medical-record-view.component.css']
})
export class MedicalRecordViewComponent {
  medicalRecord: MedicalRecord[] = [];
  demand: Demand[] = [];
  applicant: Applicant[] = [];
  agencySyndicate: AgencySyndicate[] = [];
  medicalCenter: MedicalCenter[] = [];
  agency: Agency[] = [];
  dataSource: MatTableDataSource<MedicalRecord> = new MatTableDataSource(this.medicalRecord);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["demandId", "applicantId", "medicalCenterId", "agencySyndicateId", "medicalStatus", "slipIssueDate", "medicalDate","expiryDate", "actions"];

  constructor(
    private demandSvc: DemandService,
    private medicalRecSvc: MedicalRecordsService,
    private applicantSvc: ApplicantService,
    private agecySyndicateSvc: AgencySyndicateService,
    private agencySvc: AgencyService,
    private medicalCenterSvc:MedicalCenterService,
    private notificationSvc: NotificationService,
    private dialog: MatDialog
  ) { }

  getStatusName(v: number): string {
    return medicalStatus[v];
  }
  confirmDelete(data: MedicalRecord) {
    //console.log(data);
    this.dialog.open(ConfirmDialogComponent, {
      width: '450px',
      enterAnimationDuration: '400ms'
    }).afterClosed()
      .subscribe(result => {
        //console.log(result);
        if (result) {
          this.medicalRecSvc.delete(data)
            .subscribe({
              next: r => {
                this.notificationSvc.message('Medical Record removed', 'DISMISS');
                this.dataSource.data = this.dataSource.data.filter(c => c.medicalRecordId != data.medicalRecordId);
              },
              error: err => {
                this.notificationSvc.message('Failed to delete data', 'DISMISS');
                throwError(() => err);
              }
            })
        }
      })
  }

  getDemandNames(id: number) {
    let c = this.demand.find(c => c.demandId == id);
    return c ? c.title : '';
  }

  getApplicantName(id: number) {
    let c = this.applicant.find(c => c.applicantId == id);
    return c ? c.name : '';
  }

  getAgencySyndicateNames(id: number) {
    let c = this.agency.find(c => c.agencyId == id);
    return c ? c.name : '';
  }

  getMedicalCenterName(id: number) {
    let c = this.medicalCenter.find(c => c.medicalCenterId == id);
    return c ? c.name : '';
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  filterDate(queryDate: any) {
    //const filterDate = new Date(queryDate);
    this.dataSource.filter = queryDate.toISOString().split('T')[0];
    this.demand;
  }

  ngOnInit(): void {
    this.applicantSvc.get()
      .subscribe(x => {
        this.applicant = x;
      }, err => {
        this.notificationSvc.message("Failed to load Applicant data!!!", "DISMISS");
      });

    this.medicalCenterSvc.get()
      .subscribe(x => {
        this.medicalCenter = x;
      }, err => {
        this.notificationSvc.message("Failed to load MedicalCenter data!!!", "DISMISS");
      });

    this.demandSvc.get()
      .subscribe(x => {
        this.demand = x;
      }, err => {
        this.notificationSvc.message("Failed to load Demand data!!!", "DISMISS");
      });
    //this.agencySvc.get()
    //  .subscribe(x => {
    //    this.agency = x;
    //  }, err => {
    //    this.notificationSvc.message("Failed to load Agency data!!!", "DISMISS");
    //  });
    //this.agecySyndicateSvc.get()
    //  .subscribe(x => {
    //    this.agencySyndicate = x;
    //  }, err => {
    //    this.notificationSvc.message("Failed to load AgencySyndicate data!!!", "DISMISS");
    //  });

    this.medicalRecSvc.get().
      subscribe(x => {

        x.forEach(x => {
          const id = x.applicantId ?? 0;
          x.applicant = this.getApplicantName(id);
        });
        x.forEach(x => {
          const id = x.medicalCenterId ?? 0;
          x.medicalCenter = this.getMedicalCenterName(id);
        });
        x.forEach(x => {
          const id = x.demandId ?? 0;
          x.demand = this.getDemandNames(id);
        });
        x.forEach(x => {
          const id = x.agencySyndicateId ?? 0;
          x.agencySyndicate = this.getAgencySyndicateNames(id);
        });
        this.medicalRecord = x;
        console.log(x);
        this.dataSource.data = this.medicalRecord;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, err => {
        this.notificationSvc.message("Failed to load Medical Record ", "DISMISS");
      });
  }
}
