import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home.component'
import { UserGridComponent } from './components/user/user-grid/user-grid.component';

const appRoutes: Routes = [    
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'user', component: UserGridComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);