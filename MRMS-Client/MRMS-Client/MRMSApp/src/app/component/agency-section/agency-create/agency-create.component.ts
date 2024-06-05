import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Agency } from '../../../models/AgencySection/agency';
import { AgencyService } from '../../../services/agencySection/agency.service';

import { NotificationService } from '../../../services/Shared/notification.service';

@Component({
  selector: 'app-agency-create',
  templateUrl: './agency-create.component.html',
  styleUrls: ['./agency-create.component.css']
})
export class AgencyCreateComponent {
  agency: Agency = new Agency();
  agencyForm: FormGroup = new FormGroup({
  name: new FormControl('', Validators.required),
  rl: new FormControl('', Validators.required),
  address: new FormControl('', Validators.required),
  contactNo: new FormControl('', Validators.required),
  manager: new FormControl('', Validators.required),
  accountant: new FormControl('', Validators.required)

  });
  /*agency: Agency[] = [];*/
  f() {
    return this.agencyForm.controls;
  }
  constructor(
    private notificationSvc: NotificationService,
    private router: Router,
    private agencySvc: AgencyService
  ) { }
  insert(): void {
    if (this.agencyForm.invalid) return;
    console.log(this.agencyForm.value);

    Object.assign(this.agency, this.agencyForm.value);
    console.log(this.agency);

    this.agency.name = this.f()['name'].value;
    this.agency.rl = this.f()['rl'].value;
    this.agency.address = this.f()['address'].value;
    this.agency.contactNo = this.f()['contactNo'].value;
    this.agency.manager = this.f()['manager'].value;
    this.agency.accountant = this.f()['accountant'].value;

    this.agencySvc.insert(this.agency)
      .subscribe(r => {
        this.notificationSvc.message("Data saved successfully!!!", "DISMISS");
        this.router.navigate(['/agency']);
        this.agencyForm.reset({});
        console.log(r);
      }, err => {
        this.notificationSvc.message("Failed to save data!!!", "DISMISS");
      })
  }
  ngOnInit(): void {
    this.agencySvc.get()
      .subscribe(r => {
       // this.agency = r;
      }, err => {
        this.notificationSvc.message("Failed to load agency", "DISMISS");
      })
  }
}
