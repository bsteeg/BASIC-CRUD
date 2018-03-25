import { Component, OnInit } from "@angular/core";
import { Global } from '../shared/global';
import { CommonModule } from '@angular/common';
import { UserSessionService } from '../services/userSession.service';

@Component({
    selector: "home-component",
    templateUrl: 'app/components/home.component.html'
})


export class HomeComponent implements OnInit {
    isLoggedIn: boolean = false;

    constructor(private _userSessionService: UserSessionService) { }

    ngOnInit(): void {
        var token = this._userSessionService.getUserToken();

        // If there is a token, then the user can see the webapplication otherwise not. (add verify token with server)
        if (token != null) {
            this.isLoggedIn = true;
        }
    }
}