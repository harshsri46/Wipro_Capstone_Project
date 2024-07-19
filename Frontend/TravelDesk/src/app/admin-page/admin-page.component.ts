import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { UserDTO } from '../user.dto';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrl: './admin-page.component.css'
})
export class AdminPageComponent {
  

 

 /* ngOnInit(): void {
    this.loadUsers();
  }
  /*loadUsers(): void {
    
       this.userService.getUser("id").subscribe({
          next: (data: UserDTO[]) => {
            this.users = data;
      },
      error: (error: HttpErrorResponse) => {
        console.error('Error fetching user data', error.message);
      }
    };*/
  
}

     