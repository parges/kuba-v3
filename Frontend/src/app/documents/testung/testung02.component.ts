import { Observable } from 'rxjs';
import { PatientAutocompleteDialog } from './../../utils/patient-external-dialog/patient-external-dialog.component';
import { MatDialog } from '@angular/material';
import { Customer } from './../../customer/customer';
import { FormControlService } from './../../utils/dynamic-forms/form-control.service';
import { FormGroup } from '@angular/forms';
import { FormBase } from './../../utils/dynamic-forms/form-base';
import { Component, OnInit, Input } from '@angular/core';
import { Testung } from 'src/app/models/testung';
import { timeoutWith } from 'rxjs/operators';

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

  constructor(private $formService: FormControlService, public dialog: MatDialog) {
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

        this.$formService.getTestungForPatient(this.selectedPatient.id).then((result) => {
          this.testung = result;
          this.questions = this.$formService.getFormEntries(this.testung)
          this.form = this.$formService.toFormGroup(this.questions);
        });
        // this.$formService.getChapters(this.selectedPatient.id).then((chapters) => {
        //     chapters.forEach(chapter => {
        //       this.$formService.getQuestionsForChapter(this.selectedPatient.id, chapter.id).then((questions) => {
        //         this.questionMap.set(chapter.id, questions);
        //         this.questions = this.$formService.getQuestions(this.questionMap)
        //         this.form = this.$formService.toFormGroup(this.questions);
        //       })
        //     });

        // })
        // .finally(() => {

        //  });
        // this.$formService.getTestungFor(this.selectedPatient.id).then((result)=> {
        //   this.questionsChapterOne = this.$formService.getQuestionsChapterOne(result);
        //   // this.questionsChapterTwo = this.$formService.getQuestionsChapterTwo();
        // })

        // // Calculate the age
        // const timeDiff = Math.abs(Date.now() - new Date(this.activeCustomer.birthday).getTime());
        // const age = Math.floor((timeDiff / (1000 * 3600 * 24)) / 365.25);
        // // To initialize FormGroup
        // this.docUebersicht.setValue({
        //   id: this.activeCustomer.id,
        //   firstname: this.activeCustomer.firstname,
        //   lastname: this.activeCustomer.lastname,
        //   tele: this.activeCustomer.tele,
        //   birthday: this.activeCustomer.birthday ? this.activeCustomer.birthday : '',
        //   address: this.activeCustomer.address,
        //   anamneseDate: this.activeCustomer.anamneseDate,
        //   anamnesePayed: this.activeCustomer.anamnesePayed,
        //   diagnostikDate: this.activeCustomer.diagnostikDate,
        //   diagnostikPayed: this.activeCustomer.diagnostikPayed,
        //   elternDate: this.activeCustomer.elternDate,
        //   elternPayed: this.activeCustomer.elternPayed,
        //   problemHierarchy: this.activeCustomer.problemHierarchy,
        //   reviews: this.fillReviews()
          // reviews: this.fb.array([
          //   this.initReviews(),
          //   this.initReviews()
          // ])
          // });


      }
      });
  }

  onSubmit() {
    debugger;
    this.payLoad = JSON.stringify(this.form.value);
    // this.enableControlStates(true);
    const result: Customer = Object.assign({}, this.form.value);
    // this.$customer.updateCustomer(result).catch(
    //   err => console.error(err)
    // ).finally(() => {
    //   this.snackbar.openSnackBar('Gespeichert');
    //   this.enableControlStates(false);
    //   // this.$router.navigate(['customers']);
    // });
  }

}
