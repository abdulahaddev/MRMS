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
import { RegisterComponent } from './component/Authentication/register/register.component';
import { SignInComponent } from './component/Authentication/sign-in/sign-in.component';
import { AuthGuard } from './component/auth/guards/auth.guard';
import { DemandDetailsComponent } from './component/demandSection/demand-details/demand-details.component';

import { ApplicationCreateComponent } from './component/applicationSection/application-create/application-create.component';
import { ApplicationEditComponent } from './component/applicationSection/application-edit/application-edit.component';
import { ApplicationViewComponent } from './component/applicationSection/application-view/application-view.component';


const routes: Routes = [
  { path: '', component: SignInComponent },
  { path: 'home', component: HomeComponent },
  { path: 'signUp', component: RegisterComponent },
  { path: 'signin', component: SignInComponent },
  { path: 'demand', component: DemandViewComponent, canActivate: [AuthGuard] },
  { path: 'demand-create', component: DemandCreateComponent, canActivate: [AuthGuard] },
  { path: 'demand-edit/:id', component: DemandEditComponent, canActivate: [AuthGuard] },

  { path: 'demandIssue', component: DemandIssueViewComponent, canActivate: [AuthGuard] },
  { path: 'demandIssue-create', component: DemandIssueCreateComponent, canActivate: [AuthGuard] },
  { path: 'demandIssue-edit/:id', component: DemandIssueEditComponent, canActivate: [AuthGuard] },
  { path: 'demand', component: DemandViewComponent },
  { path: 'demand-create', component: DemandCreateComponent },
  { path: 'demand-edit/:id', component: DemandEditComponent },
  { path: 'demand-details/:id', component: DemandDetailsComponent },

  { path: 'trade', component: TradeViewComponent, canActivate: [AuthGuard] },
  { path: 'trade-create', component: TradeCreateComponent, canActivate: [AuthGuard] },
  { path: 'trade-edit/:id', component: TradeEditComponent, canActivate: [AuthGuard] },
  { path: 'FileContainer', component: FileContainerComponent, canActivate: [AuthGuard] },
  { path: 'medicalCenter', component: MedicalCenterViewComponent, canActivate: [AuthGuard] },
  { path: 'medicalCenterCreate', component: MedicalCenterCreateComponent, canActivate: [AuthGuard] },
  { path: 'medicalCenterEdit/:id', component: MedicalCenterEditComponent, canActivate: [AuthGuard] },
  { path: 'demandFile', component: DemandFileCreateComponent, canActivate: [AuthGuard] },
  { path: 'company', component: CompanyViewComponent, canActivate: [AuthGuard] },
  { path: 'company-view', component: CompanyViewComponent, canActivate: [AuthGuard] },
  { path: 'company-create', component: CompanyCreateComponent, canActivate: [AuthGuard] },
  { path: 'company-edit/:id', component: CompanyEditComponent, canActivate: [AuthGuard] },
  { path: 'agent', component: AgentViewComponent, canActivate: [AuthGuard] },
  { path: 'agent-view', component: AgentViewComponent, canActivate: [AuthGuard] },
  { path: 'agent-create', component: AgentCreateComponent, canActivate: [AuthGuard] },
  { path: 'agent-edit/:id', component: AgentEditComponent, canActivate: [AuthGuard] },
  { path: 'applicant', component: ApplicantViewComponent, canActivate: [AuthGuard] },
  { path: 'applicant-create', component: ApplicantCreateComponent, canActivate: [AuthGuard] },
  { path: 'applicant-edit/:id', component: ApplicantEditComponent, canActivate: [AuthGuard] },
  { path: 'agency', component: AgencyViewComponent, canActivate: [AuthGuard] },
  { path: 'agency-view', component: AgencyViewComponent, canActivate: [AuthGuard] },
  { path: 'agency-create', component: AgencyCreateComponent, canActivate: [AuthGuard] },
  { path: 'agency-edit/:id', component: AgencyEditComponent, canActivate: [AuthGuard] },
  { path: 'applicant-edit/:id', component: ApplicantEditComponent, canActivate: [AuthGuard] },



  { path: 'visa', component: VisaViewComponent, canActivate: [AuthGuard] },
  { path: 'visa-create', component: VisaCreateComponent, canActivate: [AuthGuard] },
  { path: 'visa-edit/:id', component: VisaEditComponent, canActivate: [AuthGuard] }


  { path: 'application', component: ApplicationViewComponent },
  { path: 'application-create', component: ApplicationCreateComponent },
  { path: 'application-edit/:id', component: ApplicationEditComponent }



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
