import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationFileViewComponent } from './application-file-view.component';

describe('ApplicationFileViewComponent', () => {
  let component: ApplicationFileViewComponent;
  let fixture: ComponentFixture<ApplicationFileViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationFileViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationFileViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
