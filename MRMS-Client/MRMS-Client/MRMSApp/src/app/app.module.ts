import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DemandCreateComponent } from './component/demandSection/demand-create/demand-create.component';
import { DemandViewComponent } from './component/demandSection/demand-view/demand-view.component';
import { DemandEditComponent } from './component/demandSection/demand-edit/demand-edit.component';
import { TradeCreateComponent } from './component/demandSection/trade-create/trade-create.component';
import { TradeViewComponent } from './component/demandSection/trade-view/trade-view.component';
import { TradeEditComponent } from './component/demandSection/trade-edit/trade-edit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './component/shared/navbar/navbar.component';
import { HttpClient,HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DemandService } from './services/demandSection/demand.service';
import { TradeService } from './services/demandSection/trade.service';
import { NotificationService } from './services/Shared/notification.service';
import { DatePipe } from '@angular/common';
import { AgencyViewComponent } from './component/agency-section/agency-view/agency-view.component';
import { AgencyCreateComponent } from './component/agency-section/agency-create/agency-create.component';
import { AgencyEditComponent } from './component/agency-section/agency-edit/agency-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LayoutModule } from '@angular/cdk/layout';
import { MatModule } from './module/shared/mat/mat.module';
import { ConfirmDialogComponent } from './component/shared/confirm-dialog/confirm-dialog.component';
import { HomeComponent } from './component/home/home.component';
import { AuthInterceptor } from './Shared/authconfig.interceptor';
import { MedicalIssuesCreateComponent } from './component/MedicalSection/MedicalIssues/medical-issues-create/medical-issues-create.component';
import { MedicalIssuesViewComponent } from './component/MedicalSection/MedicalIssues/medical-issues-view/medical-issues-view.component';
import { MedicalIssuesEditComponent } from './component/MedicalSection/MedicalIssues/medical-issues-edit/medical-issues-edit.component';
import { MedicalFilessCreateComponent } from './component/MedicalSection/MedicalFiles/medical-filess-create/medical-filess-create.component';
import { MedicalFilessEditComponent } from './component/MedicalSection/MedicalFiles/medical-filess-edit/medical-filess-edit.component';
import { MedicalFilessViewComponent } from './component/MedicalSection/MedicalFiles/medical-filess-view/medical-filess-view.component';
import { MedicalRecordCreateComponent } from './component/MedicalSection/MedicalRecord/medical-record-create/medical-record-create.component';
import { MedicalRecordEditComponent } from './component/MedicalSection/MedicalRecord/medical-record-edit/medical-record-edit.component';
import { MedicalRecordViewComponent } from './component/MedicalSection/MedicalRecord/medical-record-view/medical-record-view.component';
import { MedicalIssuesCommentViewComponent } from './component/MedicalSection/MedicalIssuesComment/medical-issues-comment-view/medical-issues-comment-view.component';
import { MedicalIssuesCommentCreateComponent } from './component/MedicalSection/MedicalIssuesComment/medical-issues-comment-create/medical-issues-comment-create.component';
import { MedicalIssuesCommentEditComponent } from './component/MedicalSection/MedicalIssuesComment/medical-issues-comment-edit/medical-issues-comment-edit.component';
import { MedicalCenterCreateComponent } from './component/MedicalSection/MedicalCenter/medical-center-create/medical-center-create.component';
import { MedicalCenterEditComponent } from './component/MedicalSection/MedicalCenter/medical-center-edit/medical-center-edit.component';
import { MedicalCenterViewComponent } from './component/MedicalSection/MedicalCenter/medical-center-view/medical-center-view.component';
import { MedicalViewComponent } from './component/MedicalSection/medical-view/medical-view.component';
import { FileContainerComponent } from './component/shared/file-container/file-container.component';
import { DemandFileCreateComponent } from './component/demandSection/demandFile/demand-file-create/demand-file-create.component';
import { DemandFileEditComponent } from './component/demandSection/demandFile/demand-file-edit/demand-file-edit.component';
import { DemandFileViewComponent } from './component/demandSection/demandFile/demand-file-view/demand-file-view.component';

import { DemandIssueCreateComponent } from './component/demandSection/demand-issue-create/demand-issue-create.component';
import { DemandIssueEditComponent } from './component/demandSection/demand-issue-edit/demand-issue-edit.component';
import { DemandIssueViewComponent } from './component/demandSection/demand-issue-view/demand-issue-view.component';


