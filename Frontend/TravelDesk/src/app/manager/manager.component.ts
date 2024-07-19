import { Component,OnInit } from '@angular/core';
import { HttpClient,HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';
import { RequestServiceTsService } from '../request.service.ts.service';
import { RequestApprovalDto,RequestCommentsDto } from '../request.service.interface.ts.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrl: './manager.component.css'
})
export class ManagerComponent implements OnInit {
  assignedRequestIds: string[] = []; // Start with an empty array
  selectedRequestId: string | null = null;
  comments: string = '';
  apiUrl = 'http://localhost:5116/api/Manager'; // Replace with your actual backend URL

  constructor(private _reqservice:RequestServiceTsService) { }

  ngOnInit(): void {
    this.loadAssignedRequests();
  }
  loadAssignedRequests(): void {
    this._reqservice.getAssignedRequests().subscribe(data => this.assignedRequestIds = data);
  }

  approveRequest(requestId: string): void {
    const dto: RequestApprovalDto = { requestId, comments: this.comments };
    this._reqservice.approveRequest(dto).subscribe(() => {
      console.log(`Request ${requestId} approved with comments: ${this.comments}`);
      this.loadAssignedRequests(); // Refresh list after approval
    });
  }

  disapproveRequest(requestId: string): void {
    const dto: RequestApprovalDto = { requestId, comments: this.comments };
    this._reqservice.disapproveRequest(dto).subscribe(() => {
      console.log(`Request ${requestId} disapproved with comments: ${this.comments}`);
      this.loadAssignedRequests(); // Refresh list after disapproval
    });
  }

  returnRequest(requestId: string): void {
    const dto: RequestApprovalDto = { requestId, comments: this.comments };
    this._reqservice.returnRequest(dto).subscribe(() => {
      console.log(`Request ${requestId} returned with comments: ${this.comments}`);
      this.loadAssignedRequests(); // Refresh list after returning
    });
  }

  getRequestStatus(requestId: string): void {
    this._reqservice.getRequestStatus(requestId).subscribe(status => {
      console.log(`Request ${requestId} status: ${status}`);
    });
  }

  updateComments(requestId: string): void {
    const dto: RequestCommentsDto = { requestId, comments: this.comments };
    this._reqservice.updateComments(dto).subscribe(() => {
      console.log(`Comments updated for request ${requestId}: ${this.comments}`);
    });
  }
}
 

  


 