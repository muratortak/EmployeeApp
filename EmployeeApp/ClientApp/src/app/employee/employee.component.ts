import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {
  public employees: EmployeeViewModel[];
  public selectedEmployee?: EmployeeViewModel;
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.selectedEmployee = new EmployeeViewModel();
    this.http = http;
    this.baseUrl = baseUrl;
    this.getEmployee();
  }
    ngOnInit(): void {
    }

  getEmployee() {
    this.http.get<EmployeeViewModel[]>(this.baseUrl + 'Employee/GetEmp').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }

  onSelect(emp: EmployeeViewModel): void {
    this.selectedEmployee = emp;
  }

  onAddNew(): void {

    this.selectedEmployee = new EmployeeViewModel();
  }

  saveEmployee() {
    // Validation can be added.
    this.selectedEmployee.employeeID = 0;
    return this.http.post<EmployeeViewModel>(this.baseUrl + "Employee/Add", this.selectedEmployee, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    }).subscribe(result => {
      this.selectedEmployee = result
      this.getEmployee();
    });
  }
}

class EmployeeViewModel {
  employeeID: number;
  fullName: string;
  address: string;
  phoneNumber: string;
  positionID: number;
  positionName: string;
}
