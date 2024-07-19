import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


export interface RequestApprovalDto {
  requestId: string;
  comments: string;
}

export interface RequestCommentsDto {
  requestId: string;
  comments: string;
}
export interface RequestServiceInterfaceTsService {

  getAssignedRequests(): Observable<string[]>;
  approveRequest(dto: RequestApprovalDto): Observable<void>;
  disapproveRequest(dto: RequestApprovalDto): Observable<void>;
  returnRequest(dto: RequestApprovalDto): Observable<void>;
  getRequestStatus(requestId: string): Observable<string>;
  updateComments(dto: RequestCommentsDto): Observable<void>;
}
