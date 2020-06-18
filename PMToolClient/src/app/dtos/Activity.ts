export interface Activity {
    id: number;
    taskName: string;
    estimate: number;
    predecessors: string;
    resource: string;
    priority: number;
    start: Date;
    finish: Date;
    projectId: number;
}
