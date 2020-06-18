export interface Activity {
    id: number;
    taskName: string;
    estimate: number;
    predecessor: number;
    resource: string;
    priority: number;
    start: Date;
    finish: Date;
    projectId: number;
}
