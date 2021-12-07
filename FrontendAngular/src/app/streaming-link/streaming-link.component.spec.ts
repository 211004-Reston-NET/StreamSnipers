import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StreamingLinkComponent } from './streaming-link.component';

describe('StreamingLinkComponent', () => {
  let component: StreamingLinkComponent;
  let fixture: ComponentFixture<StreamingLinkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StreamingLinkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StreamingLinkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
