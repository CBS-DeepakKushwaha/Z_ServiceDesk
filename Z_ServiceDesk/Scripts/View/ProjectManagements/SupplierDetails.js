$(document).ready(function () {
   // alert($.session.get("supplier_id_pk"));
    GetSupplierDetailsList($.session.get("supplier_id_pk"));
    GetSupplierContactDetails();
    GetSupplierDocumentDetails();
    GetServiceList();
    $("#lblTitle").text('VENDOR MANAGEMENT');
    $("#v-pills-purchase-tab").click(function () {
        GetConsumableList();
        GetAssetsList();
        GetSoftwareList();
        GetComponentList();
    });

    $("#v-pills-sold-tab").click(function () {
        GetAssetsSoldList();
    });


    $("#v-pills-contract-tab").click(function () {
        GetContract($.session.get("supplier_id_pk"));
    });

    $("#btnSupplierContactDetails").click(function () {
        InsSupplierContactDetails($.session.get("supplier_id_pk"));
        //if (validateSupplierContactDetails() == true) {
           
        //} else {
        //    return false;
        //}
    });
    $("#btnSubmit").click(function () {
        UpdateSupplierManagements($.session.get("supplier_id_pk"));
        //if (validateAssets() == true) {
        //    alert("hello");
        //    InsMapAssetHardwareInfo();
        //} else {
        //    return false;
        //}
    });
    $("#btnSupplierDocumentDetails").click(function () {
        UpdateSupplierManagementsDocuments($.session.get("supplier_id_pk"));
        //if (validateAssets() == true) {
        //    alert("hello");
        //    InsMapAssetHardwareInfo();
        //} else {
        //    return false;
        //}
    });
    $(document).on('click', '.cb-element', function () {
        if ($(this).is(':checked')) {
            $("#BtnDelete").removeAttr("disabled");
        } else if (!$(this).is(':checked')) {
            $("#BtnDelete").attr("disabled", "disabled");
        }
        else {
            $("#BtnDelete").attr("disabled", "disabled");
        }
    });

    $(document).on('click', '.viewAsset', function () {
        if ($.session.get("asset_id_pk") != '' || $.session.get("asset_id_pk") != null || $.session.get("asset_id_pk") == undefined) {
            $.session.remove("asset_id_pk");
            $.session.set("asset_id_pk", $(this).attr("name"));
        }
    });

    $("#CheckAll").click(function () {
        if ($(this).is(':checked')) {
            $("#BtnDelete").removeAttr("disabled");
        } else if (!$(this).is(':checked')) {
            $("#BtnDelete").attr("disabled", "disabled");
        }
        else {
            $("#BtnDelete").attr("disabled", "disabled");
        }
        $('input:checkbox').not(this).prop('checked', this.checked);
    });
    $(document).on('click', '.viewContract', function () {
        // alert($(this).attr("name"));
        if ($.session.get("contract_id_pk") != '' || $.session.contract_id_pkget("contract_id_pk") != null || $.contract_id_pk.get("contract_id_pk") == undefined) {
            $.session.remove("contract_id_pk");
            $.session.set("contract_id_pk", $(this).attr("name"));
        }
        window.location.href = '/Contract/ContractDetails';
    });
});
// Validate Supplier Contact Details
function validateSupplierContactDetails() { 
    var return_val = true;
    if ($('#txtName').val().trim() == "" || $('#txtName').val() == null) {
        $('#SpnName').show();
        return_val = false;
    } else {
        $('#SpnName').hide();
    }
    if ($('#txtMobileNo').val().trim() == "" || $('#txtMobileNo').val() == null) {
        $('#SpnMobileNo').show();
        return_val = false;
    } else {
        $('#SpnMobileNo').hide();
    }
    if ($('#txtContactAddress').val().trim() == "" || $('#txtContactAddress').val() == null) {
        $('#SpnAddress').show();
        return_val = false;
    } else {
        $('#SpnAddress').hide();
    }
    if ($('#txtDesignation').val().trim() == "" || $('#txtDesignation').val() == null) {
        $('#SpnDesignation').show();
        return_val = false;
    } else {
        $('#SpnDesignation').hide();
    }
    return return_val;
};
//Vendor Details
function GetSupplierDetailsList(supplier_id) {
    var parm = {
        'supplier_id_pk': supplier_id // $.session.get("asset_id_pk");
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetSupplierDetailsList',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            $("#txtSupplierCode").text(data.supplier_code);
            $("#txtSupplierName").text(data.supplier_name);
            $("#spanSupplierName").text(data.supplier_name);
            $("#txtSupplierCategory").text(data.category_name);
            $("#txtSupplierStatus").text(data.sup_status_name);
            $("#txtConatactPerson").text(data.contact_person);
            $("#txtAddress").text(data.address);
            $("#txtCity").text(data.city);
            $("#txtEmail").text(data.email);
            $("#txtPhoneNumber").text(data.phone_number);
            $("#txtNotes").text(data.note); 

            $("#txtRiskAssesMentResult").text(data.risk_ass_mng_result);
            $("#txtRefrence").text(data.refrence);
            $("#txtTrackRecord").text(data.track_record);
           // $("#txtTrackRecord").val(data.creadit_rating).change();

            $('input[name=CreditRating]:checked').val(data.creadit_rating).select();


        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};
//Service List For Vendor Details
function GetServiceList() {
    var parm = {
        'supplier_id_pk': $.session.get("supplier_id_pk")
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetVendorServicesById',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data != null) {
                $(data).each(function () {
                    $('#tbody_services').append('<tr><th class="text-nowrap" scope="row">' + this.category_name + '</th></tr>');
                });
            }
        },
        error: function (val) {
            alert('Error while fetching service categories of vendor.');
        }
    });
};
//Risk Evaluation Tab Data Update
function UpdateSupplierManagements(supplier_id_pk) { 
    var parm = {
        "supplier_id_pk": supplier_id_pk, 
        "risk_ass_mng_result": $("#txtRiskAssesMentResult").val().trim(),
        "track_record": $("#txtTrackRecord").val().trim(),
        "refrence": $("#txtRefrence").val().trim(),
        "creadit_rating": $('input[name=CreditRating]:checked').val() //$("#ddlAssignTo option:selected").val().trim(),
       
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/UpdateSupplierManagements', 
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.status_id == "1") {
                CreateSuccess(data.status);
                $('#closedModel').click();
            } else {
                CreateSuccess(data.status);
            }
        },
        error: function (result) {
            alert("Not Update data");
        }
    });
};
// Insert Supplier Contact Details 
function InsSupplierContactDetails(supplier_id) { 
    var parm = {
        "supplier_id_fk": supplier_id,
        "name": $("#txtName").val().trim(),
        "email": $("#txtEmailId").val().trim(),
        "mobile_no": $("#txtMobileNo").val().trim(), 
        "address": $("#txtContactAddress").val().trim(),
        "designation": $("#txtDesignation").val().trim()  
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/InsSupplierContactDetails',  
        success: function (data) {
            //alert("Inserted Successfully");
            if (data.status_id != 0) {
                //  alert(data.status);
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon: 'success'
                }).then(function () {
                    $('#CloseContactModal').click();
                    $('#txtName').val('');
                    $('#txtEmailId').val('');
                    $('#txtMobileNo').val('');
                    $('#txtContactAddress').val('');
                    $('#txtDesignation').val('');
                    GetSupplierContactDetails();
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
// Get Supplier Contact Details  
function GetSupplierContactDetails() { 
    var parm = {
        'supplier_id_fk': $.session.get("supplier_id_pk"),// $.session.get("asset_id_pk"); 
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetSupplierContactDetails',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            //alert(data.status);
            var table;
            if ($.fn.dataTable.isDataTable('#tblContactDetails')) {
                table = $('#tblContactDetails').DataTable();
            } else {
                table = $('#tblContactDetails').DataTable();
            }
            table.destroy();
            $("#tblContactDetails").DataTable({
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
                        data: 'supp_con_det_id_pk',
                        sWidth: '2px',
                        sClass: "view",
                        bSortable: false,
                        render: function (supp_con_det_id_pk) {
                            return '<input id="check" class="cb-element checkbox" name="' + supp_con_det_id_pk + '" type="checkbox">';  // <button class="btn btn-xs btn-success grid-buttons btnedit" name="' + catogory_id_pk + '" style="margin-right:5px;"><i class="fa fa-edit icon-ser"></i></button>
                        }
                    },
                    //{
                    //    data: 'supp_con_det_id_pk',
                    //    sWidth: '60px',
                    //    sClass: "view",
                    //    bSortable: false,
                    //    render: function (supp_con_det_id_pk) {
                    //        return '<a class="editview" href="/SupplierManagements/SupplierDetails"  name="' + supp_con_det_id_pk + '"> ' + supp_con_det_id_pk + '</a>';  // <button class="btn btn-xs btn-success grid-buttons btnedit" name="' + catogory_id_pk + '" style="margin-right:5px;"><i class="fa fa-edit icon-ser"></i></button>
                    //    }
                    //},
                    //{ data: 'supplier_id_pk' },
                    { data: 'contact_person' },
                    { data: 'email' },
                    { data: 'phone_number' },
                    { data: 'address' },
                    { data: 'designation' }
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

function UpdateSupplierManagementsDocuments(supplier_id_pk) {
    var parm = {
        "supplier_id_fk": supplier_id_pk,
        "doc_type": $("#txtDocType").val().trim(),
        "doc_name": $("#txtDocName").val().trim(),
        "description": $("#txtReasonForGatePass").val().trim(),
        "documents": '/DocFolder/Supplier/IDS/' + $("#txtFile").val().trim().replace(/C:\\fakepath\\/i, ''), //$("#ddlAssignTo option:selected").val().trim(),
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Supplier/UpdateSupplierManagementsDocument',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.status_id == 1) {
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon: 'success'
                }).then(function () {
                    UploadDocument(data.suplier_doc_id_pk);
                    GetSupplierDocumentDetails();
                    $('#CloseDocumentModal').click();
                });
                //CreateSuccess(data.status);
            } else {
                swal.fire({
                    title: 'Warning',
                    text: data.status,
                    icon: 'warning'
                });
                //CreateSuccess(data.status);
            }
        },
        error: function (result) {
            alert("Not Update data");
        }
    });
};

function UploadDocument(ID) {
    var data = new FormData();
    data.append("UniqueID", ID);
    data.append("DocFolderPath", 'Supplier');
    data.append("Category", $("#txtDesc").val());

    var FileName = '';
    var files = $("#txtFile").get(0).files;
    if (files.length > 0) {
        data.append("UploadedFile", files[0]);
        FileName = $("#txtFile").val().trim().replace(/C:\\fakepath\\/i, '');
        //data.append("FileName", FileName);
        UploadOrgFiles(data);
    }
};

function UploadOrgFiles(data) {
    var ajaxRequest = $.ajax({
        async: false,
        type: "Post",
        url: apiurl + "/api/Commonapi/UploadOrgFile",
        contentType: false,
        processData: false,
        data: data
    });

    ajaxRequest.done(function (xhr, textStatus) {
        // Do other operation
    });
};
// Get Supplier Document Details  
function GetSupplierDocumentDetails() {
    var parm = {
        'supplier_id_fk': $.session.get("supplier_id_pk"),// $.session.get("asset_id_pk"); 
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetSupplierDocumentDetails',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            //alert(data.status);
            var table;
            if ($.fn.dataTable.isDataTable('#tblDocumentDetails')) {
                table = $('#tblDocumentDetails').DataTable();
            } else {
                table = $('#tblDocumentDetails').DataTable();
            }
            table.destroy();
            $("#tblDocumentDetails").DataTable({
                data: data,
                paging: true,
                sort: false,
                searching: true,
                ordering: true,
                order: [],
                lengthMenu: [
                    [10, 25, 50, -1],
                    ['10 rows', '25 rows', '50 rows', 'Show all']
                ],
                responsive: true,
                columns: [
                    { data: 'suplier_doc_id_pk' },
                    { data: 'doc_type' },
                    { data: 'doc_name' },
                    { data: 'description' },
                    // { data: 'documents' },
                    {
                        "data": "documents",
                        "render":
                            function (documents) {
                                return '<a class="edit" Target="_blank" href="' + 'https://sgrl-admin.zservicedesk.com/api/api/' + documents + '" download>Download</a>';
                            }
                    },
                    {
                        data: 'suplier_doc_id_pk', sWidth: '200px', render: function (suplier_doc_id_pk, type, row) {
                            return '<a class="" href="#" onclick="DeleteSupplierDocument(' + suplier_doc_id_pk + ')"> <i class="fa fa-trash" data-toggle="tooltip" title="" style="font-size:17px;color:red !important" data-original-title="Normal priority"></i> &nbsp; </a>';

                        }
                    }
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
// Delete Supplier Documents
function DeleteSupplierDocument(suplier_doc_id) {
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
            var parm = {
                "suplier_doc_id_pk": suplier_doc_id
            };
            var josnstr = JSON.stringify(parm);
            $.ajax({
                type: "Post",
                url: apiurl + 'api/Supplier/DeleteSupplierDocumentByID',
                contentType: "application/json; charset=utf-8",
                data: josnstr,
                success: function (data) {
                    if (data.status_id == 1) {
                        DeleteSuccess(data.status);
                        swal.fire({
                            title: 'Success',
                            text: data.status,
                            icon: 'success'
                        }).then(function () {
                            GetSupplierDocumentDetails();
                        });

                    } else {
                        DeleteSuccess(data.status);
                    }
                },
                error: function (edata) {
                    alert("error while feching record.");
                }
            });
            //alert('Delete');
        } else {
            //alert('Safe');
            //location.reload();
        }
    });

};

function GetConsumableList() {
    var parm = {
        'supplier_id_pk': $.session.get("supplier_id_pk")
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetConsumableForSupplier',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            var table;
            if ($.fn.dataTable.isDataTable('#tblConsumables')) {
                table = $('#tblConsumables').DataTable();
            } else {
                table = $('#tblConsumables').DataTable();
            }
            table.destroy();
            $("#tblConsumables").DataTable({
                data: data,
                paging: true,
                sort: false,
                searching: true,
                ordering: true,
                order: [],
                lengthMenu: [
                    [10, 25, 50, -1],
                    ['10 rows', '25 rows', '50 rows', 'Show all']
                ],
                responsive: false,
                columns: [
                    { data: 'consumable_item_id_pk' },
                    { data: 'location_name' },
                    { data: 'category_name' },
                    { data: 'item_name' },
                    { data: 'qty' },
                    {
                        data: 'created_date',
                        render: function (created_date) {
                            return moment(created_date).format('DD/MM/YYYY');
                        }
                    }
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

                //"buttons": [
                //    { extend: 'copy' },
                //    { extend: 'csv'  },
                //    { extend: 'excel'},
                //    { extend: 'pdf' }
                //]

                //buttons: [
                //    'copyHtml5',
                //    'excelHtml5',
                //    'csvHtml5',
                //    'pdfHtml5'
                //]
            });
        },
        error: function (result) {
            alert('Error fetching consumables for vendor.');
        }
    });
};

function GetAssetsList() {
    var parm = {
        'supplier_id_pk': $.session.get("supplier_id_pk")
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetAssetsForSupplier',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            var table;
            if ($.fn.dataTable.isDataTable('#tblAssets')) {
                table = $('#tblAssets').DataTable();
            } else {
                table = $('#tblAssets').DataTable();
            }
            table.destroy();
            $("#tblAssets").DataTable({
                data: data,
                paging: true,
                sort: false,
                searching: true,
                ordering: true,
                order: [],
                lengthMenu: [
                    [10, 25, 50, -1],
                    ['10 rows', '25 rows', '50 rows', 'Show all']
                ],
                responsive: false,
                columns: [
                    { data: 'asset_id_pk' },
                    {
                        data: 'asset_id_pk',//'asset_tag',
                        render: function (asset_id_pk,type,row) {
                            return '<a href="/Inventory/FixedAssetsDetails" class="viewAsset" name="' + asset_id_pk + '"><i class="fa fa-eye" data-toggle="tooltip" title="" style="color:#35adaf !important" data-original-title="Normal priority"></i> &nbsp;' + row.asset_tag + '</a>';
                        }
                    },
                    { data: 'asset_cat_name' },
                    //{ data: 'email' },
                    { data: 'manufacturer_name' },
                    { data: 'model_name' },
                    { data: 'serial_number' },
                    { data: 'location_name' },
                    //{
                    //    data: 'created_date',
                    //    render: function (created_date) {
                    //        return moment(created_date).format('DD/MM/YYYY');
                    //    }
                    //}
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

                //"buttons": [
                //    { extend: 'copy' },
                //    { extend: 'csv'  },
                //    { extend: 'excel'},
                //    { extend: 'pdf' }
                //]

                //buttons: [
                //    'copyHtml5',
                //    'excelHtml5',
                //    'csvHtml5',
                //    'pdfHtml5'
                //]
            });
        },
        error: function (result) {
            alert('Error fetching assets for vendor.');
        }
    });
};

function GetAssetsSoldList() {
    var parm = {
        'supplier_id_pk': $.session.get("supplier_id_pk")
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetAssetsSoldToSupplier',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            var table;
            if ($.fn.dataTable.isDataTable('#tblAssets_Sold')) {
                table = $('#tblAssets_Sold').DataTable();
            } else {
                table = $('#tblAssets_Sold').DataTable();
            }
            table.destroy();
            $("#tblAssets_Sold").DataTable({
                data: data,
                paging: true,
                sort: false,
                searching: true,
                ordering: true,
                order: [],
                lengthMenu: [
                    [10, 25, 50, -1],
                    ['10 rows', '25 rows', '50 rows', 'Show all']
                ],
                responsive: false,
                columns: [
                    { data: 'asset_id_pk' },
                    {
                        data: 'asset_id_pk',//'asset_tag',
                        render: function (asset_id_pk, type, row) {
                            return '<a href="/Inventory/FixedAssetsDetails" class="viewAsset" name="' + asset_id_pk + '"><i class="fa fa-eye" data-toggle="tooltip" title="" style="color:#35adaf !important" data-original-title="Normal priority"></i> &nbsp;' + row.asset_tag + '</a>';
                        }
                    },
                    { data: 'asset_cat_name' },
                    //{ data: 'email' },
                    { data: 'manufacturer_name' },
                    { data: 'model_name' },
                    { data: 'serial_number' },
                    { data: 'location_name' },
                    { data: 'SoldAmount' },
                    //{
                    //    data: 'created_date',
                    //    render: function (created_date) {
                    //        return moment(created_date).format('DD/MM/YYYY');
                    //    }
                    //}
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

                //"buttons": [
                //    { extend: 'copy' },
                //    { extend: 'csv'  },
                //    { extend: 'excel'},
                //    { extend: 'pdf' }
                //]

                //buttons: [
                //    'copyHtml5',
                //    'excelHtml5',
                //    'csvHtml5',
                //    'pdfHtml5'
                //]
            });
        },
        error: function (result) {
            alert('Error fetching assets for vendor.');
        }
    });
};

function GetSoftwareList() {
    var parm = {
        'supplier_id_pk': $.session.get("supplier_id_pk")
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetSoftwareForSupplier',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            var table;
            if ($.fn.dataTable.isDataTable('#tblSoftwares')) {
                table = $('#tblSoftwares').DataTable();
            } else {
                table = $('#tblSoftwares').DataTable();
            }
            table.destroy();
            $("#tblSoftwares").DataTable({
                data: data,
                paging: true,
                sort: false,
                searching: true,
                ordering: true,
                order: [],
                lengthMenu: [
                    [10, 25, 50, -1],
                    ['10 rows', '25 rows', '50 rows', 'Show all']
                ],
                responsive: false,
                columns: [
                    { data: 'software_id_pk' },
                    { data: 'software_name' },
                    { data: 'license_type' },
                    //{ data: 'email' },
                    { data: 'license_no' },
                    //{ data: 'qty' },
                    {
                        data: 'from_date',
                        render: function (from_date) {
                            if (from_date != null && from_date != '') {
                                return moment(from_date).format('DD/MM/YYYY');
                            }
                        }
                    },
                    {
                        data: 'to_date',
                        render: function (to_date) {
                            if (to_date != null && to_date != '') {
                                return moment(to_date).format('DD/MM/YYYY');
                            }
                        }
                    }
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

                //"buttons": [
                //    { extend: 'copy' },
                //    { extend: 'csv'  },
                //    { extend: 'excel'},
                //    { extend: 'pdf' }
                //]

                //buttons: [
                //    'copyHtml5',
                //    'excelHtml5',
                //    'csvHtml5',
                //    'pdfHtml5'
                //]
            });
        },
        error: function (result) {
            alert('Error fetching assets for vendor.');
        }
    });
};

