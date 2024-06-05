import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Agency } from '../../../models/AgencySection/agency';
import { AgencyService } from '../../../services/agencySection/agency.service';
import { NotificationService } from '../../../services/Shared/notification.service';

@Component({
  selector: 'app-agency-edit',
  templateUrl: './agency-edit.component.html',
  styleUrls: ['./agency-edit.component.css']
})
export class AgencyEditComponent {
  agency: Agency = new Agency();
  agencyForm: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    rl: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    contactNo: new FormControl('', Validators.required),
    manager: new FormControl('', Validators.required),
    accountant: new FormControl('', Validators.required)

  });

  f() {
    return this.agencyForm.controls;
  }
  constructor(
    private agencySvc: AgencyService,
    private notificationSvc: NotificationService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }



  update(): void {
    if (this.agencyForm.invalid) return;
    console.log(this.agencyForm.value);

    Object.assign(this.agency, this.agencyForm.value);
    console.log(this.agency);

    this.agencySvc.update(this.agency)
      .subscribe(r => {
        this.notificationSvc.message("Data Update successfully!!!", "DISMISS");
        this.router.navigate(['/agency']);
        this.agencyForm.reset({});
        console.log(r);
      }, err => {
        this.notificationSvc.message("Failed to Update data!!!", "DISMISS");
      })
  }


  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params['id'];
    this.agencySvc.getById(id)
      .subscribe(x => {
        this.agency = x;
        this.agencyForm.patchValue(this.agency);
      }, err => {
        this.notificationSvc.message("Failed to load  Agency List!!", "DISMISS");
      })
  }



}
