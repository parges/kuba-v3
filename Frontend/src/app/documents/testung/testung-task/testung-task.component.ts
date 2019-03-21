import { FormGroup } from '@angular/forms';
import { FormBase } from './../../../utils/dynamic-forms/form-base';
import { Component, OnInit, Input } from '@angular/core';
import { TestungQuestion } from 'src/app/models/testung';

@Component({
  selector: 'app-testung-task',
  templateUrl: './testung-task.component.html',
  styleUrls: ['./testung-task.component.scss']
})
export class TestungTaskComponent implements OnInit {

  @Input() question: FormBase<any>;
  @Input() form: FormGroup;

  constructor() { }

  ngOnInit() {
  }
  get isValid() { return this.form.controls[this.question.key].valid; }

}