function GetComponentList() {
    var parm = {
        'supplier_id_pk': $.session.get("supplier_id_pk")
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Supplier/GetComponentsForSupplier',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            var table;
            if ($.fn.dataTable.isDataTable('#tblComponents')) {
                table = $('#tblComponents').DataTable();
            } else {
                table = $('#tblComponents').DataTable();
            }
            table.destroy();
            $("#tblComponents").DataTable({
                data: data,
                paging: true,
                sort: false,
                searching: true,
                ordering: true,
                order: [],
                lengthMenu: [
                    [10, 25, 50, -1],
                    ['10 rows', '25 rows', '50 rows', 'Show all']
                ],
                responsive: false,
                columns: [
                    { data: 'asset_comp_id_pk' },
                    { data: 'component_name' },
                    {
                        data: 'warranty_end_date',
                        render: function (warranty_end_date) {
                            if (warranty_end_date != null && warranty_end_date != '') {
                                return moment(warranty_end_date).format('DD/MM/YYYY');
                            }
                        }
                    }
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

                //"buttons": [
                //    { extend: 'copy' },
                //    { extend: 'csv'  },
                //    { extend: 'excel'},
                //    { extend: 'pdf' }
                //]

                //buttons: [
                //    'copyHtml5',
                //    'excelHtml5',
                //    'csvHtml5',
                //    'pdfHtml5'
                //]
            });
        },
        error: function (result) {
            alert('Error fetching assets for vendor.');
        }
    });
};

