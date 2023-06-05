import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationFileCreateComponent } from './application-file-create.component';

describe('ApplicationFileCreateComponent', () => {
  let component: ApplicationFileCreateComponent;
  let fixture: ComponentFixture<ApplicationFileCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationFileCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationFileCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
