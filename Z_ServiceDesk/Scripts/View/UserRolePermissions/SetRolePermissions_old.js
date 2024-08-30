$(document).ready(function () {
    $('#lblTitle').text("CONFIGURATION MANAGEMENT");
    $('#btnUpdate').hide();
    $('#btnSubmit').hide();
    GetUserRolesRequest();
    SetUserRolePermissionsRequest();
    ////GetPageMasterRequest();

    $("#ddlUserRole").change(function () {
        if ($(this).val() == 0) {
            $('#tblRolePermissions_tbody').html('');
        } else {
            GetRolePermissonsLists($(this).val());
        }
    });

    $('#lblHead').text("USER ROLE PERMISSIONS");

    $("#BtnSlide").click();
});

//Get User Roles Lists
function GetUserRolesRequest() {
    var parm = {
        "ID": 0, "Section": "UserRoles"
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        async: false,
        url: apiurl + 'api/Commonapi/GetDropDownData',
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlUserRole').html("").append('<option value="0">Select </option>');
            $(data).each(function () {
                $('#ddlUserRole').append('<option value=' + this.ID + '>' + this.Name + '</option>');
            });
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

//Get Role Permissons Lists
function GetRolePermissonsLists(user_role_id_fk) {
    var parm = {
        "user_role_id_fk": user_role_id_fk
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        async: false,
        url: apiurl + 'api/UserRolePermissions/GetRolePermissonsLists',
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            ConvertJsontoDataTable(data);
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

function ConvertJsontoDataTable(data) {
    var tr;
    var ctrl = '';
    $('#tblRolePermissions_tbody').html('');
    for (var i = 0; i < data.length; i++) {
        tr = $("<tr id=tblRP_tr_" + i + " />");
        tr.append("<td id=tblRP_td_Id_" + i + " style='display:none;'><label id=tblRP_lbl_Id_" + i + ">" + data[i].user_role_details_id_pk + "</label></td>");
        tr.append("<td id=tblRP_td_Page_ID_" + i + " style='padding:10px;display:none;'><label id=tblRP_lbl_Page_ID_" + i + ">" + data[i].page_master_id_fk + "</label></td>");
        tr.append("<td id=tblRP_td_Role_ID_" + i + " style='padding:10px;display:none;'><label id=tblRP_lbl_Role_ID_" + i + ">" + data[i].user_role_id_fk + "</label></td>");
        tr.append("<td id=tblRP_td_Page_Name_" + i + " style='padding:10px'><label>" + data[i].Screen_Name + "</label></td>");
        tr.append("<td id=tblRP_td_View_Name_" + i + " style='padding:10px'><label id=tblRP_lbl_View_Name_" + i + ">" + data[i].View_Name + "</label><div id=divView_" + i + " class='dis-none' style='margin-left:5px;'><input id=cbkView_" + i + " type='checkbox' /><label for='View' style='margin-left:2px;'>View</label></div></td>");
        tr.append("<td id=tblRP_td_Add_Name_" + i + " style='padding:10px'><label id=tblRP_lbl_Add_Name_" + i + ">" + data[i].Add_Name + "</label><div id=divAdd_" + i + " class='dis-none' style='margin-left:5px;'><input id=cbkAdd_" + i + " type='checkbox' /><label for='Add' style='margin-left:2px;'>Add</label></div></td>");
        tr.append("<td id=tblRP_td_Edit_Name_" + i + " style='padding:10px'><label id=tblRP_lbl_Edit_Name_" + i + ">" + data[i].Edit_Name + "</label><div id=divEdit_" + i + " class='dis-none' style='margin-left:5px;'><input id=cbkEdit_" + i + " type='checkbox' /><label for='Edit' style='margin-left:2px;'>Edit</label></div></td>");
        tr.append("<td id=tblRP_td_Delete_Name_" + i + " style='padding:10px'><label id=tblRP_lbl_Delete_Name_" + i + ">" + data[i].Delete_Name + "</label><div id=divDelete_" + i + " class='dis-none' style='margin-left:5px;'><input id=cbkDelete_" + i + " type='checkbox' /><label for='Delete' style='margin-left:2px;'>Delete</label></div></td>");
        tr.append("<td id=tblRP_td_Action_" + i + "><div class=' pull-left'><button id='btnEdit_" + i + "' type='button' class='btn btn-sm btn-soft-success btn-circle mr-2' onclick='rowEdit(this.id);'><i class='dripicons-pencil'></i></button><button id='btnUpdate_" + i + "' type='button' class='btn btn-sm btn-soft-purple mr-2 btn-circle' style='display:none;' onclick='rowUpdate(this.id);'><i class='dripicons-checkmark'></i></button><button id='btnCancel_" + i + "' type='button' class='btn btn-sm btn-soft-info btn-circle' style='display:none;' onclick='rowCancel(this.id);'><i class='dripicons-cross' aria-hidden='true'></i></button></div></td>");
        $('#tblRolePermissions_tbody').append(tr);
    }
}

function rowEdit(ctrl) {
    var rowno = ctrl.replace('btnEdit_', '');

    var View_Name = $('#tblRP_lbl_View_Name_' + rowno).text();
    var Add_Name = $('#tblRP_lbl_Add_Name_' + rowno).text();
    var Edit_Name = $('#tblRP_lbl_Edit_Name_' + rowno).text();
    var Delete_Name = $('#tblRP_lbl_Delete_Name_' + rowno).text();

    if (View_Name == 'Yes') {
        $('#cbkView_' + rowno).prop('checked', true);
    }
    else {
        $('#cbkView_' + rowno).prop('checked', false);
    }

    if (Add_Name == 'Yes') {
        $('#cbkAdd_' + rowno).prop('checked', true);
    }
    else {
        $('#cbkAdd_' + rowno).prop('checked', false);
    }

    if (Edit_Name == 'Yes') {
        $('#cbkEdit_' + rowno).prop('checked', true);
    }
    else {
        $('#cbkEdit_' + rowno).prop('checked', false);
    }

    if (Delete_Name == 'Yes') {
        $('#cbkDelete_' + rowno).prop('checked', true);
    }
    else {
        $('#cbkDelete_' + rowno).prop('checked', false);
    }

    $('#btnEdit_' + rowno).hide();
    $('#btnDelete_' + rowno).hide();
    $('#btnUpdate_' + rowno).show();
    $('#btnCancel_' + rowno).show();

    $('#tblRP_lbl_View_Name_' + rowno).hide();
    $('#tblRP_lbl_Add_Name_' + rowno).hide();
    $('#tblRP_lbl_Edit_Name_' + rowno).hide();
    $('#tblRP_lbl_Delete_Name_' + rowno).hide();

    $('#divView_' + rowno).removeClass('dis-none').addClass('dis-inline-block');
    $('#divAdd_' + rowno).removeClass('dis-none').addClass('dis-inline-block');
    $('#divEdit_' + rowno).removeClass('dis-none').addClass('dis-inline-block');
    $('#divDelete_' + rowno).removeClass('dis-none').addClass('dis-inline-block');
}

function rowUpdate(ctrl) {
    var rowno = ctrl.replace('btnUpdate_', '');
    UpdRolePermissions(rowno);
}

function rowCancel(ctrl) {
    var rowno = ctrl.replace('btnCancel_', '');

    $('#btnUpdate_' + rowno).hide();
    $('#btnCancel_' + rowno).hide();
    $('#btnEdit_' + rowno).show();
    $('#btnDelete_' + rowno).show();

    $('#tblRP_lbl_View_Name_' + rowno).show();
    $('#tblRP_lbl_Add_Name_' + rowno).show();
    $('#tblRP_lbl_Edit_Name_' + rowno).show();
    $('#tblRP_lbl_Delete_Name_' + rowno).show();

    $('#divView_' + rowno).removeClass('dis-inline-block').addClass('dis-none');
    $('#divAdd_' + rowno).removeClass('dis-inline-block').addClass('dis-none');
    $('#divEdit_' + rowno).removeClass('dis-inline-block').addClass('dis-none');
    $('#divDelete_' + rowno).removeClass('dis-inline-block').addClass('dis-none');
}

function rowElim(ctrl) {
    var rowno = ctrl.replace('btnDelete_', '');

    DelRiskMatrix($('#tblRiskMatrix_lbl_Id_' + rowno).text());
}

// Update Role Permissions
function UpdRolePermissions(rowno) {
    
    var ID = $('#tblRP_lbl_Id_' + rowno).text();
    var RoleID = $('#tblRP_lbl_Role_ID_' + rowno).text();
    var PageID = $('#tblRP_lbl_Page_ID_' + rowno).text();

    var View = false;
    var Add = false;
    var Edit = false;
    var Delete = false;

    if ($('#cbkView_' + rowno).is(':checked')) {
        View = true;
    }

    if ($('#cbkAdd_' + rowno).is(':checked')) {
        Add = true;
    }

    if ($('#cbkEdit_' + rowno).is(':checked')) {
        Edit = true;
    }

    if ($('#cbkDelete_' + rowno).is(':checked')) {
        Delete = true;
    }

    var parm = {
        "user_role_details_id_pk": ID,
        "user_role_id_fk": RoleID,
        "page_master_id_fk": PageID,
        "View": View,
        "Add": Add,
        "Edit": Edit,
        "Delete": Delete,
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        async: false,
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/UserRolePermissions/InsUpdRolePermissons',
        success: function (data) {
            if (data.status_id != 0) {
                successnotify(data.status);
                GetRolePermissonsLists(RoleID);
                $("#divMain").find("input").val("");
                $("#divMain").find("textarea").val("");
                $("#divMain").find("select").val(0).change();
                $('#closedModel').click();
            } else {
                warningnotify(data.status);
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });
};

//Get User Roles Lists
function SetUserRolePermissionsRequest() {
    var parm = {
        "ID": 0, "Section": "UserRoles"
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Get",
        async: false,
        url: apiurl + 'api/UserRolePermissions/SetUserRolePermissonsDetails',
        ////data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
            if (data != null) {
                var SessionData = data;

                sessionStorage.setItem('UserSessionData', SessionData);
            }           
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

////////$('#InsertConfirmationModal.modal.fade').on('click', function () {
////////    RedirectPage('Users');
////////})

////////function RedirectToPage() {
////////    RedirectPage('Users');
////////}