// Get Contract ManagementList
function GetContract(id) {
    var parm = {
        "supplier_id_pk": id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Contract/GetContractForVendorDetails',
        dataType: "json",
        data: josnstr,
        success: function (data) {
            //alert(data.status);
            var table;
            if ($.fn.dataTable.isDataTable('#tblContract')) {
                table = $('#tblContract').DataTable();
            } else {
                table = $('#tblContract').DataTable();
            }
            table.destroy();
            $("#tblContract").DataTable({
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
                responsive: false,
                columns: [

                    {
                        data: 'contract_id_pk',
                        sWidth: '2px',
                        sClass: "view",
                        bSortable: false,
                        render: function (contract_id_pk) {
                            return '<input id="check" class="cb-element checkbox" name="' + contract_id_pk + '" type="checkbox">';  // <button class="btn btn-xs btn-success grid-buttons btnedit" name="' + catogory_id_pk + '" style="margin-right:5px;"><i class="fa fa-edit icon-ser"></i></button>
                        }
                    },
                    {
                        data: 'contract_id_pk',
                        sWidth: '60px',
                        sClass: "view",
                        bSortable: false,
                        render: function (contract_id_pk, type, row) {
                            return '<a class="viewContract" href="#"  name="' + contract_id_pk + '"> <i class="fa fa-eye"></i> &nbsp;' + row.prefix + contract_id_pk + '</a>';  // <button class="btn btn-xs btn-success grid-buttons btnedit" name="' + catogory_id_pk + '" style="margin-right:5px;"><i class="fa fa-edit icon-ser"></i></button>
                        }
                    },
                    { data: 'title' },
                    { data: 'service_discription' },
                    { data: 'service_review_period' },
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