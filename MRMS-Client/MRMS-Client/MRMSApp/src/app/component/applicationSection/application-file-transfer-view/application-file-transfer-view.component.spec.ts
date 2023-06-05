import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationFileTransferViewComponent } from './application-file-transfer-view.component';

describe('ApplicationFileTransferViewComponent', () => {
  let component: ApplicationFileTransferViewComponent;
  let fixture: ComponentFixture<ApplicationFileTransferViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationFileTransferViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationFileTransferViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
