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
// Angular
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var core_2 = require("@angular/core");
// Data Services
var data_service_1 = require("../../../services/data.service");
var userSession_service_1 = require("../../../services/userSession.service");
var global_1 = require("../../../shared/global");
// Angular material modules
var material_1 = require("@angular/material");
var UserLoginComponent = (function () {
    function UserLoginComponent(_router, _dataService, _userSessionService, _snackBar) {
        this._router = _router;
        this._dataService = _dataService;
        this._userSessionService = _userSessionService;
        this._snackBar = _snackBar;
    }
    UserLoginComponent.prototype.ngOnInit = function () {
        this.username = "";
        this.password = "";
        this.showErrorMessage = false;
        this.errorMessage = "";
    };
    UserLoginComponent.prototype.Inloggen = function () {
        var _this = this;
        var userLoginData = {
            Username: this.username,
            Password: this.password,
            Age: 0,
            Email: "",
            Id: 0,
            Name: "",
            Surname: ""
        };
        this._dataService.post(global_1.Global.BASE_USER_ENDPOINT + "Verify", userLoginData).subscribe(function (data) {
            if (data != null) {
                _this._userSessionService.saveUserToken(data.Token);
            }
            else {
                _this._snackBar.open("Username or password is incorrect, try again ...", null, {
                    duration: 2000
                });
                _this.username = "";
                _this.password = "";
            }
            location.reload();
        }, function (error) {
        });
    };
    return UserLoginComponent;
}());
UserLoginComponent = __decorate([
    core_1.Component({
        selector: 'user-login',
        templateUrl: 'app/components/user/user-login/user-login.component.html'
    }),
    core_2.Injectable(),
    __metadata("design:paramtypes", [router_1.Router,
        data_service_1.DataService,
        userSession_service_1.UserSessionService,
        material_1.MdSnackBar])
], UserLoginComponent);
exports.UserLoginComponent = UserLoginComponent;
//# sourceMappingURL=user-login.component.js.map