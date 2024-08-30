$(document).ready(function () {
    var id = 66;
    $.session.get('budget_id_pk');
    //GetBudgetType();
    //GetBudgetOwnerList();
    //GetBudgetCategory();

    console.log("Budget ID from session: ", id); // Add this line for debugging
    
    if (id) {
        GetBudgetDetailsEdit(id);
    } else {
        alert("No budget ID found in session.");
    }

    $("#btnUpdate").click(function () {
        UpdateBudgetDetails(id);
    });
    $("#ddlBudgetCategory").change(function () {
        $('#ddlBudgetSubCategory').empty();
        if ($(this).val() != 0) {
            GetSubBudgetCategory($(this).val());
        } else {
            $("#ddlBudgetSubCategory").html("").append('<option value="0">Select Sub Category</option>');
        }
    });
})

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


function GetBudgetDetailsEdit(id) {
    debugger
    console.log("Fetching details for budget ID: ", id); // Add this line for debugging
    var parm = {
        'budget_id_pk': id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "POST",
        url: apiurl + 'api/Budget/GetBudgetrDetailsEdit',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            $("#ddlBudgetType").val(data.budget_type).change();
            $("#ddlBudgetCategory").val(data.category).change();
            $("#ddlBudgetSubCategory").val(data.Subcategory).change();
            $("#ddlOnwer").val(data.budgetOwner).change();
            $("#txtDeadline").val(data.dead_line).change();
            $("#txtNotes").val(data.Description).change();
            $("#txtApproved").val(data.approved_budget).change();
        },
        error: function (edata) {
            alert("Error while fetching record.");
        }
    });

    //function UpdateBudgetDetails(id) {
       
    //    var parm = {
    //        "budget_id_pk": id,
    //        "budget_type": $("#ddlBudgetType option:selected").val(),
    //        "category": $("#ddlBudgetCategory option:selected").val(),
    //        "Subcategory": $("#ddlBudgetSubCategory option:selected").val(),
    //        "budgetOwner": $("#ddlOnwer option:selected").val(),
    //        "dead_line": $("#txtDeadline").val().trim(),
    //        "txtNotes": $("#Description").val().trim(),
    //        "txtApproved": $("#approved_budget").val().trim(),
    //    };
    //    var josnstr = JSON.stringify(parm);
    //    $.ajax({
    //        type: "Post",
    //        data: josnstr,
    //        async: false,
    //        dataType: "json",
    //        contentType: "application/json; charset=utf-8",
    //        url: apiurl + 'api/Budget/UpdateBudgetDetails',
    //        success: function (data) {
    //            if (data.status_id == 1) {
    //                swal.fire({
    //                    title: 'Success',
    //                    text: data.status,
    //                    icon: 'success'
    //                }).then(function () {
    //                    location.href = '/BudgetManagement/Index';
    //                });
    //            } else {
    //                warningnotify(data.status);
    //            }
    //        },
    //        error: function (result) {
    //            alert("Error : data");
    //        }
    //    });
   // };
}
