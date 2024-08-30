$(document).ready(function () {
    GetBudgetDetails();
    GetBudgetType();
    GetBudgetCategory();
    //GetSubBudgetCategory();
    GetDealineBudget();
    GetApprovedBudget();

    var FilterDetails = JSON.parse(localStorage.getItem('GraphFilterData'));
    if (FilterDetails != null) {
        if (FilterDetails.length > 0) {
            var ctrlID = '';

            for (var i = 0; i < FilterDetails.length; i++) {
                var Section = FilterDetails[i].Section;
                var Value = FilterDetails[i].GraphValue;

                if (Section == 'BudgetType') {
                    ctrlID = 'ddlBudgetType';
                }

                if (Section == 'BudgetCategory') {
                    ctrlID = 'ddlBudgetCategory';
                }

                if (Section == 'BudgetSubCategory') {
                    ctrlID = 'ddlBudgetSubCategory';
                }
                if (Section == 'BudgetDeadLine') {
                    ctrlID = 'txtDeadline';
                }
                if (Section == 'BudgetApproved') {
                    ctrlID = 'txtApproved';
                }

                UpdateMultiSelectDropDownVal_ByText(Value, ctrlID);
            }
            GetBudgetDetails();
            localStorage.setItem('GraphFilterData', null);
        }
    } else {
        //  GetBudgetDetails();
    }
});





$('#btnFilter').click(function () {
    GetBudgetDetails();
    //  GetSupplierDetails();
    $('#closeFilter').click();
    //$('.select').val(0).change();
});


$('#btnDelete').click(function () {
    var val = [];
    $(':checkbox:checked').each(function (i) {
        val[i] = $(this).val();
        //$("#btnEdit").hide();
        DeleteBudget($(this).attr('name'));
        //$(".cb-element").prop("checked", false);
        //  alert($(this).val());
    });
});

