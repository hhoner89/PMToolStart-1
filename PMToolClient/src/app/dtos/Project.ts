import './Activity';
import { Activity } from './Activity';

export interface Project {
    id: number;
    name: string;
    startDate: Date;
    activities: Activity[];
}
