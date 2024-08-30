$(document).ready(function () {
    $('#lblTitle').text("PROJECT MANAGEMENT");
   // GetSupplierCategoryLists();
  //  GetSupplierStatusLists();
   // GetSupplierLocationLists();
    var FilterDetails = JSON.parse(localStorage.getItem('GraphFilterData'));
    if (FilterDetails != null) {
        if (FilterDetails.length > 0) {
            var ctrlID = '';

            for (var i = 0; i < FilterDetails.length; i++) {
                var Section = FilterDetails[i].Section;
                var Value = FilterDetails[i].GraphValue;

                if (Section == 'VendorCategoryPie') {
                    ctrlID = 'ddlSupplierCategory';
                }

                if (Section == 'VendorStatusPie') {
                    ctrlID = 'ddlSupllierStatus';
                }

                if (Section == 'VendorLocationChart') {
                    ctrlID = 'ddlLocation';
                }

                UpdateMultiSelectDropDownVal_ByText(Value, ctrlID);
            }
            GetSupplierDetails();
            localStorage.setItem('GraphFilterData', null);
        }
    } else {
        GetSupplierDetails();
    }
    $('.cb-element').click(function () {
        if (!$(this).is(':checked')) {
            return confirm("Are you sure?");
            alert("Value Checked");
        }
    });
    $(document).on('click', '.cb-element', function () {
        if ($(this).is(':checked')) {
            $("#btnNew").attr("disabled", "disabled");
        } else if (!$(this).is(':checked')) {
            $("#btnNew").removeAttr("disabled");
        }
        else {
            $("#btnNew").removeAttr("disabled");
        }
    });

    $("#CheckAll").click(function () {
        if ($(this).is(':checked')) {
            $("#btnNew").attr("disabled", "disabled");
        } else if (!$(this).is(':checked')) {
            $("#btnNew").removeAttr("disabled");
        }
        else {
            $("#btnNew").removeAttr("disabled");
        }
        $('input:checkbox').not(this).prop('checked', this.checked);
    });
    $('#BtnDelete').click(function () {
        var val = [];
        $(':checkbox:checked').each(function (i) {
            val[i] = $(this).val();
            //$("#btnEdit").hide();
            DeleteSupplier($(this).attr('name'));
            //$(".cb-element").prop("checked", false);
            //  alert($(this).val());
        });
    });
    $("#CheckAllStatus").click(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
    });
    $("#CheckAllAsignTo").click(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
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

$('#btnFilter').click(function () {
    GetSupplierDetails();
    $('#closeFilter').click();
    //$('.select').val(0).change();
});

//Get Supplier Category Lists
function GetSupplierCategoryLists() {
    $.ajax({
        type: "Get",
        async:false,
        url: apiurl + 'api/Supplier/GetSupplierCategoryLists',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#ddlSupplierCategory').html("").append('<option value="0">Select</option>');
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
        async: false,
        url: apiurl + 'api/Supplier/GetSupplierStatusLists',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#ddlSupllierStatus').html("").append('<option value="0">Select</option>');
            $(data).each(function () {
                $('#ddlSupllierStatus').append('<option value=' + this.sup_status_id_pk + '>' + this.sup_status_name + '</option>');
            });
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};
//Get Supplier City Lists
function GetSupplierLocationLists() {
    $.ajax({
        type: "Get",
        async: false,
        url: apiurl + 'api/Supplier/GetVendorCityList',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#ddlLocation').html("").append('<option value="0">Select</option>');
            $(data).each(function () {
                $('#ddlLocation').append('<option value=' + this.city + '>' + this.city + '</option>');
            });
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};


// Get Supplier Details  
function GetSupplierDetails() {
    let cat = null, status = null, city = null;
    let ar = [];
    $("#ddlSupplierCategory option:selected").each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        cat = ar.toString();
    }

    ar = [];
    $("#ddlSupllierStatus option:selected").each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        status = ar.toString();
    }

    ar = [];
    $("#ddlLocation option:selected").each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        city = ar.toString();
    }

    let parm = {
        'category_name': cat,
        'sup_status_name':status,
        'city': city
    };
    let josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/GetSupplierDetailsFilter',
        dataType: "json",
        data: josnstr,
        success: function (data) {
            //alert(data.status);
            var table;
            if ($.fn.dataTable.isDataTable('#tblSupplierDetails')) {
                table = $('#tblSupplierDetails').DataTable();
            } else {
                table = $('#tblSupplierDetails').DataTable();
            }
            table.destroy();
            $("#tblSupplierDetails").DataTable({
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
                        data: 'supplier_id_pk',
                        sWidth: '2px',
                        sClass: "view",
                        bSortable: false,
                        render: function (supplier_id_pk) {
                            return '<input id="check" class="cb-element checkbox" name="' + supplier_id_pk + '" type="checkbox">';  // <button class="btn btn-xs btn-success grid-buttons btnedit" name="' + catogory_id_pk + '" style="margin-right:5px;"><i class="fa fa-edit icon-ser"></i></button>
                        }
                    },
                    { data: 'supplier_id_pk', sWidth: '60px' },
                    {
                        data: 'supplier_code',
                        //sWidth: '200px',
                        sClass: "view",
                        bSortable: false,
                        render: function (data, type, row) {
                            return '<a class="editview" href="/VendorManagement/VendorDetails"  name="' + row["supplier_id_pk"] + '"> <i class="fa fa-eye icon-ser" style="color:#35adaf !important;"> </i> ' + row["supplier_code"] + '</a>';  // <button class="btn btn-xs btn-success grid-buttons btnedit" name="' + catogory_id_pk + '" style="margin-right:5px;"><i class="fa fa-edit icon-ser"></i></button>
                        }
                    },
                    { data: 'supplier_name' },
                    { data: 'category_name' },
                    { data: 'sup_status_name' },
                    {
                        data: 'supplier_id_pk',
                        render: function (supplier_id_pk, type, row) {
                            return '<a class="btnDelete" href="#" onclick="ConfirmDelete(' + supplier_id_pk + ')"> <i class="fa fa-trash" data-toggle="tooltip" title="" style="font-size:17px;color:red !important" data-original-title="Normal priority"></i> &nbsp; </a>';
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
            DeleteSupplier(id);
            //alert('Delete');
        } else {
            //alert('Safe');
            //location.reload();
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
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon: 'success'
                }).then(function () {
                    GetSupplierDetails();
                });
            } else {
                swal.fire({
                    title: 'Warning',
                    text: data.status,
                    icon: 'warning'
                });
            }
        },
        error: function (result) {
            alert("Error Occured");
        }
    });
};
