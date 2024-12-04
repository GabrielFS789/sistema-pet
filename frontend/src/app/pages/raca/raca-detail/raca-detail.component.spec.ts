import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RacaDetailComponent } from './raca-detail.component';

describe('RacaDetailComponent', () => {
  let component: RacaDetailComponent;
  let fixture: ComponentFixture<RacaDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RacaDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RacaDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
