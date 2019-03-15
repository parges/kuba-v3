import { CustomerService } from './../../customer/customer.service';
import { Observable, merge } from 'rxjs';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { Component, AfterViewInit, Inject, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UebersichtModel } from './ubersichtModel';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Customer } from 'src/app/customer/customer';
import { startWith, switchMap, map } from 'rxjs/operators';
import { SnackbarGenericComponent } from 'src/app/utils/snackbar-generic/snackbar-generic.component';
import { isString, isObject } from 'util';

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

  isDisabled: boolean = true;
  disabledColumns: string[] = ['firstname','lastname', 'tele', 'address', 'birthday']


  constructor(private $customer: CustomerService, private fb: FormBuilder, public dialog: MatDialog, public snackbar: SnackbarGenericComponent) {
    this.docUebersicht = this.fb.group({
      id : [''],
      firstname : ['', Validators.required],
      lastname : ['', Validators.required],
      tele : ['', Validators.required],
      birthday : [''],
      address : [''],
      anamneseDate: [''],
      anamnesePayed: [''],
      diagnostikDate: [''],
      diagnostikPayed: [''],
      elternDate: [''],
      elternPayed: [''],
      problemHierarchy: [''],
      reviews : this.fb.array([])
    });
    
    this.enableControlStates(false);

    this.openDialog();
   }

   ngAfterViewInit() {
    
   }

   enableControlStates(enable: boolean) {
    if(enable){
      Object.keys(this.docUebersicht.controls).forEach(key => {
        if(this.disabledColumns.indexOf(key) != -1){
          this.docUebersicht.get(key).enable();
        }
      });
    } else {
      
      Object.keys(this.docUebersicht.controls).forEach(key => {
        if(this.disabledColumns.indexOf(key) != -1){
          this.docUebersicht.get(key).disable();
        }
      });
    }
    
   }

   openDialog(): void {
    const dialogRef = this.dialog.open(DialogExampleDialog, {
      width: '250px',
      data: {patient: this.selectedPatient}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(dialogRef.componentInstance.selectedPatient) 
      {
        this.isDisabled = false;

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
          birthday: this.activeCustomer.birthday ? this.activeCustomer.birthday : '',
          address: this.activeCustomer.address,
          anamneseDate: this.activeCustomer.anamneseDate,
          anamnesePayed: this.activeCustomer.anamnesePayed,
          diagnostikDate: this.activeCustomer.diagnostikDate,
          diagnostikPayed: this.activeCustomer.diagnostikPayed,
          elternDate: this.activeCustomer.elternDate,
          elternPayed: this.activeCustomer.elternPayed,
          problemHierarchy: this.activeCustomer.problemHierarchy,
          reviews: this.fillReviews()
          // reviews: this.fb.array([
          //   this.initReviews(),
          //   this.initReviews()
          // ])
          });

          
      }
    });
    }
  fillReviews(): FormGroup {
    let reviews = this.docUebersicht.get('reviews') as FormArray;
    if(this.activeCustomer.reviews.length > 0){
      
      this.activeCustomer.reviews.forEach(review => {
        reviews.push(
        this.fb.group({
          name: review.name,
          date: review.date,
          payed: review.payed,
          exercises: review.exercises,
          reasons: review.reasons
        })
        );
      });
     
    }
    // initialize our address
    return this.fb.group({
        name: ['Anfangsübung'],
        date: [''],
        payed: [''],
        exercises: ['Übungen'],
        reasons: ['BEgründungen']
    });
  }
  initReviews() {
    // initialize our address
    return this.fb.group({
        name: ['neuer Eintrag'],
        date: [''],
        payed: [false],
        exercises: [''],
        reasons: ['']
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
    this.enableControlStates(true);
    const result: Customer = Object.assign({}, this.docUebersicht.value);
    this.$customer.updateCustomer(result).catch(
      err => console.error(err)
    ).finally(() => {
      this.snackbar.openSnackBar('Gespeichert');
      this.enableControlStates(false);
      // this.$router.navigate(['customers']);
    });

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

    public _filterPatients(value: any): Customer[] {
      if (isString(value)) {
        const filteredValue = value.toLowerCase();
        return this.patients.filter(patient => patient.firstname.toLowerCase().indexOf(filteredValue) === 0 || patient.lastname.toLowerCase().indexOf(filteredValue)  === 0 );
      } else if(isObject(value)){
        const filterValueFirstname = value.firstname.toLowerCase();
        const filterValueLastname = value.lastname.toLowerCase();
        return this.patients.filter(patient => patient.firstname.toLowerCase().indexOf(filterValueFirstname) === 0 || patient.lastname.toLowerCase().indexOf(filterValueLastname)  === 0 );
      } 
      else {
        return this.patients;
      }
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
