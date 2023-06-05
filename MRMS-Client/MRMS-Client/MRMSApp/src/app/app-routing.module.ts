import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgencyCreateComponent } from './component/agency-section/agency-create/agency-create.component';
import { AgencyEditComponent } from './component/agency-section/agency-edit/agency-edit.component';
import { AgencyViewComponent } from './component/agency-section/agency-view/agency-view.component';
import { AgentCreateComponent } from './component/agentSection/agent-create/agent-create.component';
import { AgentEditComponent } from './component/agentSection/agent-edit/agent-edit.component';
import { AgentViewComponent } from './component/agentSection/agent-view/agent-view.component';
import { ApplicantCreateComponent } from './component/applicantSection/applicant-create/applicant-create.component';
import { ApplicantEditComponent } from './component/applicantSection/applicant-edit/applicant-edit.component';
import { ApplicantViewComponent } from './component/applicantSection/applicant-view/applicant-view.component';
import { CompanyCreateComponent } from './component/company/company-create/company-create.component';
import { CompanyEditComponent } from './component/company/company-edit/company-edit.component';
import { CompanyViewComponent } from './component/company/company-view/company-view.component';
import { DemandCreateComponent } from './component/demandSection/demand-create/demand-create.component';
import { DemandEditComponent } from './component/demandSection/demand-edit/demand-edit.component';
import { DemandViewComponent } from './component/demandSection/demand-view/demand-view.component';
import { DemandFileCreateComponent } from './component/demandSection/demandFile/demand-file-create/demand-file-create.component';
import { TradeCreateComponent } from './component/demandSection/trade-create/trade-create.component';
import { TradeEditComponent } from './component/demandSection/trade-edit/trade-edit.component';
import { TradeViewComponent } from './component/demandSection/trade-view/trade-view.component';
import { HomeComponent } from './component/home/home.component';
import { MedicalViewComponent } from './component/MedicalSection/medical-view/medical-view.component';
import { MedicalCenterCreateComponent } from './component/MedicalSection/MedicalCenter/medical-center-create/medical-center-create.component';
import { MedicalCenterEditComponent } from './component/MedicalSection/MedicalCenter/medical-center-edit/medical-center-edit.component';
import { MedicalCenterViewComponent } from './component/MedicalSection/MedicalCenter/medical-center-view/medical-center-view.component';
import { MedicalRecordViewComponent } from './component/MedicalSection/MedicalRecord/medical-record-view/medical-record-view.component';
import { FileContainerComponent } from './component/shared/file-container/file-container.component';

import { DemandIssueCreateComponent } from './component/demandSection/demand-issue-create/demand-issue-create.component';
import { DemandIssueEditComponent } from './component/demandSection/demand-issue-edit/demand-issue-edit.component';
import { DemandIssueViewComponent } from './component/demandSection/demand-issue-view/demand-issue-view.component';

import { VisaViewComponent } from './component/visaSection/visa-view/visa-view.component';
import { VisaCreateComponent } from './component/visaSection/visa-create/visa-create.component';
import { VisaEditComponent } from './component/visaSection/visa-edit/visa-edit.component';

import { ApplicationCreateComponent } from './component/applicationSection/application-create/application-create.component';
import { ApplicationEditComponent } from './component/applicationSection/application-edit/application-edit.component';
import { ApplicationViewComponent } from './component/applicationSection/application-view/application-view.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },

  { path: 'demand', component: DemandViewComponent },
  { path: 'demand-create', component: DemandCreateComponent },
  { path: 'demand-edit/:id', component: DemandEditComponent },

  { path: 'demandIssue', component: DemandIssueViewComponent },
  { path: 'demandIssue-create', component: DemandIssueCreateComponent },
  { path: 'demandIssue-edit/:id', component: DemandIssueEditComponent },

  { path: 'trade', component: TradeViewComponent },
  { path: 'trade-create', component: TradeCreateComponent },
  { path: 'trade-edit/:id', component: TradeEditComponent },
  { path: 'FileContainer', component: FileContainerComponent },
  { path: 'medicalCenter', component: MedicalCenterViewComponent },
  { path: 'medicalCenterCreate', component: MedicalCenterCreateComponent },
  { path: 'medicalCenterEdit/:id', component: MedicalCenterEditComponent },
  { path: 'demandFile',component:DemandFileCreateComponent},
  { path: 'company', component: CompanyViewComponent },
  { path: 'company-view', component: CompanyViewComponent },
  { path: 'company-create', component: CompanyCreateComponent },
  { path: 'company-edit/:id', component: CompanyEditComponent },
  { path: 'agent', component: AgentViewComponent },
  { path: 'agent-view', component: AgentViewComponent },
  { path: 'agent-create', component: AgentCreateComponent },
  { path: 'agent-edit/:id', component: AgentEditComponent },
  { path: 'applicant', component: ApplicantViewComponent },
  { path: 'applicant-create', component: ApplicantCreateComponent },
  { path: 'applicant-edit/:id', component: ApplicantEditComponent },
  { path: 'agency', component: AgencyViewComponent },
  { path: 'agency-view', component: AgencyViewComponent },
  { path: 'agency-create', component: AgencyCreateComponent },
  { path: 'agency-edit/:id', component: AgencyEditComponent },
  



  { path: 'visa', component: VisaViewComponent },
  { path: 'visa-create', component: VisaCreateComponent },
  { path: 'visa-edit/:id', component: VisaEditComponent },

  { path: 'application', component: ApplicationViewComponent },
  { path: 'application-create', component: ApplicationCreateComponent },
  { path: 'application-edit/:id', component: ApplicationEditComponent }



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
