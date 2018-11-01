import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientDisplay } from './clientdisplay';

@Injectable()
export class DataService {
    private url = "/api/clients";

    constructor(private http: HttpClient) {
    }

    getClients() {
        return this.http.get(this.url);
    }

    //deleteTask(id: number) {
    //    return this.http.delete(this.url + '/' + id);
    //}
}