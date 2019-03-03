import { CustomerService } from './../../customer/customer.service';
import { Observable, merge } from 'rxjs';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { Component, AfterViewInit, Inject, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UebersichtModel } from './ubersichtModel';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Customer } from 'src/app/customer/customer';
import { startWith, switchMap, map } from 'rxjs/operators';

export interface DialogData {
  patient: Customer;
}

@Component({
  selector: 'app-uebersicht00',
  templateUrl: './uebersicht00.component.html',
  styleUrls: ['./uebersicht00.component.scss']
})
export class Uebersicht00Component implements AfterViewInit{


  docUebersicht: FormGroup;
  formModel: UebersichtModel;
  selectedPatient: Customer;
  patients: Customer[];
  activeCustomer: Customer;

  constructor(private $customer: CustomerService, private fb: FormBuilder, public dialog: MatDialog) {
    this.docUebersicht = this.fb.group({
      'id' : [''],
      'firstname' : ['', Validators.required],
      'lastname' : ['', Validators.required],
      'tele' : ['', Validators.required],
      'birthday' : [''],
      'address' : [''],
      'reviews' : this.fb.array([
        this.initReviews(),
        this.initReviews()
      ])
    });

    this.openDialog();
   }

   ngAfterViewInit() {

   }


   openDialog(): void {
    const dialogRef = this.dialog.open(DialogExampleDialog, {
      width: '250px',
      data: {patient: this.selectedPatient}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.activeCustomer = dialogRef.componentInstance.selectedPatient;
      // Calculate the age
      const timeDiff = Math.abs(Date.now() - new Date(this.activeCustomer.birthday).getTime());
      const age = Math.floor((timeDiff / (1000 * 3600 * 24)) / 365.25);
      // To initialize FormGroup
      this.docUebersicht.setValue({
        id: this.activeCustomer.id,
        firstname: this.activeCustomer.firstname,
        lastname: this.activeCustomer.lastname,
        tele: this.activeCustomer.tele,
        birthday: this.activeCustomer.birthday,
        address: 'Max Mustermann Straße',
        reviews: this.fb.array([
          this.initReviews(),
          this.initReviews()
        ])
        });
      });
    }

  initReviews() {
    // initialize our address
    return this.fb.group({
        name: ['Anfangsübung'],
        date: [''],
        payed: [''],
        exercises: ['Übungen'],
        reasons: ['BEgründungen']
    });
  }
  addReview() {
    // add address to the list
    const control = <FormArray>this.docUebersicht.controls['reviews'];
    control.push(this.initReviews());
  }
  removeReview(i: number) {
    // remove address from the list
    const control = <FormArray>this.docUebersicht.controls['reviews'];
    control.removeAt(i);
  }



  onDocSubmit() {
    // const result: Customer = Object.assign({}, this.addCustForm.value);
    // this.$customer.addCustomer(result).catch(
    //   err => console.error(err)
    // ).finally(() => {
    //   this.$router.navigate(['customers']);
    // });

  }

}
@Component({
  selector: 'dialog-example-dialog',
  templateUrl: 'dialog-example-dialog.html',
})
export class DialogExampleDialog {

  myControl = new FormControl();
  filteredPatients: Observable<Customer[]>;
  patients: Customer[];
  selectedPatientId: number;

  selectedPatient: Customer;

  constructor(private $customer: CustomerService,
    public dialogRef: MatDialogRef<DialogExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {

      merge()
        .pipe(
          startWith({}),
        switchMap(() => {
          return this.$customer.getAllUsers();
        })
        ).subscribe(resp => {
          this.patients = resp;
          this.filteredPatients = this.myControl.valueChanges
          .pipe(
            startWith(''),
            map(patient => patient ? this._filterPatients(patient) : this.patients.slice())
          );
        });

    }

    public _filterPatients(value: string): Customer[] {
      const filterValue = value;
      // .toLowerCase();
      return this.patients.filter(patient => patient.firstname.toLowerCase().indexOf(filterValue) === 0);
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public getDisplayFn() {
    return (val) => this.display(val);
  }
  public display(item: Customer): string {
      if (item) {
        return item.firstname + ' ' + item.lastname;
      }
  }
  selectionChange(customer) {
    this.selectedPatient = customer;
    this.dialogRef.close();
   }

}
