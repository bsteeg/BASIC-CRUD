import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

// Data Services
import { DataService } from '../../../services/data.service';

// Data structures
import { IUser } from '../../../models/user';
import { Global } from '../../../shared/global';

// Angular material modules
import { MdSnackBar, MdDialogModule } from '@angular/material';

@Component({
    selector: 'user-register',
    templateUrl: 'app/components/user/user-register/user-register.component.html'
})

@Injectable()
export class UserRegisterComponent implements OnInit {
    name: string;
    surname: string;
    username: string;
    email: string;
    age: number;
    password: string;
    password_sec: string;

    constructor(private _router: Router,
        private _dataService: DataService,
        private _snackBar: MdSnackBar) { }

    ngOnInit(): void {

    }

    Register(): void {
        var userRegister: IUser = {
            Username: this.username,
            Password: this.password,
            Age: this.age,
            Email: this.email,
            Id: 0,
            Name: this.name,
            Surname: this.surname
        }


        this._dataService.post(Global.BASE_USER_ENDPOINT + "Create", userRegister).subscribe(
            data => {
                if (data != null && data == true) {
                    this._snackBar.open("The account has been created!", null, {
                        duration: 2000
                    });
                } else {
                    this._snackBar.open("Something went wrong, try again....", null, {
                        duration: 2000
                    });
                }
                location.reload();
            },
            error => {

            }
        );
    }
}