$(document).ready(function () {
    GetBudgetType();
    GetBudgetCategory();
    GetBudgetOwnerList();

    $("#ddlBudgetCategory").change(function () {
        $('#ddlBudgetSubCategory').empty();
        if ($(this).val() != 0) {
            GetSubBudgetCategory($(this).val());
        } else {
            $("#ddlBudgetSubCategory").html("").append('<option value="0">Select Sub Category</option>');
        }
    });
    $("#btnSubmit").click(function () {
       // InsBudgetData();

        if (ValidateBudget() == true) {
            InsBudgetData();
        }
    });

    var minDate = new Date();
    $('#txtDeadline').datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: minDate

    })

});

const apiurl1 = 'http://localhost:49708/';
// get budget type list

function GetBudgetType() {
    debugger
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl1 + 'api/Budget/GetBudgetTypeLists',
        dataType: "json",
        success: function (data) {
            $(data).each(function () {
                $('#ddlBudgetType').append('<option value="' + this.budgettype_id_pk + '">' + this.budgettype + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching in budget type.');
        }
    });
};


// get owner
function GetBudgetOwnerList() {
    debugger
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl1 + 'api/Budget/GetBudgetOwner',
        dataType: "json",
        success: function (data) {
            $(data).each(function () {
                $('#ddlOnwer').append('<option value="' + this.Onwer_id_pk + '">' + this.Onwer_name + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching in budget type.');
        }
    });
};

// get category list

function GetBudgetCategory() {
    debugger
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl1 + 'api/Budget/GetBudgetCategoryLists',
        dataType: "json",
        success: function (data) {
            $(data).each(function () {
                $('#ddlBudgetCategory').append('<option value="' + this.b_category_pk + '">' + this.budget_category + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching in budget category.');
        }
    });
};



//get Sub Category

function GetSubBudgetCategory(id) {
    debugger
    $.ajax({
        type: "Get",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: apiurl1 + 'api/Budget/GetBudgetSubCategoryLists/' + id,
        dataType: "json",
        success: function (data) {
            $(data).each(function () {
                $('#ddlBudgetSubCategory').append('<option value="' + this.b_Subcategory_pk + '">' + this.budget_Subcategory + '</option>');
            });
        },
        error: function (result) {
            alert('Error fetching in budget category.');
        }
    });
};




// insert data

function InsBudgetData() {
    debugger
    var parm = {
        "budget_type": $("#ddlBudgetType").val().trim(),
        "category": $("#ddlBudgetCategory").val().trim(),
        "Subcategory": $("#ddlBudgetSubCategory").val().trim(),
        "budgetOwner": $("#ddlOnwer").val().trim(),
        "dead_line": $("#txtDeadline").val().trim(),
        "Description": $('#txtNotes').val(),
        "approved_budget": $("#txtApproved").val().trim(),
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Budget/InsertBudgetList',
        success: function (data) {
          // alert("Inserted Successfully");
                if (data != 0)
                {
                     // alert(data.status);
                    swal.fire({
                        title: 'Success',
                        text: ' Inserted suceccfully',
                        icon: 'success'
                    }).then(function () {
                       // $('#closedModel').click();
                        //$("#ClrTicket").find("input").val("");
                        //$("#ClrTicket").find("select").val(0).change();
                        window.location.href = "/BudgetManagement/Index"
                    });
            }
                else {
                     alert(data);
                }
        },
        error: function (result) {
            alert("Error : data");
        }
    });



}

// Validation Budget
function ValidateBudget() {
    var return_val = true;
    if ($('#ddlBudgetType').val().trim() == "" || $('#ddlBudgetType').val() == null) {
        $('#SpnBudgetType').show();
        return_val = false;
    } else {
        $('#SpnBudgetType').hide();
    }

    if ($('#ddlBudgetCategory').val().trim() == "" || $('#ddlBudgetCategory').val() == null) {
        $('#SpnBudgetCategory').show();
        return_val = false;
    } else {
        $('#SpnBudgetCategory').hide();
    }

    if ($('#ddlBudgetSubCategory').val().trim() == "" || $('#ddlBudgetSubCategory').val() == null) {
        $('#SpnBudgetCategory').show();
        return_val = false;
    } else {
        $('#SpnBudgetCategory').hide();
    }
    if ($('#ddlOnwer').val().trim() == "" || $('#ddlOnwer').val() == null) {
        $('#SpnOnwer').show();
        return_val = false;
    } else {
        $('#SpnOnwer').hide();
    }

    if ($('#txtApproved').val().trim() == "" || $('#txtApproved').val() == null) {
        $('#SpnApproved').show();
        return_val = false;
    } else {
        $('#SpnApproved').hide();
    }

    if ($('#txtDeadline').val().trim() == "" || $('#txtDeadline').val() == null) {
        $('#SpnDeadline').show();
        return_val = false;
    } else {
        $('#SpnDeadline').hide();
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

