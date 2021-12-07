import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListRecommendComponent } from './list-recommend.component';

describe('ListRecommendComponent', () => {
  let component: ListRecommendComponent;
  let fixture: ComponentFixture<ListRecommendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListRecommendComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListRecommendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
