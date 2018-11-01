import { TaskDisplay } from './taskdisplay';

export class ClientDisplay {
    constructor(
        public clientid?: number,
        public firstname?: string,
        public lastname?: string,
        public address?: string,
        public phonenumber?: string,
        public clienttasks?: TaskDisplay[]) {}
       
}