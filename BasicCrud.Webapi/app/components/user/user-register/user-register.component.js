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
var core_2 = require("@angular/core");
var router_1 = require("@angular/router");
// Data Services
var data_service_1 = require("../../../services/data.service");
var global_1 = require("../../../shared/global");
// Angular material modules
var material_1 = require("@angular/material");
var UserRegisterComponent = (function () {
    function UserRegisterComponent(_router, _dataService, _snackBar) {
        this._router = _router;
        this._dataService = _dataService;
        this._snackBar = _snackBar;
    }
    UserRegisterComponent.prototype.ngOnInit = function () {
    };
    UserRegisterComponent.prototype.Register = function () {
        var _this = this;
        var userRegister = {
            Username: this.username,
            Password: this.password,
            Age: this.age,
            Email: this.email,
            Id: 0,
            Name: this.name,
            Surname: this.surname
        };
        this._dataService.post(global_1.Global.BASE_USER_ENDPOINT + "Create", userRegister).subscribe(function (data) {
            if (data != null && data == true) {
                _this._snackBar.open("The account has been created!", null, {
                    duration: 2000
                });
            }
            else {
                _this._snackBar.open("Something went wrong, try again....", null, {
                    duration: 2000
                });
            }
            location.reload();
        }, function (error) {
        });
    };
    return UserRegisterComponent;
}());
UserRegisterComponent = __decorate([
    core_1.Component({
        selector: 'user-register',
        templateUrl: 'app/components/user/user-register/user-register.component.html'
    }),
    core_2.Injectable(),
    __metadata("design:paramtypes", [router_1.Router,
        data_service_1.DataService,
        material_1.MdSnackBar])
], UserRegisterComponent);
exports.UserRegisterComponent = UserRegisterComponent;
//# sourceMappingURL=user-register.component.js.map