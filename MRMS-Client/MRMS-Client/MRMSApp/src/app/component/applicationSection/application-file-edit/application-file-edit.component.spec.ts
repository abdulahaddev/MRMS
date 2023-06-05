import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationFileEditComponent } from './application-file-edit.component';

describe('ApplicationFileEditComponent', () => {
  let component: ApplicationFileEditComponent;
  let fixture: ComponentFixture<ApplicationFileEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationFileEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationFileEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