import { CompanyCreateComponent } from './component/company/company-create/company-create.component';
import { CompanyEditComponent } from './component/company/company-edit/company-edit.component';
import { CompanyViewComponent } from './component/company/company-view/company-view.component';
import { AgentCreateComponent } from './component/agentSection/agent-create/agent-create.component';
import { AgentEditComponent } from './component/agentSection/agent-edit/agent-edit.component';
import { AgentViewComponent } from './component/agentSection/agent-view/agent-view.component';
import { AgentService } from './services/Agents/agents.service';
import { ApplicantViewComponent } from './component/applicantSection/applicant-view/applicant-view.component';
import { ApplicantCreateComponent } from './component/applicantSection/applicant-create/applicant-create.component';
import { ApplicantEditComponent } from './component/applicantSection/applicant-edit/applicant-edit.component';

import { VisaViewComponent } from './component/visaSection/visa-view/visa-view.component';
import { VisaCreateComponent } from './component/visaSection/visa-create/visa-create.component';
import { VisaEditComponent } from './component/visaSection/visa-edit/visa-edit.component';
import { ApplicationCreateComponent } from './component/applicationSection/application-create/application-create.component';
import { ApplicationEditComponent } from './component/applicationSection/application-edit/application-edit.component';
import { ApplicationViewComponent } from './component/applicationSection/application-view/application-view.component';
import { ApplicationFileCreateComponent } from './component/applicationSection/application-file-create/application-file-create.component';
import { ApplicationFileViewComponent } from './component/applicationSection/application-file-view/application-file-view.component';
import { ApplicationFileEditComponent } from './component/applicationSection/application-file-edit/application-file-edit.component';
import { ApplicationFileTransferCreateComponent } from './component/applicationSection/application-file-transfer-create/application-file-transfer-create.component';
import { ApplicationFileTransferEditComponent } from './component/applicationSection/application-file-transfer-edit/application-file-transfer-edit.component';
import { ApplicationFileTransferViewComponent } from './component/applicationSection/application-file-transfer-view/application-file-transfer-view.component';



@NgModule({
  declarations: [
    AppComponent,  
    DemandCreateComponent,
    DemandViewComponent,
    DemandEditComponent,
    DemandIssueCreateComponent,
    DemandIssueEditComponent,
    DemandIssueViewComponent,
    TradeCreateComponent,
    TradeViewComponent,
    TradeEditComponent,
    NavbarComponent,
    ConfirmDialogComponent,
    HomeComponent,
    MedicalIssuesCreateComponent,
    MedicalIssuesViewComponent,
    MedicalIssuesEditComponent,
    MedicalFilessCreateComponent,
    MedicalFilessEditComponent,
    MedicalFilessViewComponent,
    MedicalRecordCreateComponent,
    MedicalRecordEditComponent,
    MedicalRecordViewComponent,
    MedicalIssuesCommentViewComponent,
    MedicalIssuesCommentCreateComponent,
    MedicalIssuesCommentEditComponent,
    MedicalCenterCreateComponent,
    MedicalCenterEditComponent,
    MedicalCenterViewComponent,
    MedicalViewComponent,
    FileContainerComponent,
    DemandFileCreateComponent,
    DemandFileEditComponent,
    DemandFileViewComponent,
    CompanyCreateComponent,
    CompanyEditComponent,
    CompanyViewComponent,
    AgentCreateComponent,
    AgentEditComponent,
    AgentViewComponent,
    AgentEditComponent,
    ApplicantViewComponent,
    ApplicantCreateComponent,
    ApplicantEditComponent,
    AgencyViewComponent,
    AgencyCreateComponent,
    AgencyEditComponent,
    VisaViewComponent,
    VisaCreateComponent,
    VisaEditComponent,
    ApplicationCreateComponent,
    ApplicationEditComponent,
    ApplicationViewComponent,
    ApplicationFileCreateComponent,
    ApplicationFileViewComponent,
    ApplicationFileEditComponent,
    ApplicationFileTransferCreateComponent,
    ApplicationFileTransferEditComponent,
    ApplicationFileTransferViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DatePipe,
    ReactiveFormsModule,
    LayoutModule,
    MatModule,
    FormsModule
  ],
  providers: [
    HttpClient,
    DemandService,
    TradeService,
    NotificationService,
    AgentService,
    DatePipe,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
