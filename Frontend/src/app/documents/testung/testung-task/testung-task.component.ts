import { FormGroup } from '@angular/forms';
import { FormBase } from './../../../utils/dynamic-forms/form-base';
import { Component, OnInit, Input, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-testung-task',
  templateUrl: './testung-task.component.html',
  styleUrls: ['./testung-task.component.scss']
})
export class TestungTaskComponent implements OnInit, AfterViewInit {


  @Input() question: FormBase<any>;
  @Input() formTask: FormGroup;

  constructor() {
   }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    var test = this.formTask;
  }


  get isValid() {
    debugger;
    var bRet = this.formTask.controls[this.question.key].valid;
    return bRet;
  }

}
