import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationFileTransferEditComponent } from './application-file-transfer-edit.component';

describe('ApplicationFileTransferEditComponent', () => {
  let component: ApplicationFileTransferEditComponent;
  let fixture: ComponentFixture<ApplicationFileTransferEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationFileTransferEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationFileTransferEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
