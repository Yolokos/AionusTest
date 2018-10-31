import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Client } from './client';
import { Task } from './task';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})

export class AppComponent implements OnInit {
    client: Client = new Client();   // изменяемый товар
    clients: Client[];                // массив товаров
    tasks: Task[];
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadClients();    // загрузка данных при старте компонента  
    }

    loadClients() {
        this.dataService.getClients()
            .subscribe((data: Client[]) => this.clients = data);
    }

    delete(p: Task) {
        this.dataService.deleteTask(p.taskid)
            .subscribe(data => this.loadClients());
    }
}