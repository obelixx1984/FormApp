import { Routes } from '@angular/router';
import { PanelComponent } from './panel/panel.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: LogowanieComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'panel', component: PanelComponent},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
