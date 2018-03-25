import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../../../services/data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IUser } from '../../../models/user';
import { DBOperation } from '../../../shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../../shared/global';

@Component({
    templateUrl: 'app/components/user/user-grid/user-grid.component.html'
})

export class UserGridComponent implements OnInit {
    @ViewChild('modal') modal: ModalComponent;
    users: IUser[];
    user: IUser;
    msg: string;
    indLoading: boolean = false;
    userFrm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private fb: FormBuilder, private _dataService: DataService) { }

    ngOnInit(): void {
        this.userFrm = this.fb.group({
            Id: [''],
            Username: ['', Validators.required],
            Email: ['', Validators.required],
            Name: [''],
            Surname: [''],
            Age: 0,
            Password: [''],
            Hash: ['']
        });
        
        this.LoadUsers();
    }

    LoadUsers(): void {
        this.indLoading = true;
        this._dataService.get(Global.BASE_USER_ENDPOINT + "list")
            .subscribe(users => { this.users = users; this.indLoading = false; },
            error => this.msg = <any>error);

    }

    addUser() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New User";
        this.modalBtnTitle = "Add";
        this.userFrm.reset();
        this.modal.open();
    }

    editUser(id: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit User";
        this.modalBtnTitle = "Update";
        this.user = this.users.filter(x => x.Id == id)[0];
        
        this.userFrm.setValue(this.user);
        this.modal.open();
    }

    deleteUser(id: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.user = this.users.filter(x => x.Id == id)[0];
        this.userFrm.setValue(this.user);
        this.modal.open();
    }

    SetControlsState(isEnable: boolean) {
        isEnable ? this.userFrm.enable() : this.userFrm.disable();
    }

    onSubmit(formData: any) {
        this.msg = "";

        switch (this.dbops) {
            case DBOperation.create:
                this._dataService.post(Global.BASE_USER_ENDPOINT + "create", formData._value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully added.";
                            this.LoadUsers();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }

                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.update:
                this._dataService.post(Global.BASE_USER_ENDPOINT + "update", formData._value).subscribe(
                    data => {
                        this.msg = "Data successfully updated.";
                        this.LoadUsers();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.delete:
                this._dataService.post(Global.BASE_USER_ENDPOINT + "remove", formData._value).subscribe(
                    data => {
                        this.msg = "Data successfully deleted.";
                        this.LoadUsers();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

        }
    }
}