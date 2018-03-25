import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';

import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { FormsModule } from '@angular/forms';

// Animation and Materials
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule, MdNativeDateModule } from '@angular/material';

// Services
import { DataService } from './services/data.service'
import { UserSessionService } from './services/userSession.service'

// Index page
import { HomeComponent } from './components/home.component'

// User Components
import { UserGridComponent } from './components/user/user-grid/user-grid.component';
import { UserLoginComponent } from './components/user/user-login/user-login.component';
import { UserRegisterComponent } from './components/user/user-register/user-register.component';

@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule, 
        MaterialModule, 
        MdNativeDateModule, 
        ReactiveFormsModule, 
        HttpModule, 
        routing, 
        Ng2Bs3ModalModule, 
        FormsModule
    ],

    declarations: [
        AppComponent,
        HomeComponent,
        UserGridComponent,
        UserLoginComponent,
        UserRegisterComponent
    ],

    providers: [{ provide: APP_BASE_HREF, useValue: '/' }, DataService, UserSessionService],
    bootstrap: [AppComponent]
})

export class AppModule { }