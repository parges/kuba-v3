import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestungTaskComponent } from './testung-task.component';

describe('TestungTaskComponent', () => {
  let component: TestungTaskComponent;
  let fixture: ComponentFixture<TestungTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestungTaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestungTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
