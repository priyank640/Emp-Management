import { Component, OnInit } from '@angular/core';
import { SharedService } from './shared.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] // Change 'styleUrl' to 'styleUrls'
})
export class AppComponent implements OnInit {

  allEmployee: any[] = [];
  visible: boolean = false;
  editvisible: boolean = false;
  deletevisible: boolean = false;
  EmployeeCreationForm!: FormGroup;
  EmployeeEditForm!: FormGroup


  constructor(private sharedService: SharedService, private formbuild: FormBuilder) { }

  ngOnInit(): void {
    this.getAllEmployee();
    this.EmployeeCreationForm = this.formbuild.group({
      firstname: ["", Validators.required],
      id: ["", Validators.required],
      lastname: ["", Validators.required],

      department: ["", Validators.required],
      salary: ["", Validators.required],
      phoneNumber: ["", Validators.required],
      email: [
        "",
        [
          Validators.required,
          Validators.pattern(/^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/),
        ],
      ]

    });




    this.EmployeeEditForm = this.formbuild.group({
      id: ["", Validators.required],
      firstname: ["", Validators.required],
      lastname: ["", Validators.required],
      department: ["", Validators.required],
      salary: ["", Validators.required],
      phoneNumber: ["", Validators.required],
      email: [
        "",
        [
          Validators.required,
          Validators.pattern(/^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/),
        ],
      ]
    });
  }



  getAllEmployee() {
    this.sharedService.getAllEmployee().subscribe((res) => {
      this.allEmployee = res;
      console.log(this.allEmployee);
    });
  }
  showDialog() {
    this.visible = true;
  }
  showEditDialog(emp: any) {
    this.editvisible = true;
    this.EmployeeEditForm.patchValue({
      id: emp.id,
      firstname: emp.firstName,
      lastname: emp.lastName,
      department: emp.department,
      email: emp.email,
      salary: emp.salary,
      phoneNumber: emp.phoneNumber
    });
  }

  showDeleteDialog(emp: any) {
    this.deletevisible = true;
    this.EmployeeEditForm.patchValue({
      id: emp.id,
      firstname: emp.firstName,
      email: emp.email

    });

  }
  createemp() {
    console.log(this.EmployeeCreationForm.value)
    const payload = {
      id: this.EmployeeCreationForm.value.id,
      firstname: this.EmployeeCreationForm.value.firstname,
      lastname: this.EmployeeCreationForm.value.lastname,
      department: this.EmployeeCreationForm.value.department,
      email: this.EmployeeCreationForm.value.email,
      salary: this.EmployeeCreationForm.value.salary.toString(),
      phoneNumber: this.EmployeeCreationForm.value.phoneNumber,
    };
    this.sharedService.createemployee(payload.id, payload.firstname,
      payload.lastname,
      payload.email,
      payload.phoneNumber,
      payload.department,
      payload.salary).subscribe((res) => {
        console.log(res);
        this.visible = false;
        this.getAllEmployee();
      })
  }



  editemp() {
    console.log(this.EmployeeEditForm.value)
    const payload = {
      id: this.EmployeeEditForm.value.id,
      firstname: this.EmployeeEditForm.value.firstname,
      lastname: this.EmployeeEditForm.value.lastname,
      department: this.EmployeeEditForm.value.department,
      email: this.EmployeeEditForm.value.email,
      salary: this.EmployeeEditForm.value.salary.toString(),
      phoneNumber: this.EmployeeEditForm.value.phoneNumber,
    };
    this.sharedService.editemployee(payload.id, payload.firstname,
      payload.lastname,
      payload.email,
      payload.phoneNumber,
      payload.department,
      payload.salary).subscribe((res) => {
        console.log(res);
        this.editvisible = false;
        this.getAllEmployee();

      })
  }
  deleteemp() {
    const payload = {
      id: this.EmployeeEditForm.value.id.toString()

    };
    this.sharedService.deleteemployee(payload.id).subscribe((res) => {
      console.log(res);
      this.getAllEmployee();
      this.deletevisible = false;
    })
 }

}
