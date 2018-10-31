import { Task } from "./task";

export class Client {
    constructor(
        public clientid?: number,
        public firstname?: string,
        public lastname?: string,
        public address?: string,
        public phonenumber?: string,
        public clienttasks?: Task[]) { }
}