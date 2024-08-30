$(document).ready(function () {
    $('#lblTitle').text("VENDOR MANAGEMENT");
    var id = $.session.get('supplier_id_pk');
    GetSupplierDetailsEdit(id);
    GetSupplierStatusLists();
    GetSupplierCategoryLists();
    GetSupplierCategory();
    $("#btnUpdate").click(function () {
        UpdateSupplierDetails(id);
    });
});
function GetSupplierStatusLists() {
    $.ajax({
        type: "Get",
        async: false,
        url: apiurl + 'api/Supplier/GetSupplierStatusLists',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#ddlSupllierStatus').html("").append('<option value="0">Select Vendor Status</option>');
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
function GetSupplierCategoryLists() {
    $.ajax({
        type: "Get",
        async: false,
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
// Get Supplier Details For Edit
function GetSupplierDetailsEdit(id) {
    var parm = {
        'supplier_id_pk': id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetSupplierDetailsEdit',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            $("#txtSupplierCode").val(data.supplier_code).change();
            $("#txtSupplierName").val(data.supplier_name).change();
            $("#txtAddress").val(data.address);
            $("#txtCity").val(data.city);
            $("#txtContactPerson").val(data.contact_person);
            $("#ddlSupllierStatus").val(data.sup_status_id_fk).change();
            $("#txtEmail").val(data.email).change();
            $("#ddlSupplierCategory").val(data.sup_category_id_fk).change();
            $("#txtPhoneNumber").val(data.phone_number).change();
            $("#txtGSTNumber").val(data.GSTNumber);
            $("#txtNotes").val(data.note).change();
            if (data.services) {
                let _val = data.services;
                var ar = [];
                ar = _val.split(',');
                $('#ddlSupllierService').val(ar).change();
            }
            $("#txtNotes").val(data.note);
            $("#txtSupplierCode").attr('disabled','disabled');
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};
// Update Supplier Details  
function UpdateSupplierDetails(id) {
    var ser = [],svc = null;
    $('#ddlSupllierService option:selected').each(function () {
        if ($(this).val() != 0) {
            ser.push($(this).val());
        }
    });
    if (ser.length > 0) {
        svc = ser.toString();
    }
    var parm = {
        "supplier_id_pk": id,
        "supplier_code": $("#txtSupplierCode").val().trim(),
        "supplier_name": $("#txtSupplierName").val().trim(),
        "address": $("#txtAddress").val().trim(),
        "city": $("#txtCity").val().trim(),
        "contact_person": $("#txtContactPerson").val().trim(),
        "sup_status_id_fk": $("#ddlSupllierStatus option:selected").val(),
        "email": $("#txtEmail").val().trim(),
        "sup_category_id_fk": $("#ddlSupplierCategory option:selected").val(),
        "phone_number": $("#txtPhoneNumber").val().trim(),
        "GSTNumber": $("#txtGSTNumber").val().trim(),
        "note": $("#txtNotes").val().trim(),
        'services': svc
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        async:false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/UpdateSupplierDetails',
        success: function (data) {
            if (data.status_id == 1) {
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon: 'success'
                }).then(function () {
                    location.href = '/VendorManagement/Index';
                });
            } else {
                warningnotify(data.status);
            }
        },
        error: function (result) {
            alert("Error : data");
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