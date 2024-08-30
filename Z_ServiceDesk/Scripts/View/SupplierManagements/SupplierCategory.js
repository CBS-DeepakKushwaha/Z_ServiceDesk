$(document).ready(function () {
    $('#lblTitle').text("CONFIGURATION ");
    //if ($.session.get("roleid") == undefined || $.session.get("roleid") == 0) {
    //    window.location.href = "/Login/Index/";
    //};
    GetSupplierCategoryLists();
    $('.cb-element').click(function () {
        if (!$(this).is(':checked')) {
            return confirm("Are you sure?");
            alert("Value Checked");
        }
    });
    $(document).on('click', '.cb-element', function () {
        if ($(this).is(':checked')) {
            $("#btnEdit").show();
            $("#btnNew").hide();
            $("#btnAssignTo").removeAttr("disabled");
            $("#btnChangeStatus").removeAttr("disabled");
            $("#BtnDelete").removeAttr("disabled");
        } else if (!$(this).is(':checked')) {
            $("#btnAssignTo").attr("disabled", "disabled");
            $("#btnChangeStatus").attr("disabled", "disabled");
            $("#BtnDelete").attr("disabled", "disabled");
            $("#btnEdit").hide();
            $("#btnNew").show();
        }
        else {
            $("#btnAssignTo").attr("disabled", "disabled");
            $("#btnChangeStatus").attr("disabled", "disabled");
            $("#BtnDelete").attr("disabled", "disabled");
            $("#btnEdit").hide();
            $("#btnNew").show();
        }
        // alert($(this).attr("name"));
        //if ($.session.get("ticket_id_pk") != '' || $.session.get("ticket_id_pk") != null || $.session.get("ticket_id_pk") == undefined) {
        //    $.session.remove("ticket_id_pk");
        //    $.session.set("ticket_id_pk", $(this).attr("name"));
        //    window.open('/Ticket/TicketDetails');
        //}

    });

    $("#CheckAll").click(function () {
        if ($(this).is(':checked')) {
            $("#btnAssignTo").removeAttr("disabled");
            $("#btnChangeStatus").removeAttr("disabled");
            $("#BtnDelete").removeAttr("disabled");
            $("#btnEdit").show();
            $("#btnNew").hide();
        } else if (!$(this).is(':checked')) {
            $("#btnAssignTo").attr("disabled", "disabled");
            $("#btnChangeStatus").attr("disabled", "disabled");
            $("#BtnDelete").attr("disabled", "disabled");
            $("#btnEdit").hide();
            $("#btnNew").show();
        }
        else {
            $("#btnAssignTo").attr("disabled", "disabled");
            $("#btnChangeStatus").attr("disabled", "disabled");
            $("#BtnDelete").attr("disabled", "disabled");
            $("#btnEdit").hide();
            $("#btnNew").show();
        }
        $('input:checkbox').not(this).prop('checked', this.checked);
    });
    $('#BtnDelete').click(function () {
        var val = [];
        $(':checkbox:checked').each(function (i) {
            val[i] = $(this).val();
            $("#btnEdit").hide();
            deleteTicket($(this).attr('name'));
            $(".cb-element").prop("checked", false);
            //  alert($(this).val());
        });
    });
    $("#btnSubmit").click(function () {
        if (InsSupplierCategory() == true) {
            //InsSupplierCategory();
        } else {
            return false;
        }
    });
    $(document).on('change', '#txtEditVendorCtaegory', function () {
        validateUpdate();
    });
    $("#btnSubmitEdit").click(function () {
        if (validateUpdate() == true) {
            updatename();
        }
    });
});
//function validateSupplierCategory() { 
//    var return_val = true;
//    if ($('#txtCategoryName').val() == "" || $('#txtCategoryName').val() == null) {
//        $('#SpnCategoryName').show();
//        return_val = false;
//    } else {
//        $('#SpnCategoryName').hide();
//    }
//    return return_val;
//};
// Insert Supplier Category 
function InsSupplierCategory() {
    var parm = {
        "category_name": $("#txtVendorCtaegory").val()
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/InsSupplierCategory',
        success: function (data) {
            //alert("Inserted Successfully");
            if (data.status_id != 0) {
                //  alert(data.status);
                successnotify(data.status);
                GetSupplierCategoryLists();
                $("#closedModel").click();

            } else {
                // alert(data.status);
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });
};
// Get Supplier Category Lists 
function GetSupplierCategoryLists() {
    $.ajax({ 
        type: "Get",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/GetSupplierCategoryLists', 
        dataType: "json",
        success: function (data) {
            //alert(data.status);
            var table;
            if ($.fn.dataTable.isDataTable('#tblSupplierCategory')) {
                table = $('#tblSupplierCategory').DataTable();
            } else {
                table = $('#tblSupplierCategory').DataTable();
            }
            table.destroy();
            $("#tblSupplierCategory").DataTable({
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

                    {
                        data: 'sup_category_id_pk',
                        sWidth: '2px',
                        sClass: "view",
                        bSortable: false,
                        render: function (sup_category_id_pk) {
                            return '<input id="check" class="cb-element checkbox" name="' + sup_category_id_pk + '" type="checkbox">';  // <button class="btn btn-xs btn-success grid-buttons btnedit" name="' + catogory_id_pk + '" style="margin-right:5px;"><i class="fa fa-edit icon-ser"></i></button>
                        }
                    },
                    { data: 'sup_category_id_pk' },
                    { data: 'category_name' },
                    {
                        data: 'sup_category_id_pk', sWidth: '200px', render: function (sup_category_id_pk, type, row) {
                            return '<i class="fa fa-edit editview" onclick="OpenEdit(' + sup_category_id_pk + ')" data-toggle="tooltip" title="" style="color:#35adaf !important; font-size:17px" data-original-title="Normal priority"></i><a class="btnDelete" href="#" onclick="ConfirmDelete(' + sup_category_id_pk + ')"> <i class="fa fa-trash" data-toggle="tooltip" title="" style="font-size:17px;color:#f64e60 !important" data-original-title="Normal priority"></i> &nbsp; </a>';

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
            DeleteSupplierCategoryByID(id);
            //alert('Delete');
        } else {
            //alert('Safe');
            //location.reload();
        }
    });
};
function DeleteSupplierCategoryByID(sup_category_id) {  
    var parm = {
        "sup_category_id_pk": sup_category_id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Masters/DeleteSupplierCategoryByID',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.status_id == "1") {
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon: 'success'
                }).then(function () {
                    GetSupplierCategoryLists();
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
    var parm = {
        "sup_category_id_pk": id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Masters/GetVendorCategoryById',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            $("#txtEditVendorCtaegory").val(data.category_name);
            $("#txtEditVendorCtaegory").attr('name', data.sup_category_id_pk);
        },
        error: function (result) {
            alert("Error Occured");
        }
    });
    $("#btnEdit").click();
};
function updatename() {
    var parm = {
        "sup_category_id_pk": $("#txtEditVendorCtaegory").attr('name'),
        "category_name": $("#txtEditVendorCtaegory").val(),
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Masters/UpdateVendorById',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.status_id == 1) {
                successnotify(data.status);
                $("#closedModelEdit").click();
                GetSupplierCategoryLists();
            } else {
                GetSupplierCategoryLists();
            }
        },
        error: function (result) {
            alert("Error Occured");
        }
    });
};
function validateUpdate() {
    var ret_val = true;
    if ($('#txtEditVendorCtaegory').val().trim() == "" || $('#txtEditVendorCtaegory').val() == null) {
        $('#SpnEditVendorCtaegory').show();
        return_val = false;
    } else {
        $('#SpnEditVendorCtaegory').hide();
    }

    return ret_val;
};