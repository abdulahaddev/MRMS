import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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

@Component({
  selector: 'app-application-create',
  templateUrl: './application-create.component.html',
  styleUrls: ['./application-create.component.css']
})
export class ApplicationCreateComponent {
  application: Application = new Application();
  applicationForm: FormGroup = new FormGroup({

    tradeId: new FormControl('', Validators.required),
    applicantId: new FormControl('', Validators.required),
    agencyId: new FormControl('', Validators.required),
    applicationDate: new FormControl(undefined, Validators.required),
    status: new FormControl('', Validators.required)
  });
  trade: Trade[] = [];
  applicant: Applicant[] = [];
  agency: Agency[] = [];
  f() {
    return this.applicationForm.controls;

  }
  IssueStatus: { label: string, value: number }[] = [];
  constructor(
    private applicationSvc: ApplicationService,
    private tradeSvc: TradeService,
    private applicantSvc: ApplicantService,
    private agencySvc: AgencyService,
    private notificationSvc: NotificationService,
    private datePipe: DatePipe,
    private router: Router
  ) { }
  insert(): void {
    if (this.applicationForm.invalid) return;
    console.log(this.applicationForm.value);

    Object.assign(this.application, this.applicationForm.value);
    console.log(this.application);

    //this.applicationSvc.insert(this.application)
    //  .subscribe(r => {
    //    this.notificationSvc.message("Data saved successfully!!!", "DISMISS");
    //    this.router.navigate(['/application']);
    //    this.applicationForm.reset({});
    //    console.log(r);
    //  }, err => {
    //    this.notificationSvc.message("Failed to save data!!!", "DISMISS");
    //  })

    //if (this.applicationForm.invalid) return;
    
    //console.log(this.applicationForm.value);

    //Object.assign(this.application, this.applicationForm.value);
    //console.log(this.application);


    this.application.tradeId = this.f()['jobTitle'].value;
    this.application.applicantId = this.f()['passsportNo'].value;
    this.application.agencyId = this.f()['name'].value;
    this.application.applicationDate = new Date(<string>this.datePipe.transform(this.application.applicationDate, "yyyy-MM-dd"));
    this.application.status = this.f()['status'].value;
    
    const formData = new FormData();
    this.applicationSvc.insert(formData)
      .subscribe(r => {
        this.notificationSvc.message("Data saved successfully!!!", "DISMISS");
        this.router.navigate(['/application']);
        this.applicationForm.reset({});
        console.log(r);
      }, err => {
        this.notificationSvc.message("Failed to save data!!!", "DISMISS");
      })

  
   
    //const formData = new FormData();
    //Object.assign(this.application, this.applicationForm.value);
    //this.applicationSvc.insert(formData)
    //  .subscribe(r => {
    //    this.notificationSvc.message("Data saved successfully!!!", "DISMISS");
    //    this.router.navigate(['/application']);
    //    this.applicationForm.reset({});
    //    console.log(r);
    //  }, err => {
    //    this.notificationSvc.message("Failed to save data!!!", "DISMISS");
    //  })
  
  }
  ngOnInit(): void {
    this.tradeSvc.get()
      .subscribe(r => {
        this.trade = r;
      }, err => {
        this.notificationSvc.message("Failed to load Trade", "DISMISS");
      })
    this.applicantSvc.get()
      .subscribe(r => {
        this.applicant = r;
      }, err => {
        this.notificationSvc.message("Failed to load Applicant", "DISMISS");
      })
    this.agencySvc.get()
      .subscribe(r => {
        this.agency = r;
      }, err => {
        this.notificationSvc.message("Failed to load Agency", "DISMISS");
      })
    Object.keys(issueStatus).filter(
      (type) => isNaN(<any>type) && type !== 'values'
    ).forEach((v: any, i) => {
      this.IssueStatus.push({ label: v, value: <any>issueStatus[v] });
    });
  }
}
