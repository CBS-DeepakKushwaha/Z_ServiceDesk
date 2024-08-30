$(document).ready(function () {
    $('#lblTitle').text("PROJECT MANAGEMENT");
    GetSupplierCategoryLists();
    GetSupplierStatusLists();
    GetSupplierCategory();
    GetSupplierVendorCode();
    GetProjectDetails();
   // GetSupplierDetails();
    
    $('.cb-element').click(function () {
        if (!$(this).is(':checked')) {
            return confirm("Are you sure?");
            alert("Value Checked");
        }
    });

    $("#ddlCategory").change(function () {
        if ($(this).val() != 0) {
            GetCommonSubCategory($(this).val());
        } else {
            $("#ddlSubCategory").html("").append('<option value="0">Select Sub Category</option>');
        }
    });
    $("#ddlSupportGroup").change(function () {
        if ($(this).val() != 0) {
            GetEmployeeListSGD($(this).val());
        } else {
            $("#ddlUser").html("").append('<option value="0">Select Employee</option>');
        }
    });

    $("#ddlDepartmentName").change(function () {
        if ($(this).val() != 0) {
            GetSupportGroup($(this).val());
        } else {
            $("#ddlSupportGroup").html("").append('<option value="0">Select Support Group</option>');
        }
    });
    $("#btnSubmit").click(function () {
        if (validateSupplier() == true) {
            InsSupplierDetails();
        }
    });
    $("#btnUpdate").click(function () {
        var val = [];
        $('.cb-element:checked').each(function (i) {
            val[i] = $(this).val();
            UpdateSupplierDetails($(this).attr('name'));
        });
    });
    $('#btnStatusUpdate').click(function () {
        var val = [];
        $(':checkbox:checked').each(function (i) {
            val[i] = $(this).val();
            UpdateSupplierStatus($(this).attr('name'));
        });
    });
    $(document).on('click', '.editview', function () {
        //alert($(this).attr("name"));
        if ($.session.get("supplier_id_pk") != '' || $.session.get("supplier_id_pk") != null || $.session.get("supplier_id_pk") == undefined) {
            $.session.remove("supplier_id_pk");
            $.session.set("supplier_id_pk", $(this).attr("name"));
            //  window.open('/Ticket/TicketDetails');
        }
    });
});
// Validate Supplier 
function validateSupplier() {
    var return_val = true;
    if ($('#txtProjectCode').val().trim() == "" || $('#txtProjectCode').val() == null) { 
        $('#SpnProjectCode').show();
        return_val = false;
    } else {
        $('#SpnProjectCode').hide(); 
    }

    if ($('#txtProjectName').val().trim() == "" || $('#txtProjectName').val() == null) {
        $('#SpnProjectName').show();
        return_val = false;
    } else {
        $('#SpnSupplierName').hide();
    }

   

    if ($('#ddlProjectStatus').val() == 0) {
        $('#SpnProjectStatus').show();
        return_val = false;
    } else {
        $('#SpnProjectStatus').hide();
    }
    if ($('#txtProjectTitle').val().trim() == "" || $('#txtProjectTitle').val() == null) {
        $('#SpnProjectTitle').show();
       return_val = false;
    } else {
        $('#SpnProjectTitle').hide();
    }
    if (return_val == false) {
        swal.fire({
            title: 'Validation Error!',
            text: 'Please check and fill mandatory fields.',
            icon: 'warning'
        });
    }

    return return_val;
};
//Get Supplier Category Lists
function GetSupplierCategoryLists() {
    $.ajax({
        type: "Get",
        url: apiurl + 'api/Supplier/GetSupplierCategoryLists',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#ddlSupplierCategory').html("").append('<option value="0">Select Vendor Category</option>');
            $(data).each(function () {
                $('#ddlSupplierCategory').append('<option value=' + this.sup_category_id_pk + '>' + this.category_name + '</option>');
            });
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};
//Get Supplier Status Lists
function GetSupplierStatusLists() {
    $.ajax({
        type: "Get",
        url: apiurl + 'api/Supplier/GetSupplierStatusLists',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#ddlSupllierStatus').html("");
            $('#ddlSupllierStatusUpd').html("").append('<option value="0">Select Vendor Status</option>');
            $(data).each(function () {
                $('#ddlSupllierStatusUpd').append('<option value=' + this.sup_status_id_pk + '>' + this.sup_status_name + '</option>');
                $('#ddlSupllierStatus').append('<option value=' + this.sup_status_id_pk + '>' + this.sup_status_name + '</option>');
            });
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};
// Get the Vendor code for new Vendor
function GetSupplierVendorCode() {
    $.ajax({
        type: "Get",
        url: apiurl + 'api/Supplier/GetSupplierVendorCode',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#txtSupplierCode').val(data[0].supplier_code).attr('disabled','disabled');
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

// Insert Supplier Details 
function InsSupplierDetails() {
    var ar = [];
    var ser = null;
    $('#ddlSupllierService option:selected').each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        ser = ar.toString();
    }
    var parm = {
        "supplier_code": $("#txtSupplierCode").val().trim(),
        "supplier_name": $("#txtSupplierName").val().trim(),
        "address": $("#txtAddress").val().trim(),
        "city": $("#txtCity").val().trim(),
        "contact_person": $("#txtContactPerson").val().trim(),
        "sup_status_id_fk": $("#ddlSupllierStatus option:selected").val().trim(),
        "email": $("#txtEmail").val().trim(),
        "sup_category_id_fk": $("#ddlSupplierCategory option:selected").val().trim(),
        "phone_number": $("#txtPhoneNumber").val().trim(),
        "GSTNumber": $("#txtGSTNumber").val().trim(),
        "note": $("#txtNotes").val(),
        "services":ser
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/InsSupplierDetails',
        success: function (data) {
            //alert("Inserted Successfully");
            if (data.status_id != 0) {
                //  alert(data.status);
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon:'success'
                }).then(function () {
                    $('#closedModel').click();
                    $("#ClrTicket").find("input").val("");
                    $("#ClrTicket").find("select").val(0).change();
                    window.location.href = "/VendorManagement/Index"
                });
            } else {
                // alert(data.status);
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });
};
// Update Supplier Status  
function UpdateSupplierStatus(supplier_id) {
    var parm = {
        "supplier_id_pk": supplier_id,
        "sup_status_id_fk": $("#ddlSupllierStatusUpd option:selected").val().trim(),
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/UpdateSupplierStatus',
        success: function (data) {
            if (data.status_id != 0) {
                CreateSuccess(data.status);
                $('#closedModelStatus').click();
                GetSupplierDetails();
                $(".cb-element").prop("checked", false);
                $("#ClrSupplier").find("select").val(0).change();
            } else {
                $('#closedModelStatus').click();
                //CreateSuccess(data.status);
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });
};

function DeleteSupplier(supplier_id) {
    var parm = {
        "supplier_id_pk": supplier_id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/DeleteSupplierByID',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.status_id == "1") {
                DeleteSuccess(data.status);
                GetSupplierDetails();

            } else {
                DeleteSuccess(data.status);
            }
        },
        error: function (result) {
            alert("Error Occured");
        }
    });
};

function GetSupplierCategory() {
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/GetVendorServiceList',
        dataType: "json",
        success: function (data) {
            $(data).each(function () {
                $('#ddlSupllierService').append('<option value="' + this.service_cat_id_pk + '">' + this.category_name + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching supplier services.');
        }
    });
};
function GetProjectDetails() {
    $.ajax({
        type: "Get",
        url: apiurl + 'api/Project/GetProjectDetails',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#ddlProjectStatus').html("").append('<option value="0">Select</option>');
            $(data).each(function () {
                $('#ddlProjectStatus').append('<option value=' + this.supplier_id_pk + '>' + this.supplier_name + '</option>');
            });
        },
        error: function (edata) {
            alert("  feching record.");
        }
    });
};

function GetSupplierDetails() {
    var ar = [];
    var ser = null;
    $('#btn option:selected').each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        ser = ar.toString();
    }
    var parm = {
        "suppller_code": $("#txtSupplierCode").val().trim(),
        "supplier_name": $("#txtSupplierName").val().trim(),
        "address": $("#txtAddress").val().trim(),
        "city": $("#txtCity").val().trim(),
        "contact_person": $("#txtContactPerson").val().trim(),
        "sup_status_id_fk": $("#ddlSupllierStatus option:selected").val().trim(),
        "email": $("#txtEmail").val().trim(),
        "sup_category_id_fk": $("#ddlSupplierCategory option:selected").val().trim(),
        "phone_number": $("#txtPhoneNumber").val().trim(),
        "GSTNumber": $("#txtGSTNumber").val().trim(),
        "note": $("#txtNotes").val(),
        "services": ser
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Project/GetSupplierDetails',
        success: function (data) {
            //alert("Inserted Successfully");
            if (data.status_id != 0) {
                //  alert(data.status);
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon: 'success'
                }).then(function () {
                    $('#closedModel').click();
                    $("#ClrTicket").find("input").val("");
                    $("#ClrTicket").find("select").val(0).change();
                    window.location.href = "/Project/Index"
                });
            } else {
                // alert(data.status);
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });
};


