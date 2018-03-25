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
var data_service_1 = require("../../../services/data.service");
var forms_1 = require("@angular/forms");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var enum_1 = require("../../../shared/enum");
var global_1 = require("../../../shared/global");
var UserGridComponent = (function () {
    function UserGridComponent(fb, _dataService) {
        this.fb = fb;
        this._dataService = _dataService;
        this.indLoading = false;
    }
    UserGridComponent.prototype.ngOnInit = function () {
        this.userFrm = this.fb.group({
            Id: [''],
            Username: ['', forms_1.Validators.required],
            Email: ['', forms_1.Validators.required],
            Name: [''],
            Surname: [''],
            Age: 0,
            Password: [''],
            Hash: ['']
        });
        this.LoadUsers();
    };
    UserGridComponent.prototype.LoadUsers = function () {
        var _this = this;
        this.indLoading = true;
        this._dataService.get(global_1.Global.BASE_USER_ENDPOINT + "list")
            .subscribe(function (users) { _this.users = users; _this.indLoading = false; }, function (error) { return _this.msg = error; });
    };
    UserGridComponent.prototype.addUser = function () {
        this.dbops = enum_1.DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New User";
        this.modalBtnTitle = "Add";
        this.userFrm.reset();
        this.modal.open();
    };
    UserGridComponent.prototype.editUser = function (id) {
        this.dbops = enum_1.DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit User";
        this.modalBtnTitle = "Update";
        this.user = this.users.filter(function (x) { return x.Id == id; })[0];
        this.userFrm.setValue(this.user);
        this.modal.open();
    };
    UserGridComponent.prototype.deleteUser = function (id) {
        this.dbops = enum_1.DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.user = this.users.filter(function (x) { return x.Id == id; })[0];
        this.userFrm.setValue(this.user);
        this.modal.open();
    };
    UserGridComponent.prototype.SetControlsState = function (isEnable) {
        isEnable ? this.userFrm.enable() : this.userFrm.disable();
    };
    UserGridComponent.prototype.onSubmit = function (formData) {
        var _this = this;
        this.msg = "";
        switch (this.dbops) {
            case enum_1.DBOperation.create:
                this._dataService.post(global_1.Global.BASE_USER_ENDPOINT + "create", formData._value).subscribe(function (data) {
                    if (data == 1) {
                        _this.msg = "Data successfully added.";
                        _this.LoadUsers();
                    }
                    else {
                        _this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.update:
                this._dataService.post(global_1.Global.BASE_USER_ENDPOINT + "update", formData._value).subscribe(function (data) {
                    _this.msg = "Data successfully updated.";
                    _this.LoadUsers();
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.delete:
                this._dataService.post(global_1.Global.BASE_USER_ENDPOINT + "remove", formData._value).subscribe(function (data) {
                    _this.msg = "Data successfully deleted.";
                    _this.LoadUsers();
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
        }
    };
    return UserGridComponent;
}());
__decorate([
    core_1.ViewChild('modal'),
    __metadata("design:type", ng2_bs3_modal_1.ModalComponent)
], UserGridComponent.prototype, "modal", void 0);
UserGridComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/components/user/user-grid/user-grid.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, data_service_1.DataService])
], UserGridComponent);
exports.UserGridComponent = UserGridComponent;
//# sourceMappingURL=user-grid.component.js.map