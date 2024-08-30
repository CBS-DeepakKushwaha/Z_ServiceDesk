$(document).ready(function () {
    //if ($.session.get("roleid") == undefined || $.session.get("roleid") == 0) {
    //    window.location.href = "/Login/Index/";
    //};
    $('#lblTitle').text("CONFIGURATION - INCIDENT MANAGEMENT");
    GetRoleList();
    $("#btnUpdate").attr("disabled", "disabled");

    $(document).on('click', '.btnedit', function () {
        // GetPreventiveMaintainanceActivityViewCheckList($(this).attr('name'));
    });
    $(document).on('click', '.btneditstatus', function () {
        // GetPreventiveMaintainanceActivityChangeStatus($(this).attr('name'));
    });
    $("#btnSubmit").click(function () {
        if (validateNewRole() == true) {
            InsCategoryName();
        } else {
            return false;
        }
    });
    $(document).on('change', '#txtEditCommonCategory', function () {
        validateUpdate();
    });
    $("#btnSubmitEdit").click(function () {
        if (validateUpdate() == true) {
            updatename();
        }
    });

});

function validateNewRole() {
    var return_val = true;
    if ($('#txtNewRole').val().trim() == "" || $('#txtNewRole').val() == null) {
        $('#SpnNewRole').show();
        return_val = false;
    } else {
        $('#SpnNewRole').hide();
    }

    if ($('#ddlRoleType option:selected').val() == 0) {
        $('#SpnRoleType').show();
        return_val = false;
    } else {
        $('#SpnRoleType').hide();
    }
    return return_val;
};

function InsCategoryName() {
    var parm = {
        "role_name": $("#txtNewRole").val().trim(),
        "role_type": $('#ddlRoleType option:selected').val()
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
                GetRoleList();
                $('#NewRoleModal').modal('hide');
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

// Get Location List 
function GetRoleList() {
    $.ajax({
        type: "Get",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/UserRolePermissions/GetUserRoleList',
        dataType: "json",
        success: function (data) {
            var table;
            if ($.fn.dataTable.isDataTable('#tblUserRoles')) {
                table = $('#tblUserRoles').DataTable();
            } else {
                table = $('#tblUserRoles').DataTable();
            }
            table.destroy();
            $("#tblUserRoles").DataTable({
                data: data,
                paging: true,
                sort: false,
                searching: true,
                ordering: true,
                order: [],
                lengthMenu: [
                    [10, 25, 50, -1],
                    ['10 Rows', '25 Rows', '50 Rows', 'Show All']
                ],
                responsive: true,
                columns: [
                    { data: 'user_role_id_pk' },
                    { data: 'role_type_name' },
                    { data: 'role_name' },
                    //{
                    //    data: 'is_active',
                    //    render: function (is_active) {
                    //        if (is_active == 1) {
                    //            return '<span class="badge badge-soft-success">Active</span>';
                    //        } else {
                    //            return '<span class="badge badge-soft-danger">In-active</span>';
                    //        }
                    //    }
                    //},
                    //{
                    //    data: 'created_date',
                    //    render: function (created_date) {
                    //        if (created_date == null) {
                    //            return 'N/A';
                    //        } else {
                    //            var dat = moment(created_date).format('DD-MM-YYYY');
                    //            return dat;
                    //        }
                    //    }
                    //},
                    {
                        data: 'user_role_id_pk', sWidth: '200px', render: function (user_role_id_pk, type, row) {
                            return '<i class="fa fa-edit editview" onclick="OpenEdit(' + user_role_id_pk + ')" data-toggle="tooltip" title="" style="color:#35adaf !important; font-size:17px" data-original-title="Normal priority"></i> &nbsp; <a class="btnDelete" href="#" onclick="ConfirmDelete(' + user_role_id_pk + ')"> <i class="fa fa-trash" data-toggle="tooltip" title="" style="font-size:17px;color:#f64e60 !important" data-original-title="Normal priority"></i> &nbsp; </a>';

                        }
                    },
                ],
                dom: 'Bflrtip',
                lengthChange: true,
                buttons: [
                    {
                        extend: 'copyHtml5',
                        text: '<i class="fa fa-files-o fa-1x"></i>',
                        titleAttr: 'Copy'
                    },
                    {
                        extend: 'excelHtml5',
                        text: '<i class="fa fa-file-excel-o fa-1x"></i>',
                        titleAttr: 'Excel'
                    },
                    {
                        extend: 'pdfHtml5',
                        text: '<i class="fa fa-file-pdf-o fa-1x"></i>',
                        titleAttr: 'PDF'
                    },
                    {
                        extend: 'colvis',
                        text: '<i class="fa fa-list fa-1x"></i>',
                        titleAttr: 'colvis'
                    },
                    //'colvis'
                ]
                //dom: 'Bfrtip',
                //buttons: [
                //    'copyHtml5',
                //    'excelHtml5',
                //    'csvHtml5',
                //    'pdfHtml5'
                //]
            });
        },

        error: function (edata) {
            alert("error while feching record.");
        }
    });
};
function ConfirmDelete(id) {
    swal.fire({
        title: 'Confirmation',
        text: 'Are you sure you want to delete?',
        icon: 'warning',
        confirmButtonText: 'Yes',
        cancelButtonText: 'No',
        showCancelButton: true,
        buttons: true,
        dangerMode: true
    }).then(function (is_delete) {
        if (is_delete.value) {
            DeleteUserRole(id);
            //alert('Delete');
        } else {
            //alert('Safe');
            //location.reload();
        }
    });
};
function DeleteUserRole(id) {
    var parm = {
        "user_role_id_pk": id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/UserRolePermissions/DeleteRoleById',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.status_id == "1") {
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon: 'success'
                }).then(function () {
                    GetRoleList();
                });
            } else {
                DeleteSuccess(data.status);
            }
        },
        error: function (result) {
            alert("Error Occured");
        }
    });
};

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
            $("#ddlEditRoleType").val(data.role_type).change();
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
    var chk = $("#chkEditStatus").is(":checked") ? 1 : 0;
    var parm = {
        ////"user_role_id_pk": $.session.get("edit_id"),
        "user_role_id_pk": $("#hdnRoleID").val(),
        "role_name": $("#txtEditRole").val(),
        "role_type": $('#ddlEditRoleType option:selected').val(),
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
                $("#closedEdit").click();
                GetRoleList();
                $('#EditPopUp').modal('hide');
            } else {
                warningnotify(data.status);
                $("#closedEdit").click();
                GetRoleList();
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
    if ($("#txtEditRole").val() == null || $("#txtEditRole").val() == '') {
        $("#SpnEditRole").show();
        ret_val = false;
    } else {
        $("#SpnEditRole").hide();
    }

    if ($('#ddlEditRoleType option:selected').val() == 0) {
        $('#SpnEditRoleType').show();
        ret_val = false;
    } else {
        $('#SpnEditRoleType').hide();
    }
    return ret_val;
}