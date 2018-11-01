import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { ClientDisplay } from './clientdisplay';
import { TaskDisplay } from './taskdisplay';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {
    client: ClientDisplay = new ClientDisplay();   // изменяемый клиент
    clients: ClientDisplay[];                // массив клиентов
    tasks: TaskDisplay[];
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadClients();    // загрузка данных при старте компонента  
        //this.loadTasks();
    }

    loadClients() {
        this.dataService.getClients()
            .subscribe(( data: ClientDisplay[]) => this.clients = data);
    }
    //loadTasks() {
    //    this.dataService.getClients()
    //        .subscribe((data: TaskDisplay[]) => this.tasks = data);
    //}
    //loadTask() {
    //    this.dataService.getClientsAndTasks()
    //        .subscribe((dataTask: TaskDisplay[]) => this.tasks = dataTask);;
    //}

    //delete(t: TaskDisplay) {
    //    this.dataService.deleteTask(t.taskid)
    //        .subscribe(data => this.loadClients());
    //}
}