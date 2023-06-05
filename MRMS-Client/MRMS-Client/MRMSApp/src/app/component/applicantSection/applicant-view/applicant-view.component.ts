import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { Agent } from '../../../models/Agent/agent';

import { Applicant } from '../../../models/ApplicantSection/applicant';
import { AgentService } from '../../../services/Agents/agents.service';
import { ApplicantService } from '../../../services/ApplicantSection/applicant.service';
import { NotificationService } from '../../../services/Shared/notification.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-applicant-view',
  templateUrl: './applicant-view.component.html',
  styleUrls: ['./applicant-view.component.css']
})
export class ApplicantViewComponent {
  applicant: Applicant[] = [];
  agent: Agent[] = [];
  dataSource: MatTableDataSource<Applicant> = new MatTableDataSource(this.applicant);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["passsportNo", "passportExpiry"/*, "height", "weight"*/, "jobExperience", "agentId", "name", "fathersName"/*, "mothersName"*/, "spouse", "presentAddress", "permanentAddress", "dateOfBrith", "phoneNumber", "nid"/*, "birthCertificateNo"*/, "email"/*, "nationality"*//*, "picture","gender", "religion", "maritalStatus", "education"*/, "actions"];

  constructor(
    private applicantSvc: ApplicantService,
    private agentSvc: AgentService,
    private notificationSvc: NotificationService,
    private dialog: MatDialog,
    private route: Router
  ) { }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  getAgentName(id: number) {
    let c = this.agent.find(c => c.agentId == id);
    return c ? c.name : '';
  }


  ngOnInit(): void {
    this.applicantSvc.get().
      subscribe(a => {
        this.agent = a;
        console.log(a);
        this.dataSource.data = this.agent;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, err => {
        this.notificationSvc.message("Failed to load Applicant data", "DISMISS");
      });
    this.agentSvc.get()
      .subscribe(x => {
        this.agent = x;
      }, err => {
        this.notificationSvc.message("Failed to load Agent data!!!", "DISMISS");
      })
  }


  confirmDelete(data: Applicant) {
    //console.log(data);
    this.dialog.open(ConfirmDialogComponent, {
      width: '450px',
      enterAnimationDuration: '400ms'
    }).afterClosed()
      .subscribe(result => {
        //console.log(result);
        if (result) {
          this.applicantSvc.delete(data)
            .subscribe({
              next: r => {
                this.notificationSvc.message('Applicant has removed', 'DISMISS');
                this.dataSource.data = this.dataSource.data.filter(c => c.applicantId != data.applicantId);
              },
              error: err => {
                this.notificationSvc.message('Failed to delete data', 'DISMISS');
                throwError(() => err);
              }
            })
        }
      })
  }
}
