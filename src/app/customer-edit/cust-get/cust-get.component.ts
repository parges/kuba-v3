import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { CustomerService } from './../../customer/customer.service';
import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/customer/customer';

import { MAT_DATE_LOCALE} from '@angular/material/core';
import { BreakpointObserver } from '@angular/cdk/layout';


@Component({
  selector: 'app-cust-get',
  templateUrl: './cust-get.component.html',
  styleUrls: ['./cust-get.component.scss'],
  providers: [
    // The locale would typically be provided on the root module of your application. We do it at
    // the component level here, due to limitations of our example generation script.
    {provide: MAT_DATE_LOCALE, useValue: 'de-DE'},

  ],
})
export class CustGetComponent implements OnInit, OnDestroy {
  id: number;
  private sub: any;
  activeCustomer: Customer;
  tempCustomer: Customer;

  regiForm: FormGroup;
  formBuilder: FormBuilder;
  selectedFile: File;

  imageToShow: any;
  isImageLoading: boolean;

  @ViewChild("uploader") uploader: any;

  constructor(private route: ActivatedRoute, private $router: Router, private $customer: CustomerService, private fb: FormBuilder) {
    this.formBuilder = fb;
    this.regiForm = this.formBuilder.group({
      'id' : [''],
      'firstname' : ['', Validators.required],
      'lastname' : ['', Validators.required],
      'tele' : ['', Validators.required],
      'birthday' : [''],
      'age' : [],
      'avatar' : []
    });
   }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      // In a real app: dispatch action to load the details here.
      this.$customer.getCustomerByID(this.id)
      .then(cust => {
        this.activeCustomer = cust;
        // Calculate the age
        const timeDiff = Math.abs(Date.now() - new Date(this.activeCustomer.birthday).getTime());
        const age = Math.floor((timeDiff / (1000 * 3600 * 24)) / 365.25);
        // To initialize FormGroup
        this.regiForm.setValue({
          id: this.activeCustomer.id,
          firstname: this.activeCustomer.firstname,
          lastname: this.activeCustomer.lastname,
          tele: this.activeCustomer.tele,
          birthday: this.activeCustomer.birthday,
          age: age,
          avatar: this.activeCustomer.avatar
        });
      })
      .then(cust => {
        this.isImageLoading = true;

        this.$customer.getImageByFilename(this.activeCustomer.id).subscribe(data => {
          this.createImageFromBlob(data);
          this.isImageLoading = false;
        }, error => {
          this.isImageLoading = false;
          console.log(error);
        });
      });
     });

  }


  createImageFromBlob(image: Blob) {
     let reader = new FileReader();
     reader.addEventListener("load", () => {
        this.imageToShow = reader.result;
     }, false);

     if (image) {
        reader.readAsDataURL(image);
     }
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  fileChange(files: FileList) {
      if (files && files[0].size > 0) {
        this.regiForm.patchValue({
          avatar: files[0]
        });
      }
  }

  private prepareSave(): any {
    let formData = new FormData();

    // This can be done a lot prettier; for example automatically assigning values by looping through `this.form.controls`, but we'll keep it as simple as possible here
    formData.append('id', this.regiForm.get('id').value);
    formData.append('firstname', this.regiForm.get('firstname').value);
    formData.append('lastname', this.regiForm.get('lastname').value);
    formData.append('tele', this.regiForm.get('tele').value);
    formData.append('age', this.regiForm.get('age').value);
    formData.append('birthday', this.regiForm.get('birthday').value);
    formData.append('avatar', this.regiForm.get('avatar').value);

    return formData;
  }

  onSubmit() {
    // this.loading = true;
    // In a real-world app you'd have a http request / service call here like
    // this.http.post('apiUrl', formModel)
    const formModel = this.prepareSave();
    // const result: Customer = Object.assign({}, this.regiForm.value);
       this.$customer.updateCustomerFormData(formModel);//.then(customer => {
    //     this.activeCustomer = customer;
    // })

  }


  // // Executed When Form Is Submitted
  // onFormSubmit() {
  //   // Make sure to create a deep copy of the form-model
  //   const result: Customer = Object.assign({}, this.regiForm.value);
  //   this.$customer.updateCustomer(result).then(customer => {
  //       this.activeCustomer = customer;
  //   }).finally(() => {
  //     this.$router.navigate(['customers']);
  //   });

  // }

  // Executed When Form Is Submitted
  onDeleteCustomer() {
    // Make sure to create a deep copy of the form-model
    const result: Customer = Object.assign({}, this.regiForm.value);
    this.$customer.delCustomer(result).finally(() => {
      this.$router.navigate(['customers']);
    });
  }

  /**
   * Uploading the customer picture
   */
  // onFileChanged(event) {
  //   this.selectedFile = event.target.files[0];
  //   this.$customer.uploadImage(this.selectedFile);
  // }

}
