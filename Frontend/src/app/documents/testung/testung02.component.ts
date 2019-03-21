import { SnackbarGenericComponent } from './../../utils/snackbar-generic/snackbar-generic.component';
import { LoaderService } from './../../../../libs/shared/ui/services/loader.service';
import { map } from 'rxjs/operators';
import { ApiResponse } from './../../../../libs/shared/models/src/lib/interfaces/interfaces.common';
import { ApiService } from './../../../../libs/shared/api/src/lib/services/api.service';
import { PatientAutocompleteDialog } from './../../utils/patient-external-dialog/patient-external-dialog.component';
import { MatDialog } from '@angular/material';
import { Customer } from './../../customer/customer';
import { FormControlService } from './../../utils/dynamic-forms/form-control.service';
import { FormGroup } from '@angular/forms';
import { FormBase } from './../../utils/dynamic-forms/form-base';
import { Component, OnInit, Input } from '@angular/core';
import { Testung } from 'src/app/models/testung';

@Component({
  selector: 'app-testung02',
  templateUrl: './testung02.component.html',
  styleUrls: ['./testung02.component.scss'],
  providers: [ FormControlService ]

})
export class Testung02Component implements OnInit {

  questions: FormBase<any>[] = [];
  // questionMap: Map<number, TestungDetails[]> = new Map<number, TestungDetails[]>();
  form: FormGroup;
  payLoad = '';
  selectedPatient: Customer;

  testung: Testung = new Testung();

  private resource = `testung`;

  constructor(private $formService: FormControlService, private api: ApiService, public dialog: MatDialog, private loader: LoaderService,
    private snackbar: SnackbarGenericComponent) {
  }

  ngOnInit() {
    this.openDialog();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(PatientAutocompleteDialog, {
      width: '250px',
      data: {patient: this.selectedPatient}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(dialogRef.componentInstance.selectedPatient)
      {
        this.selectedPatient = dialogRef.componentInstance.selectedPatient;
        this.api.getById<Testung>(this.resource, this.selectedPatient.id)
        .pipe(
          map((data: ApiResponse<Testung>) => {
            this.loader.hideSpinner();
            this.testung = data.items[0];
          })
        ).subscribe(() => {
          this.questions = this.$formService.getFormEntries(this.testung);
          this.form = this.$formService.toFormGroup(this.questions);
        });
      }
      });
  }

  onSubmit() {

    // this.payLoad = JSON.stringify(this.form.value);
    // this.enableControlStates(true);
    const result: Customer = Object.assign({}, this.form.value);
    var index = 1;
    this.testung.chapters.forEach(chapter => {
      chapter.questions.forEach(question => {
        question.value = this.form.value["question_" + index];
        index++;
      })
    });
    this.api.put<Testung>(this.resource, this.selectedPatient.id, this.testung)
    .pipe(
      map((data: ApiResponse<Testung>) => {
        this.loader.hideSpinner();
        this.testung = data[0];
      })
    ).subscribe(() => {
      this.snackbar.openSnackBar('Gespeichert');
    });
  }

}
