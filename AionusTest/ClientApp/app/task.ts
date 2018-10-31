export class Task {
    constructor(
        public taskid?: number,
        public taskname?: string,
        public clientaddress?: string,
        public starttime?: string,
        public endtime?: string,
        public clientid?: number) { }
}