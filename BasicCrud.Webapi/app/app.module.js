"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var app_component_1 = require("./app.component");
var app_routing_1 = require("./app.routing");
var forms_2 = require("@angular/forms");
// Animation and Materials
var animations_1 = require("@angular/platform-browser/animations");
var material_1 = require("@angular/material");
// Services
var data_service_1 = require("./services/data.service");
var userSession_service_1 = require("./services/userSession.service");
// Index page
var home_component_1 = require("./components/home.component");
// User Components
var user_grid_component_1 = require("./components/user/user-grid/user-grid.component");
var user_login_component_1 = require("./components/user/user-login/user-login.component");
var user_register_component_1 = require("./components/user/user-register/user-register.component");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            animations_1.BrowserAnimationsModule,
            material_1.MaterialModule,
            material_1.MdNativeDateModule,
            forms_1.ReactiveFormsModule,
            http_1.HttpModule,
            app_routing_1.routing,
            ng2_bs3_modal_1.Ng2Bs3ModalModule,
            forms_2.FormsModule
        ],
        declarations: [
            app_component_1.AppComponent,
            home_component_1.HomeComponent,
            user_grid_component_1.UserGridComponent,
            user_login_component_1.UserLoginComponent,
            user_register_component_1.UserRegisterComponent
        ],
        providers: [{ provide: common_1.APP_BASE_HREF, useValue: '/' }, data_service_1.DataService, userSession_service_1.UserSessionService],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map