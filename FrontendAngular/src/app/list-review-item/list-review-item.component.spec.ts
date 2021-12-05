import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListReviewItemComponent } from './list-review-item.component';

describe('ListReviewItemComponent', () => {
  let component: ListReviewItemComponent;
  let fixture: ComponentFixture<ListReviewItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListReviewItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListReviewItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
