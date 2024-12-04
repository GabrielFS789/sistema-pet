import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCadastraRacaComponent } from './dialog-cadastra-raca.component';

describe('DialogCadastraRacaComponent', () => {
  let component: DialogCadastraRacaComponent;
  let fixture: ComponentFixture<DialogCadastraRacaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DialogCadastraRacaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogCadastraRacaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
