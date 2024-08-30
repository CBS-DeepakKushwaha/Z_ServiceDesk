$(document).ready(function () {
    $('#lblTitle').text('CONFIGURATION - GLOBAL');
    GetPagePermissionsList(0);
    GetUserRolesRequest();

    $("#ddlUserRole").change(function () {
        if ($(this).val() == 0) {
            $('#tblPageRolePermissions_tbody').html('');
        } else {
            GetPagePermissionsList($(this).val());
        }
    });
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

function UpdPagePermissions() {
    var parm = {
        "role_name": $("#txtNewRole").val().trim()
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/UserRolePermissions/InsNewRole',
        success: function (data) {
            if (data.status_id != 0) {
                successnotify(data.status);
                GetPagePermissionsList();
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
// Get Page Permissions List
function GetPagePermissionsList(UserRole) {
    var parm = {
        "user_role_id_fk": UserRole, "Section": "PagePermissions_UserRole"
    };
    var josnstr = JSON.stringify(parm);

    $.ajax({
        type: "Post",
        async: false,
        url: apiurl + 'api/UserRolePermissions/GetPageControlPermissonsLists',
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var table;
            if (data != null) {
                ConvertJsontoDataTable(data);

                ////if ($.fn.dataTable.isDataTable('#tblPageRolePermissions')) {
                ////    table = $('#tblPageRolePermissions').DataTable();
                ////} else {
                ////    table = $('#tblPageRolePermissions').DataTable();
                ////}
            }

            ////table.destroy();
            ////$("#tblPageRolePermissions").DataTable({
            ////    data: data,
            ////    paging: true,
            ////    sort: false,
            ////    searching: true,
            ////    ordering: true,
            ////    order: [],
            ////    lengthMenu: [
            ////        [10, 25, 50, -1],
            ////        ['10 Rows', '25 Rows', '50 Rows', 'Show All']
            ////    ],
            ////    responsive: true,
            ////    columns: [
            ////        { data: 'user_role_id_pk' },
            ////        { data: 'role_name' },
            ////        //{
            ////        //    data: 'is_active',
            ////        //    render: function (is_active) {
            ////        //        if (is_active == 1) {
            ////        //            return '<span class="badge badge-soft-success">Active</span>';
            ////        //        } else {
            ////        //            return '<span class="badge badge-soft-danger">In-active</span>';
            ////        //        }
            ////        //    }
            ////        //},
            ////        //{
            ////        //    data: 'created_date',
            ////        //    render: function (created_date) {
            ////        //        if (created_date == null) {
            ////        //            return 'N/A';
            ////        //        } else {
            ////        //            var dat = moment(created_date).format('DD-MM-YYYY');
            ////        //            return dat;
            ////        //        }
            ////        //    }
            ////        //},
            ////        {
            ////            data: 'user_role_id_pk', sWidth: '200px', render: function (user_role_id_pk, type, row) {
            ////                return '<i class="fa fa-edit" onclick="OpenEdit(' + user_role_id_pk + ')" data-toggle="tooltip" title="" style="color:#35adaf !important; font-size:17px" data-original-title="Normal priority"></i> &nbsp; <a class="" href="#" onclick="ConfirmDelete(' + user_role_id_pk + ')"> <i class="fa fa-trash" data-toggle="tooltip" title="" style="font-size:17px;color:#f64e60 !important" data-original-title="Normal priority"></i> &nbsp; </a>';

            ////            }
            ////        },
            ////    ],
            ////    dom: 'Bflrtip',
            ////    lengthChange: true,
            ////    buttons: [
            ////        {
            ////            extend: 'copyHtml5',
            ////            text: '<i class="fa fa-files-o fa-1x"></i>',
            ////            titleAttr: 'Copy'
            ////        },
            ////        {
            ////            extend: 'excelHtml5',
            ////            text: '<i class="fa fa-file-excel-o fa-1x"></i>',
            ////            titleAttr: 'Excel'
            ////        },
            ////        {
            ////            extend: 'pdfHtml5',
            ////            text: '<i class="fa fa-file-pdf-o fa-1x"></i>',
            ////            titleAttr: 'PDF'
            ////        },
            ////        {
            ////            extend: 'colvis',
            ////            text: '<i class="fa fa-list fa-1x"></i>',
            ////            titleAttr: 'colvis'
            ////        },
            ////        //'colvis'
            ////    ]
            ////    //dom: 'Bfrtip',
            ////    //buttons: [
            ////    //    'copyHtml5',
            ////    //    'excelHtml5',
            ////    //    'csvHtml5',
            ////    //    'pdfHtml5'
            ////    //]
            ////});
        },

        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

function ConvertJsontoDataTable(data) {
    var tr;
    var ctrl = '';
    $('#tblPageRolePermissions_tbody').html('');
    var strOptions = "";
    for (var i = 0; i < data.length; i++) {
        tr = $("<tr id=tblPRP_tr_" + i + " />");
        tr.append("<td id=tblPRP_td_Id_" + i + "><label id=tblPRP_lbl_Id_" + i + ">" + data[i].page_controls_permissions_id_pk + "</label></td>");
        tr.append("<td id=tblPRP_td_Role_" + i + " style='padding:10px'><label id=tblPRP_lbl_Role_" + i + ">" + data[i].RoleName + "</label></td>");
        tr.append("<td id=tblPRP_td_PageName_" + i + " style='padding:10px'><label id=tblPRP_lbl_PageName_" + i + ">" + data[i].PageName + "</label></td>");
        tr.append("<td id=tblPRP_td_ControlName_" + i + " style='padding:10px'><label id=tblPRP_lbl_ControlName_" + i + ">" + data[i].ControlName + "</label></td>");
        tr.append("<td id=tblPRP_td_Visibility_" + i + " style='padding:10px'><label id=tblPRP_lbl_Visibility_" + i + ">" + data[i].VisibilityName + "</label><select style='display:none' class='select form-control select2' id=ddlVisibility_" + i + " name='txtclient' required><option value='Select'>Select</option><option value='0'>No</option><option value='1'>Yes</option></select></td>");
        tr.append("<td id=tblPRP_td_Action_" + i + "><div class=' pull-left'><button id='btnEdit_" + i + "' style='display:block;' type='button' class='btn btn-sm btn-soft-success btn-circle mr-2' onclick=EditRow(this.id);><i class='dripicons-pencil'></i></button><button style='display:none;' id='btnUpdate_" + i + "' type='button' class='btn btn-sm btn-soft-purple mr-2 btn-circle' onclick=SaveRow(this.id);><i class='dripicons-checkmark'></i></button><button style='display:none;' id='btnCancel_" + i + "' type='button' class='btn btn-sm btn-soft-info btn-circle' onclick=CancelRow(this.id);><i class='dripicons-cross' aria-hidden='true'></i></button></div></td>");
        $('#tblPageRolePermissions_tbody').append(tr);

    }
}

function CancelRow(ctrl) {
    var rowno = ctrl.replace('btnCancel_', '');

    var tblAR_lbl_RiskLevel = $('#tblPRP_lbl_Visibility_' + rowno).text();

    if (tblAR_lbl_RiskLevel == 'No') {
        $("#ddlVisibility_" + rowno).val(0);
    }

    if (tblAR_lbl_RiskLevel == 'Yes') {
        $("#ddlVisibility_" + rowno).val(1);
    }

    $('#ddlVisibility_' + rowno).hide();

    $('#btnUpdate_' + rowno).hide();
    $('#btnCancel_' + rowno).hide();

    $('#tblPRP_lbl_Visibility_' + rowno).show();

    $('#btnEdit_' + rowno).show();
}

function EditRow(ctrl) {
    
    var rowno = ctrl.replace('btnEdit_', '');

    $('#ddlVisibility_' + rowno).show();

    $('#btnUpdate_' + rowno).show();
    $('#btnCancel_' + rowno).show();

    $('#tblPRP_lbl_Visibility_' + rowno).hide();

    $('#btnEdit_' + rowno).hide();
}

function SaveRow(ctrl) {
    var ErrorMsg = '';
    var rowno = ctrl.replace('btnUpdate_', '');
    var ID = $('#tblPRP_lbl_Id_' + rowno).text();
    var ddlVisibility = $('#ddlVisibility_' + rowno).val();

    if (ddlVisibility == 'Select') {
        if (ErrorMsg == '') {
            ErrorMsg = 'Please enter the mentioned fields: Visibility';
        }
        else {
            ErrorMsg = ErrorMsg + ',Visibility';
        }
    }
    else {
        if (ddlVisibility == 0) {
            $('#tblPRP_lbl_Visibility_' + rowno).text('No');
        }

        if (ddlVisibility == 1) {
            $('#tblPRP_lbl_Visibility_' + rowno).text('Yes');
        }


        $('#ddlVisibility_' + rowno).hide();

        $('#btnUpdate_' + rowno).hide();
        $('#btnCancel_' + rowno).hide();

        $('#tblPRP_lbl_Visibility_' + rowno).show();

        $('#btnEdit_' + rowno).show();

        var parm = {
            "page_controls_permissions_id_pk": ID,
            "IsVisible": $("#ddlVisibility_" + rowno + " option:selected").val(),
        };

        var josnstr = JSON.stringify(parm);
        $.ajax({
            type: "Post",
            async: false,
            data: josnstr,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: apiurl + 'api/UserRolePermissions/UpdPageControlPermissons',
            success: function (data) {
                if (data.status_id != 0) {
                    ////GetPagePermissionsList();
                    successnotify(data.status);
                } else {
                    warningnotify(data.status);
                }
            },
            error: function (result) {
                alert("Error : data");
            }
        });
    }

    if (ErrorMsg != '') {
        $('#lblErrorMessage').text(ErrorMsg);
        $('#ErrorModal').modal('show');
    }
    else {
        $('#btnAddRow').removeAttr('disabled');
    }
}

function OpenEdit(id) {
    //alert(id);
    //////if ($.session.get("edit_id") != '' || $.session.get("edit_id") != null || $.session.get("edit_id") == undefined) {
    //////    $.session.remove("edit_id");
    //////    $.session.set("edit_id", id);       
    //////}

    if ($('#hdnRoleID').val() == 0) {
        $('#hdnRoleID').val(id);
    }

    var parm = {
        "user_role_id_pk": id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/UserRolePermissions/GetRoleById',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            $("#txtEditRole").val(data.role_name);
            if (data.is_active == 1) {
                $("#chkEditStatus").prop('checked', true);
            } else {
                $("#chkEditStatus").prop('checked', false);
            }
        },
        error: function (result) {
            alert("Error Occured");
        }
    });
    $("#btnEdit").click();
};

function updatename() {
    var chk = $("#chkEditStatus").attr("checked") ? 1 : 0;
    var parm = {
        ////"user_role_id_pk": $.session.get("edit_id"),
        "user_role_id_pk": $("#hdnRoleID").val(),
        "role_name": $("#txtEditRole").val(),
        "is_active": chk
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/UserRolePermissions/UpdateUserRole',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.status_id == 1) {
                successnotify(data.status);
                //$("#closedEdit").click();
                //GetRoleList();
            } else {
                warningnotify(data.status);
                //$("#closedEdit").click();
                //GetRoleList();
            }
            ////$.session.remove("edit_id");
            $('#hdnRoleID').val(0);
        },
        error: function (result) {
            alert("Error Occured");
            ////$.session.remove("edit_id");
            $('#hdnRoleID').val(0);
        }
    });
};

function validateUpdate() {
    var ret_val = true;
    if ($("#txtEditCommonCategory").val() == null || $("#txtEditCommonCategory").val() == '') {
        $("#SpnEditCommonCategory").show();
        ret_val = false;
    } else {
        $("#SpnEditCommonCategory").hide();
    }
    return ret_val;
}