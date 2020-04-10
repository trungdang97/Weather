import { InjectionToken } from "@angular/core";
import { MatDialogConfig, MatDialog } from '@angular/material';
import { throwError } from 'rxjs/internal/observable/throwError';
import { ConfirmDialogComponent } from './_layout/confirm-dialog/confirm-dialog.component';

export let APP_CONFIG = new InjectionToken("app.config");

export interface IAppConfig {
    apiEndpoint: string;
}

export const AppConfig: IAppConfig = {
    apiEndpoint: "https://localhost:8587/"
};

export const DemoUserId: string = "EEDB73DA-A008-4140-A8A4-237D32BEEFC0";