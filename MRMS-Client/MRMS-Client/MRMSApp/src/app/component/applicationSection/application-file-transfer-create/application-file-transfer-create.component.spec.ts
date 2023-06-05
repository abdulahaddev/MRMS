import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationFileTransferCreateComponent } from './application-file-transfer-create.component';

describe('ApplicationFileTransferCreateComponent', () => {
  let component: ApplicationFileTransferCreateComponent;
  let fixture: ComponentFixture<ApplicationFileTransferCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationFileTransferCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationFileTransferCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
