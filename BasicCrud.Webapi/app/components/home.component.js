"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var userSession_service_1 = require("../services/userSession.service");
var HomeComponent = (function () {
    function HomeComponent(_userSessionService) {
        this._userSessionService = _userSessionService;
        this.isLoggedIn = false;
    }
    HomeComponent.prototype.ngOnInit = function () {
        var token = this._userSessionService.getUserToken();
        // If there is a token, then the user can see the webapplication otherwise not. (add verify token with server)
        if (token != null) {
            this.isLoggedIn = true;
        }
    };
    return HomeComponent;
}());
HomeComponent = __decorate([
    core_1.Component({
        selector: "home-component",
        templateUrl: 'app/components/home.component.html'
    }),
    __metadata("design:paramtypes", [userSession_service_1.UserSessionService])
], HomeComponent);
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map