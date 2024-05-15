import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor(
    private httpclient: HttpClient
  ) { }
  getAllEmployee(): Observable<any> {
    return this.httpclient.get(`http://localhost:5197/api/Employee`);

  }
  createemployee(id:string, firstName: string,
  lastName: string,
  email: string,
  phoneNumber: string,
  department: string,
  salary: string
):Observable<any>{
  return this.httpclient.post(`http://localhost:5197/api/Employee`,{id,firstName,
    lastName,
    phoneNumber,
    department,
    salary,
    email
  });
}

  editemployee(id:string, firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    department: string,
    salary: string
  ):Observable<any>{
    return this.httpclient.patch(`http://localhost:5197/api/Employee`,{ id,firstName,
      lastName,
      phoneNumber,
      department,
      salary,
      email
    });
    
  }

  deleteemployee(Id:string
  ):Observable<any>{
    return this.httpclient.delete(`http://localhost:5197/api/Employee/${Id}`);
    
  }


}

