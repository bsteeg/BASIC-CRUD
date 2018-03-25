// Angular
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

// Data Services
import { DataService } from '../../../services/data.service';
import { UserSessionService } from '../../../services/userSession.service';

// Data structures
import { IUser } from '../../../models/user';
import { Global } from '../../../shared/global';

// Angular material modules
import { MdSnackBar, MdDialogModule } from '@angular/material';


@Component({
    selector: 'user-login',
    templateUrl: 'app/components/user/user-login/user-login.component.html'
})

@Injectable()
export class UserLoginComponent implements OnInit {
    username: string;
    password: string;

    showErrorMessage: boolean;
    errorMessage: string;

    constructor(private _router: Router,
        private _dataService: DataService,
        private _userSessionService: UserSessionService,
        private _snackBar: MdSnackBar) { }

    ngOnInit(): void {
        this.username = "";
        this.password = "";
        this.showErrorMessage = false;
        this.errorMessage = "";
    }

    Inloggen(): void {
        var userLoginData: IUser = {
            Username: this.username,
            Password: this.password,
            Age: 0,
            Email: "",
            Id: 0,
            Name: "",
            Surname: ""
        }
        
        this._dataService.post(Global.BASE_USER_ENDPOINT + "Verify", userLoginData).subscribe(
            data => {
                if (data != null) {
                    this._userSessionService.saveUserToken(data.Token);
                } else {
                    this._snackBar.open("Username or password is incorrect, try again ...", null, {
                        duration: 2000
                    });
                    this.username = "";
                    this.password = "";
                }
                location.reload();
            },
            error => {
                 
            }
        );
    }
}