//Get BudgetType Lists
function GetBudgetType() {
    debugger
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Budget/GetBudgetTypeLists',
        dataType: "json",
        success: function (data) {
            $('#ddlBudgetType').html("").append('<option value="0">Select</option>');

            $(data).each(function () {
                $('#ddlBudgetType').append('<option value="' + this.budgettype_id_pk + '">' + this.budgettype + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching in budget type.');
        }
    });
};

// Get the selected value
$('#ddlBudgetCategory').on('change', function (e) {
    debugger
    var selectedValue = $(this).val();
    // var id = e.params.data.id;
    var id = selectedValue[selectedValue.length - 1];
    GetSubBudgetCategory(id);
});
//Get Budget category
function GetBudgetCategory() {
    debugger
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Budget/GetBudgetCategoryLists',
        dataType: "json",
        success: function (data) {
            $('#ddlBudgetCategory').html("").append('<option value="0">Select</option>');

            $(data).each(function () {
                $('#ddlBudgetCategory').append('<option value="' + this.b_category_pk + '">' + this.budget_category + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching in budget category.');
        }
    });
};
// Get Budget SubCategory

function GetSubBudgetCategory(id) {
   // debugger
    // var id = val.value;
    // var id = e.params.data.id;
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Budget/GetBudgetSubCategoryLists/' + id,
        dataType: "json",
        success: function (data) {
            $('#ddlBudgetSubCategory').html("").append('<option value="0">Select</option>');

            $(data).each(function () {
                $('#ddlBudgetSubCategory').append('<option value="' + this.b_Subcategory_pk + '">' + this.budget_Subcategory + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching in budget Subcategory.');
        }
    });
};
//GET BUDGET DEADLINE
function GetDealineBudget() {
    debugger
    $.ajax({
        type: "GET",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Budget/GetDeadlineBudgetFilter',
        dataType: "json",
        success: function (data) {
            $('#txtDeadline').html("").append('<option value="0">Select</option>');

            $(data).each(function () {
                $('#txtDeadline').append('<option value="' + this.budget_id_pk + '">' + this.dead_line + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching budget deadlines.');
        }
    });
}
//GET APPROVED BUDGET
function GetApprovedBudget() {
    debugger
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Budget/GetAppBudgetFilter',
        dataType: "json",
        success: function (data) {
            $('#txtApproved').html("").append('<option value="0">Select</option>');

            $(data).each(function () {
                $('#txtApproved').append('<option value="' + this.budget_id_pk + '">' + this.approved_budget + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching in budget Approved.');
        }
    });
};
//DELETE BUDGET
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
            DeleteBudget(id);
            //alert('Delete');
        } else {
            //alert('Safe');
            //location.reload();
        }
    });
};
function DeleteBudget(Budget_id) {
    var parm = {
        "budget_id_pk": Budget_id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Budget/DeleteBudgetById',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.ID == "1") {
                swal.fire({
                    title: 'Success',
                    text: data.BUDGETSTATUS,
                    icon: 'success'
                }).then(function () {
                    GetBudgetDetails();
                });
            } else {
                swal.fire({
                    title: 'Warning',
                    text: data.BUDGETSTATUS,
                    icon: 'warning'
                });
            }
        },
        error: function (result) {
            alert("Error Occured");
        }
    });
};
//GET BUDGET DETAILS
function GetBudgetDetails() {
    let cat = null, SubCat = null, Bgttype = null, Deadline = null, AppBudget = null;
    let ar = [];
    $("#ddlBudgetCategory option:selected").each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        cat = ar.toString();
    }

    ar = [];
    $("#ddlBudgetSubCategory option:selected").each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        SubCat = ar.toString();
    }

    ar = [];
    $("#ddlBudgetType option:selected").each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        Bgttype = ar.toString();
    }
    $("#txtDeadline option:selected").each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        Deadline = ar.toString();
    }
    $("#txtApproved option:selected").each(function () {
        if ($(this).val() != 0) {
            ar.push($(this).val());
        }
    });
    if (ar.length > 0) {
        AppBudget = ar.toString();
    }

    let parm = {
        'budget_category': cat,
        'budget_Subcategory': SubCat,
        'budgettype': Bgttype,
        'dead_line': Deadline,
        'approved_budget_filter': AppBudget,

    };
    let josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Budget/GetFilteredBudgetDetails',
        dataType: "json",
        data: josnstr,

        success: function (data) {
            //alert(data.status);
            console.log(data);
            var table;
            if ($.fn.dataTable.isDataTable('#tblBudgetDetails')) {
                table = $('#tblBudgetDetails').DataTable();
            } else {
                table = $('#tblBudgetDetails').DataTable();
            }

            table.destroy();
            $("#tblBudgetDetails").DataTable({
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
                        data: 'budget_id_pk',
                        sWidth: '2px',
                        sClass: "view",
                        bSortable: false,
                        render: function (budget_id_pk) {
                            return '<input id="check" class="cb-element checkbox" name="' + budget_id_pk + '" type="checkbox">';  // <button class="btn btn-xs btn-success grid-buttons btnedit" name="' + catogory_id_pk + '" style="margin-right:5px;"><i class="fa fa-edit icon-ser"></i></button>
                        }
                    },
                    { data: 'budget_id_pk', sWidth: '60px' },
                    { data: 'budgettype', },
                    { data: 'budget_category' },
                    { data: 'budget_Subcategory' },
                    { data: 'approved_budget' },
                    {
                        data: 'dead_line',
                        render: function (data) {
                            return moment(data).format('MM/DD/YYYY');
                        }
                    },


                    { data: 'budgetOwner' },
                    { data: 'Description' },
                   
                    {
                        data: 'budget_id_pk',
                        render: function (budget_id_pk, type, row) {
                            return '<a class="btnDelete" href="#" onclick="ConfirmDelete(' + budget_id_pk + ')"> \
                                   <i class="fa fa-trash" data-toggle="tooltip" title="Delete" style="font-size:17px;color:red;"></i> \
                                    </a>&nbsp;<a class="btnEdit" href="/BudgetManagement/EditBudget?budget_id_pk=' + budget_id_pk + '"> \
                                     <i class="fa fa-edit" data-toggle="tooltip" title="Edit" style="font-size:17px;color:blue;"></i> \
                                    </a>';
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
}
