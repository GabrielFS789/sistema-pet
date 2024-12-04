import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RacaComponent } from './raca.component';

describe('RacaComponent', () => {
  let component: RacaComponent;
  let fixture: ComponentFixture<RacaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RacaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RacaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
