import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TestMeResponse } from '../dtos/TestMeResponse';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private httpClient: HttpClient) { }

  public async testMe(): Promise<TestMeResponse> {
    return this.httpClient.get<TestMeResponse>(
      'https://localhost:44347/Planning/Test').toPromise();
  }
}
