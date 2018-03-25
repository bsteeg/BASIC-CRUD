import { Injectable } from '@angular/core';

@Injectable()
export class UserSessionService {

    constructor() { }

    // Get the current user stored in the localStorage
    getUserToken(): string {
         return localStorage.getItem('currentUser');
    }

    // Remove session
    removeUserToken(): void {
        localStorage.clear();
    }

    // Save a token in the local storage
    saveUserToken(token: string) {
        if (token != null || token != "") {
            localStorage.setItem("currentUser", token);
        }
    }
}