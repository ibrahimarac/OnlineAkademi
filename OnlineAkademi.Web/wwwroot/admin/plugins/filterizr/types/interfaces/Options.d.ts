import { BaseOptions } from './BaseOptions';
import ActiveFilter from '~/admin/ActiveFilter';
export interface Options extends BaseOptions {
    filter: ActiveFilter;
}
