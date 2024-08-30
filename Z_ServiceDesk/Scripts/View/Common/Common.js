var idleTime = 0;

$(document).ready(function () {
    PagePermissions();
    $("#BtnSlide").click();
    //$(".open-left").click();
    //$('.select2').select2(
    //    { dropdownParent: $('#myModalNew') });
    // $('.select').select2();
    //var id = $.session.get("user_code");
    //var number = id.substring(4);
    // $(".user-name").html("").html("<p>" + $.session.get("emp_f_name") + "<span>Administrator</span></p>");
    //alert($.session.get("emp_state"));
    //if ($.session.get("emp_code") != undefined) {
    //    $(".hidden-xs").text("").text($.session.get("emp_f_name"));
    //    $(".user-header").find("p").text($.session.get("emp_f_name"));
    //};
    if ($.session.get("id") != undefined) {
        $(".user-name").text("").text($.session.get("name"));
        $(".user-name").find("p").text($.session.get("name"));
    };
    //if ($.session.get("roleid") == 0 || $.session.get("roleid") == undefined) { 
    //    $("#MenuConfiguration").hide();
    //    $("#MenuFeedback").hide();
    //    $("#MenuSla").hide();
    //    $(".btndelete").hideupdate
    //};
    //alert($.session.get("roleid"));
    //if ($.session.get("id") == undefined) {
    //    window.location.href = "/Login/Index/";
    //} 

    // Numeric 
    $(document).on('keypress', '.numericonly', function (e) {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });
    //Number
    $(document).on('keypress', '.numberonly', function (e) {
        $(this).val($(this).val().replace(/[^\d].+/, ""));
        if ((event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });
    //Date picker
    //$('.datepicker').datepicker({
    //    //autoclose: true,
    //    format: "yyyy-mm-dd",
    //    forceParse: false,
    //  //  startDate: '01/01/2017',// '1900/01/01',
    //   // endDate: '+1d',
    //    autoclose: true,
    //    todayHighlight: true
    //});
    // $(".js-example-basic-multiple").select2();
    // GetDefaultLocation();


    //Increment the idle time counter every minute.
    var idleInterval = setInterval(timerIncrement, 60000); // 1 minute

    //Zero the idle timer on mouse movement.
    $(this).mousemove(function (e) {
        idleTime = 0;
    });
    $(this).keypress(function (e) {
        idleTime = 0;
    });
});



function onlyNumbersWithColon(e) {
    var charCode;
    if (e.keyCode > 0) {
        charCode = e.which || e.keyCode;
    }
    else if (typeof (e.charCode) != "undefined") {
        charCode = e.which || e.keyCode;
    }
    if (charCode == 58)
        return true
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function SaveSuccess() {
    swal({
        title: 'Done',
        text: 'Saved Successfully',
        type: 'success',
        // showCancelButton: true,
        confirmButtonText: 'Ok',
        //cancelButtonText: 'Not at all'
    });
};
function DeleteSuccess(txt) {
    Swal.fire(
        'Deleted',
        txt,
        // 'You clicked the button!',
        'delete'
    )
};
function RequiredField(txt) {
    Swal.fire({
        icon: 'error',
        title: 'Required',
        text: txt,
        type: 'error',
        // showCancelButton: true,
        confirmButtonText: 'Ok',
        //footer: 'Something went wrong'
        //cancelButtonText: 'Not at all'
    });
};
function successnotify(txt) {
    Swal.fire(
        'Success!',
        txt,
        // 'You clicked the button!',
        'success'
    )
};
function warningnotify(txt) {
    swal({
        title: 'Warning',
        text: txt, //'Created Successfully',
        type: 'warning',
        // showCancelButton: true,
        confirmButtonText: 'Ok',
        //cancelButtonText: 'Not at all'
    });
};
function CreateSuccess(txt) {
    swal({
        title: 'Done',
        text: txt, //'Created Successfully',
        type: 'success'
        // showCancelButton: true,
        //confirmButtonText: 'Ok',
        //cancelButtonText: 'Not at all'
    });
};
function errornotify(message) {
    $.notice({
        //canAutoHide: true,
        holdup: "9000",
        // fadeTime: "500",
        //canFadeHover: true,
        //hasCloseBtn: true,
        //canCloseClick: false,
        //position: 'top-right',
        //zIndex: '9999',
        //custom: ''
        text: message,
        type: "error"
    });
};
//function successnotify(message) {
//    $.notice({
//        holdup: "9000",
//        text: message,
//        type: "success"
//    });
//};

//function warningnotify(message) {
//    $.notice({
//        holdup: "10000",
//        text: message,
//        type: "warning"
//    });
//};
function infonotify(message) {
    $.notice({
        text: message,
        type: "info"
    });
};
// Send Payment Request
function SendPaymentRequest(tomail, url, name) {
    var parm = {
        "Tomail": tomail,
        "Name": name,
        "Url": url,
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        // url: apiurl + 'Controllers/Email/SendPaymentRequest',
        url: apiurl + 'api/Email/SendPaymentRequest',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
        }
    });
};
//Send Mail from index page to initior
function SendEmail(tomail, name, businessname, contact_number, url) {
    var parm = {
        "Tomail": tomail,
        "Name": name,
        "BusinessType": businessname,
        "Url": url,
        "contact_number": contact_number
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        // url: apiurl + 'Controllers/Email/SendPasswordLink',
        url: apiurl + 'api/Email/SendPaymentRequest',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail from index page to Sales team
function SendmailToAdmin(mail, name, businessname, contact_number) {
    var parm = {
        "Tomail": SalesMailid,
        "FromMail": mail,
        "Name": name,
        "BusinessType": businessname,
        "contact_number": contact_number
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        // url: apiurl + 'Controllers/Email/SendmailToAdmin',
        url: apiurl + 'api/Email/SendmailToAdmin',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
// This method is used to send mail to all directors after submitted the application from submitapplication page.
function sendSatusMail() {
    var parm = {
        "user_mst_fk": $.session.get("user_mst_pk")
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        // url: apiurl + 'Controllers/Email/sendSatusMail',
        url: apiurl + 'api/Email/sendSatusMail',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function () {
            alert("error while Sending mail.");
        }
    });
};
//Send Mail When New Ticket Create
function SendEmailTicketCreate(receiptemail, ticketid, username, ticketstatus) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "TicketId": ticketid,
        "Name": username,
        "Status": ticketstatus
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendNewTicketsCreate',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail When New Service Request Create
function SendNewServiceRequestCreate(receiptemail, servicereqid, username, ticketstatus) {
    debugger;
    var parm = {
        "ReceiptEmail": receiptemail,
        "ServiceRequestId": servicereqid,
        "Name": username,
        "Status": ticketstatus
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendNewServiceRequestCreate',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail When Change Status Service Request 
function SendServiceRequestChangeStatus(receiptemail, servicereqid, username, servicereqstatus) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "ServiceRequestId": servicereqid,
        "Name": username,
        "Status": servicereqstatus
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendServiceRequestChangeStatus',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail When Change Status Aprooved Service Request 
function SendServiceRequestChangeStatusAprooved(receiptemail, servicereqid, username, servicereqstatus, url) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "ServiceRequestId": servicereqid,
        "Name": username,
        "Status": servicereqstatus,
        "Url": url
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendServiceRequestChangeStatusAprooved',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail For Status Aprooved Or Reject Service Request 
function SendServiceRequestChangeStatusAproovedOrRejected(receiptemail, servicereqid, subject, useremail, url1, url2) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "ServiceRequestId": servicereqid,
        "Subject": subject,
        "UserEmail": useremail,
        // "ApproverID" : approverid, 
        "UrlApp": url1,
        "UrlRej": url2
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendServiceRequestChangeStatusAproovedOrRejected',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail TO User For Technician Predefine Reply Status
function SendEmailTicketReplyStatus(receiptemail, ticketid, description) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "TicketId": ticketid,
        "Description": description
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailTicketReplyStatus',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail TO User For Technician Predefine Reply Status
function SendEmailServiceRequestReplyStatus(receiptemail, ccEmail, requestid, description,downloadpath) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "RequestID": requestid,
        "Description": description,
        "CCEmail": ccEmail,
        "Url": downloadpath
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailServiceRequestReplyStatus',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//to insert exception
function InsException(status, message, exception_message, exception_type) {
    var parm = { "status": status, "message": message, "exception_message": exception_message, "exception_type": exception_type };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        // url: apiurl + 'Controllers/Commonapi/InsException',
        url: apiurl + 'api/Commonapi/InsException',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (error) {
        }
    });
};
// Send Email To user For Ticket Create And Change Status
function SendNewTickets(receiptemail, ticketid, username, ticketstatus, assign_to) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "TicketId": ticketid,
        "Name": username,
        "Status": ticketstatus,
        "Assign": assign_to
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        // url: apiurl + 'Controllers/Email/SendCourierDetails',
        url: apiurl + 'api/Email/SendNewTickets',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

// Send Email To user For Ticket Create And Change Status
//To_Email,TicketId,Subject,Name,Email,Contact,Location
function SendTicketsAssignTechnician(receiptemail, ticketid, subject, name, email, contact, location) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "TicketId": ticketid,
        "Subject": subject,
        "Name": name,
        "Email": email,
        "Contact": contact,
        "Location": location
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        // url: apiurl + 'Controllers/Email/SendCourierDetails',
        url: apiurl + 'api/Email/SendTicketAssignToTechnician',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail to technician.");
        }
    });
};
//Send Mail TO User for Change GatePass Status
function SendEmailChangeGatePassStatus(receiptemail, GatePassID, MomentType, GatePasType, Name, ApproverName, ApproverLevel) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "GatePassID": GatePassID,
        "MomentType": MomentType,
        "GatePasType": GatePasType,
        "Name": Name,
        "ApproverName": ApproverName,
        "ApproverLevel": ApproverLevel
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeGatePassStatus',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail To User for Change Service Request Status
function SendEmailChangeStatus_SR(receiptemail, ID, ServiceRequestID, Title, RequestDescription, Category, SubCategory, UserName, ApproverName, ApproverLevel, ApproverComments, ApproverComments1, ApproverComments2) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "ID": ID,
        "ServiceRequestId": ServiceRequestID,
        "Title": Title,
        "RequestDescription": RequestDescription,
        "Category": Category,
        "SubCategory": SubCategory,
        "UserName": UserName,
        "ApproverName": ApproverName,
        "ApproverLevel": ApproverLevel,
        "StatusComments": ApproverComments,
        "StatusComments1": ApproverComments1,
        "StatusComments2": ApproverComments2
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeStatus_SR',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            swal.fire({
                title: 'Success',
                text: 'Email Sent Successfully.',
                icon: 'success'
            });

            setTimeout(function () {
                location.reload(true)
            }, 3000);
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail TO User for Change Purchase Order Status
function SendEmailChangeStatus_PO(receiptemail, PurchaseOrderID, POName, ApproverName, ApproverLevel,ID) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "PurchaseOrderID": PurchaseOrderID,
        "POName": POName,
        "ApproverName": ApproverName,
        "ApproverLevel": ApproverLevel,
        "ID": ID
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangePurchaseOrderStatus',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            swal.fire({
                title: 'Success',
                text: 'Email sent successfully!!',
                icon: 'success'
            }).then(function () {
                window.location.reload(true);
            });
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};



//Send Mail TO GatePass Creator for GatePass Action taken by Approver
function SendEmailChangeGatePassActionNotification(receiptemail, GatePassID, Name, ApproverName, ApproverLevel) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "GatePassID": GatePassID,
        "Name": Name,
        "ApproverName": ApproverName,
        "ApproverLevel": ApproverLevel
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeGatePassStatusChangeNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail TO User for Change GatePass Status
function SendEmailChangeGatePassStatusFirst(receiptemail, GatePassID, MomentType, GatePasType, Name) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "GatePassID": GatePassID,
        "MomentType": MomentType,
        "GatePasType": GatePasType,
        "Name": Name
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeGatePassStatusFirst',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail TO User for Change GatePass Status
function SendEmailChangeGatePassStatusSc(receiptemail, GatePassID, MomentType, GatePasType, Name) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "GatePassID": GatePassID,
        "MomentType": MomentType,
        "GatePasType": GatePasType,
        "Name": Name
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeGatePassStatusSc',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail TO Approval for Request Approval Status
function SendEmailRequestApprovalStatus(receiptemail, ID, Subject, ContactNo, Email) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "ReqID": ID,
        "Subject": Subject,
        "ContactNo": ContactNo,
        "Email": Email
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailRequestApprovalStatus',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail TO User for Change GatePass Status 
function SendEmailChangeGatePassStatusSecond(receiptemail, GatePassID, MomentType, GatePasType, Name) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "GatePassID": GatePassID,
        "MomentType": MomentType,
        "GatePasType": GatePasType,
        "Name": Name
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeGatePassStatusThird',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            // window.location.href = "/Inventory/GetPass";
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
// Send Email To Technitian For Ticket Status Not Resolved
function SendEmailTicketStatusNotResolved(receiptemail, ticketid, username, sub, assignto, ticketstatus, remtime) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "TicketId": ticketid,
        "UserName": username,
        "Subject": sub,
        "AssignTo": assignto,
        "TicketStatus": ticketstatus,
        "Remaining_Time": remtime
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        // url: apiurl + 'Controllers/Email/SendCourierDetails',
        url: apiurl + 'api/Email/SendEmailTicketStatusNotResolved',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail for New Change Request
function SendNewChangeRequestNotification(ChangeID) {
    var parm = {
        "ChangeID": ChangeID
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendNewChangeRequestNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail for Change Request Status Change
function SendChangeRequestStatusChangeNotification(ChangeID, OldStatus, NewStatus) {
    var parm = {
        "ChangeID": ChangeID, "OldStatus": OldStatus, "NewStatus": NewStatus
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendChangeRequestStatusChangeNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail for Change Request Review
function SendChangeRequestReviewNotification(ChangeID, UserID, StageID) {
    var parm = {
        "ChangeID": ChangeID,
        "UserID": UserID,
        "StageID": StageID
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendChangeRequestReviewNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail for New Problem Ticket
function SendNewProblemTicketNotification(ProblemID) {
    var parm = {
        "ProblemID": ProblemID
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendNewProblemTicketNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail for Problem Ticket Status Change
function SendProblemTicketStatusChangeNotification(ProblemID, OldStatus, NewStatus) {
    var parm = {
        "ProblemID": ProblemID, "OldStatus": OldStatus, "NewStatus": NewStatus
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendProblemStatusChangeNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Get Default Location 
function GetDefaultLocation() {
    $.ajax({
        type: "Get",
        url: apiurl + 'api/Peripherals/GetDefaultLocation',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('.ddlLocation').html("").append('<option value=' + data.location_id_pk + '>' + data.location_name + '</option>');

        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};
$("#adminlogout").click(function () {
    // UpdateTechnicianSessionId($.session.get("id"));
    LogOut();
});


// Update Technician Session id
function UpdateTechnicianSessionId(id) {
    var parm = {
        "id": id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Login/UpdateTechnicianSessionId',
        success: function (data) {
            if (data.status_id != 0) {
                CreateSuccess(data.status);
            } else {
                CreateSuccess(data.status);
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });
};
//
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}


function ValidateNumber(ctrl, DecimalPrecision) {
    var input = $(ctrl);
    var newval = input.val();

    if (!$.isNumeric(newval)) {
        input.val(newval.substr(0, newval.length - 1));
    }

    if (newval.indexOf(".") !== -1) {
        parts = newval.split(".");
        if (parts[1].length > DecimalPrecision) {
            if (DecimalPrecision == 0) {
                input.val(newval.substr(0, newval.length - 2));
            }
            else {
                input.val(newval.substr(0, newval.length - 1));
            }
        }
    }
}

function UpdateMultiSelectDropDownVal(Val, Id) {
    //
    var dropdownVal = Val.split(",");

    ////for (var i = 0; i < dropdownVal.length; i++) {
    ////    $("#" + Id).find('option[value="' + dropdownVal[i] + '"]').attr('selected', 'selected').change();
    ////}

    for (var i = 0; i < dropdownVal.length; i++) {
        $('#' + Id + ' option').each(function () {
            if ($(this).text() == dropdownVal[i]) {
                $("#" + Id).find('option[value="' + $(this).val() + '"]').attr('selected', 'selected').change();
            }
        });
    }
    $("#" + Id).multiselect('reload');
}

function GetDropDownID_ByEmail(Val, Id) {
    var ID = 0;
    ID = $("#" + Id).find("option:contains(" + Val + ")").val();
    return ID;
}

$('#tblFixedAsset').on('page.dt', function () {

    setTimeout(function () {
        //code goes here
        PagePermissions();
    }, 1000);
});

function PagePermissions() {
    
    //debugger;
    var pageDetails = JSON.parse(localStorage.getItem('UserSessionData'));
    var PageExists = 0;
    if (pageDetails == null) {
        window.location.href = "../Home/NoPermission";
    }
    var pagName = window.location.pathname;
    var c = 0;
    $.each(pageDetails, function (index, value) {
        if (value.PartURL == pagName) {
            var Add = value.Add;
            var View = value.View;
            var Edit = value.Edit;
            var Delete = value.Delete;

            if (Add == false) {
                ////$('.AddUser').hide();
                $('.btnAddNew').hide();
            }

            if (View == false) {
                window.location.href = "../Home/NoPermission";

            }

            if (Edit == false) {
                $('.editview').attr("onclick", null).off("click");
                $('.btnedit').attr("onclick", null).off("click");
               // $('.btnedit').hide();
                $('.editview').attr("href", 'javascript:#');
                $('.btnedit').attr("href", 'javascript:#');
                $('.btnedit').hide();
                //$('.editview').addClass('dis-none');
            }

            if (Delete == false) {
                ////$('.btnDelete').hide();
                $('#btnDelDuplicate').hide();
                $('.btnDelete').attr("onclick", null).off("click");
                $('.btnDelete').hide();
            }

            PageExists = PageExists + 1;
        }
    });

    var UserSession = JSON.parse(localStorage.getItem('UserSession'));
    if (UserSession != null) {
        GetUserPageControlPermissionsRequest(UserSession[0].UserRole, pagName);
    }

    ////if (PageExists == 0) {
    ////    window.location.href = "../Home/NoPermission";
    ////}
}

////function GetUserSessionDetails() {
//    $.ajax({
//        type: "Get",
//        async: false,
//        url: '/Home/GetSessionDetails',
//        //data: josnstr,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            if (data.length > 0 && data != null) {
//                var ID = data[0].id;
//            }
//        },
//        error: function (edata) {
//            alert("error while feching record.");
//        }
//    });
//};

function SetUserRolePermissionsRequest(id) {
    //
    var parm = {
        "ID": id
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        async: false,
        url: apiurl + 'api/UserRolePermissions/SetUserRolePermissonsDetails',
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            ////
            if (data != null) {
                var SessionData = data;

                localStorage.setItem('UserSessionData', SessionData);
            }
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

function GetUserPageControlPermissionsRequest(RoleID, PageUrl) {

    var parm = {
        "user_role_id_fk": RoleID, "PathURL": PageUrl
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
            //
            if (data != null) {
                $.each(data, function (index, value) {
                    //$('#' + data[index].ControlID).css('display', data[index].Visibility);

                    if (data[index].Visibility == 'none') {
                        $('#' + data[index].ControlID).hide();
                        $('#' + data[index].ControlID).addClass('dis-none');
                        $('.' + data[index].ControlID).hide();
                        $('.' + data[index].ControlID).addClass('dis-none');
                    }
                    else {
                        $('#' + data[index].ControlID).show();
                        $('.' + data[index].ControlID).show();
                    }
                });
            }
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

function DisplayErrorModal(lblID, ModalID, Message) {
    $('#' + lblID).text("");
    $('#' + lblID).text(Message);
    $('#' + lblID).removeClass('Duplicate').addClass('Success');
    $('#' + ModalID).modal('show');
}

function DisplaySuccessModal(lblID, ModalID, Message) {
    $('#' + lblID).text("");
    $('#' + lblID).text(Message);
    $('#' + lblID).removeClass('Success').addClass('Duplicate');
    $('#' + ModalID).modal('show');
}

function HideModal(ModalID) {
    $('#' + ModalID).modal('hide');
}

//Send Mail TO User for Change GatePass Status 
function SendEmailChangeGatePassStatusComponent(receiptemail, GatePassID, MomentType, GatePasType, Name, TicketNo, AssetType, PartNo, SerialNo, Destination, Remarks) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "GatePassID": GatePassID,
        "MomentType": MomentType,
        "GatePasType": GatePasType,
        "Name": Name,
        "TicketNo": TicketNo,
        "AssetType": AssetType,
        "PartNo": PartNo,
        "SerialNo": SerialNo,
        "Destination": Destination,
        "Remarks": Remarks
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeGatePassStatusComponent',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            window.location.href = "/Inventory/GetPass";
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail TO User for Change GatePass Status 
function SendEmailChangeGatePassStatusFirstComponent(receiptemail, GatePassID, MomentType, GatePasType, Name, TicketNo, AssetType, PartNo, SerialNo, Destination, Remarks) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "GatePassID": GatePassID,
        "MomentType": MomentType,
        "GatePasType": GatePasType,
        "Name": Name,
        "TicketNo": TicketNo,
        "AssetType": AssetType,
        "PartNo": PartNo,
        "SerialNo": SerialNo,
        "Destination": Destination,
        "Remarks": Remarks
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeGatePassStatusFirstComponent',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            window.location.href = "/Inventory/GetPass";
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail TO User for Change GatePass Status 
function SendEmailChangeGatePassStatusSecondComponent(receiptemail, GatePassID, MomentType, GatePasType, Name, TicketNo, AssetType, PartNo, SerialNo, Destination, Remarks) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "GatePassID": GatePassID,
        "MomentType": MomentType,
        "GatePasType": GatePasType,
        "Name": Name,
        "TicketNo": TicketNo,
        "AssetType": AssetType,
        "PartNo": PartNo,
        "SerialNo": SerialNo,
        "Destination": Destination,
        "Remarks": Remarks
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailChangeGatePassStatusSecondComponent',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            window.location.href = "/Inventory/GetPass";
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};
//Send Mail TO Approval for Consumable Allocation
function SendConsumableAllocateNotification(receiptemail, TicketID, Category, Item, Qty, SerialNo, Username) {
    debugger;
    var parm = {
        "ReceiptEmail": receiptemail,
        "TicketID": TicketID,
        "Category": Category,
        "Item": Item,
        "Qty": Qty,
        "SerialNo": SerialNo,
        "Name": Username
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendConsumableAllocateNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            //successnotify(data.status);
            // window.location.href = "/ServiceRequests/RequestApproval";
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};


function SendSoftwareAllocateNotification(receiptemail, Item, Qty, SoftwareName, LicenseNo) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "Item": Item,
        "Qty": Qty,
        "SoftwareName": SoftwareName,
        "LicenseNo": LicenseNo
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendSoftwareAllocateNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            //successnotify(data.status);
            // window.location.href = "/ServiceRequests/RequestApproval";
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};


//Send Mail TO Approval for Consumable Allocation
function SendUserStatusChangeNotification(receiptemail, UserName, UserEmail, OldStatus, NewStatus) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "UserName": UserName,
        "UserEmail": UserEmail,
        "OldStatus": OldStatus,
        "NewStatus": NewStatus
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendUserStatusChangeNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        success: function (data) {
            //successnotify(data.status);
            // window.location.href = "/ServiceRequests/RequestApproval";
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

function DonutChart(Data, Id) {
    //
    var dateSeries = [];
    var Lable = [];
    Data.forEach(function (obj) {
        dateSeries.push(parseInt(obj.VALUE));
        Lable.push(obj.NAME);
    });
    var options = {
        chart: {
            type: 'donut',
            height: 350//280
        },
        dataLabels: {
            enabled: false
        },
        series: dateSeries,
        legend: {
            show: true,
            position: 'bottom',
            horizontalAlign: 'center',
            verticalAlign: 'middle',
            floating: false,
            fontSize: '14px',
            offsetX: 0,
            offsetY: 6
        },
        labels: Lable, plotOptions: {
            pie: {
                size: undefined,
                customScale: 1,
                offsetX: 0,
                offsetY: 0,
                expandOnClick: true,
                dataLabels: {
                    offset: 0,
                    minAngleToShowLabel: 10,
                },
                donut: {
                    size: '65%',
                    background: 'transparent',
                    labels: {
                        show: true,
                        name: {
                            show: true,
                            fontSize: '25px',
                            fontFamily: 'Helvetica, Arial, sans-serif',
                            color: undefined,
                            offsetY: -10
                        },
                        value: {
                            show: true,
                            fontSize: '20px',
                            fontFamily: 'Helvetica, Arial, sans-serif',
                            color: undefined,
                            offsetY: 16,
                            formatter: function (val) {
                                return val
                            }
                        },
                        total: {
                            show: true,
                            label: 'Total',
                            color: '#132135',
                            formatter: function (w) {
                                return w.globals.seriesTotals.reduce((a, b) => {
                                    return a + b
                                }, 0)
                            }
                        }
                    }
                },
            }
        },
        responsive: [{
            breakpoint: 450,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    }

    var chart = new ApexCharts(
        document.querySelector("#" + Id),
        options
    );
    chart.render();
};

function DonutChart_Click(Data, Id, Section) {
    //
    var dateSeries = [];
    var Lable = [];
    Data.forEach(function (obj) {
        dateSeries.push(parseInt(obj.VALUE));
        Lable.push(obj.NAME);
    });
    var options = {
        chart: {
            type: 'donut',
            events: {
                dataPointSelection(event, chartContext, config) {
                    Click(config.w.config.labels[config.dataPointIndex], Section)
                }
            },
            height: 315//280
        },
        dataLabels: {
            enabled: false
        },
        series: dateSeries,
        legend: {
            show: true,
            position: 'bottom',
            horizontalAlign: 'center',
            verticalAlign: 'middle',
            floating: false,
            fontSize: '14px',
            offsetX: 0,
            offsetY: 6
        },
        labels: Lable, plotOptions: {
            pie: {
                size: undefined,
                customScale: 1,
                offsetX: 0,
                offsetY: 0,
                expandOnClick: true,
                dataLabels: {
                    offset: 0,
                    minAngleToShowLabel: 10,
                },
                donut: {
                    size: '65%',
                    background: 'transparent',
                    labels: {
                        show: true,
                        name: {
                            show: true,
                            fontSize: '25px',
                            fontFamily: 'Helvetica, Arial, sans-serif',
                            color: undefined,
                            offsetY: -10
                        },
                        value: {
                            show: true,
                            fontSize: '20px',
                            fontFamily: 'Helvetica, Arial, sans-serif',
                            color: undefined,
                            offsetY: 16,
                            formatter: function (val) {
                                return val
                            }
                        },
                        total: {
                            show: true,
                            label: 'Total',
                            color: '#132135',
                            formatter: function (w) {
                                return w.globals.seriesTotals.reduce((a, b) => {
                                    return a + b
                                }, 0)
                            }
                        }
                    }
                },
            }
        },
        responsive: [{
            breakpoint: 450,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    }

    var chart = new ApexCharts(
        document.querySelector("#" + Id),
        options
    );
    chart.render();
};

function Click(Text, Section) {
    debugger;
    var PageRedirectData = [];

    PageRedirectData.push({
        GraphValue: Text,
        Section: Section,
    });

    localStorage.setItem('GraphFilterData', JSON.stringify(PageRedirectData));

    if (Section == 'AssetBySupportType' || Section == 'AssetByStatus' || Section == 'AssetByCategory' || Section == 'AssetByVendor' || Section == 'AssetByLife' || Section == 'AssetByLife_Expiry' || Section == 'AssetByBU' || Section == 'AssetByPurchaseHistory' || Section == 'AssetBySubLocation' || Section == 'AssetByWarranty' || Section == 'PatchStatus') {
        window.location.href = "/Inventory/FixedAssets";
    }
    else if (Section == 'VendorCategoryPie' || Section == 'VendorLocationChart' || Section == 'VendorStatusPie') {
        window.location.href = "/VendorManagement/Index";
    }
    else if (Section == 'BudgetCategory' || Section == 'BudgetSubCategory' || Section == 'BudgetType' || Section == 'BudgetDeadLine' || Section =='BudgetApproved') {
        window.location.href = "/BudgetManagement/Index";
    }
    else if (Section == 'AssetByOS') {
        window.location.href = "/Patch/AutoDiscovery";
    }
    else if (Section == 'informationMissing' || Section == 'Mapped') {
        window.location.href = "/Patch/AutoDiscovery";
    }
    else if (Section == 'IncidentByStatus' || Section == 'Incidents_Severity'
        || Section == 'ClosedIncidentsBySubLocation' || Section == 'OpenIncidentsbySubLocation'
        || Section == 'ClosedIncidentsBySupportDepartment' || Section == 'OpenIncidentsBySupportDepartment'
        || Section == 'ClosedIncidentsByCategory' || Section == 'OpenIncidentsByCategory'
        || Section == 'ClosedIncidentsbyLocation' || Section == 'OpenIncidentsbyLocation'
        || Section == 'OpenIncidentsBySubCategory' || Section == 'ClosedIncidentsBySubCategory'
        || Section == 'ClosedIncidentsBySupportGroup' || Section == 'OpenIncidentsBySupportGroup'
        || Section == 'ClosedIncidentsByTechnician' || Section == 'OpenIncidentsByTechnician') {
        window.location.href = "/Ticket/Index";
    }
    else if (Section == 'OpenServiceStatus' || Section == 'Service_Severity'
        || Section == 'OpenServiceTechnician' || Section == 'ClosedService_Technician'
        || Section == 'OpenService_SupportGroup' || Section == 'ClosedService_SupportGroup'
        || Section == 'OpenService_Category' || Section == 'ClosedService_Category'
        || Section == 'OpenService_SubCategory' || Section == 'ClosedService_SubCategory'
        || Section == 'OpenService_Location' || Section == 'ClosedService_Location'
        || Section == 'OpenService_SubLocation' || Section == 'ClosedService_SubLocation'
        || Section == 'OpenService_Sup_Depatment' || Section == 'ClosedService_Sup_Depatment') {
        window.location.href = "/ServiceRequest/Index";
    }
    else {
        localStorage.setItem('GraphFilterData', null);
    }
}

function RedirectToFixedAssets(AssetCategory, AssetStatus, AssetCategorySection, AssetStatusSection) {

    var PageRedirectData = [];

    PageRedirectData.push({
        GraphValue: AssetStatus,
        Section: AssetStatusSection,
    });

    PageRedirectData.push({
        GraphValue: AssetCategory,
        Section: AssetCategorySection,
    });

    localStorage.setItem('GraphFilterData', JSON.stringify(PageRedirectData));

    window.location.href = "/Inventory/FixedAssets";
}

function UpdateMultiSelectDropDownVal_ByTextIds(Val, Id) {
    var dropdownVal = Val.split(",");

    for (var i = 0; i < dropdownVal.length; i++) {
        //$("#" + Id).find("option:contains(" + dropdownVal[i] + ")").attr('selected', 'selected').change();
        $("#" + Id).find('option[value="' + dropdownVal[i] + '"]').attr('selected', 'selected').change();
    }
}

function UpdateMultiSelectDropDownVal_ByText(Val, Id) {
    ////var dropdownVal = Val.split(",");

    ////for (var i = 0; i < dropdownVal.length; i++) {
    ////    $("#" + Id).find('option[value="' + dropdownVal[i] + '"]').attr('selected', 'selected').change();
    ////}

    $("#" + Id).find("option:contains(" + Val + ")").attr('selected', 'selected').change();
}

function UpdateMultiSelectDropDownVal_BySingleVal(Val, Id) {
    ////var dropdownVal = Val.split(",");

    ////for (var i = 0; i < dropdownVal.length; i++) {
    ////    $("#" + Id).find('option[value="' + dropdownVal[i] + '"]').attr('selected', 'selected').change();
    ////}

    $("#" + Id).find('option[value="' + Val + '"]').attr('selected', 'selected').change();
}

function BarChart(Data, Id) {
    var DataName = [];
    var DataTotal = [];

    Data.forEach(function (obj) {
        DataName.push(obj.NAME);
        DataTotal.push(obj.VALUE);
    });

    var options = {
        chart: {
            height: 396,
            type: 'bar',
            stacked: false,
            toolbar: {
                show: false
            },
            zoom: {
                enabled: false
            },
            dropShadow: {
                enabled: true,
                top: 0,
                left: 5,
                bottom: 5,
                right: 0,
                blur: 5,
                color: '#45404a2e',
                opacity: 0.35
            },
        },
        responsive: [{
            breakpoint: 480,
            options: {
                legend: {
                    position: 'bottom',
                    offsetX: -10,
                    offsetY: 0
                }
            }
        }],
        plotOptions: {
            bar: {
                horizontal: false,
                endingShape: 'rounded',
                columnWidth: '45%',
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        colors: ['#87cefa', '#0099cc', '#ff9900', '#9933ff', '#00ffcc'],
        series: [{
            name: 'Total',
            data: DataTotal
        }],
        xaxis: {
            type: 'String',
            categories: DataName,
            axisBorder: {
                show: true,
                color: '#bec7e0',
            },
            axisTicks: {
                show: true,
                color: '#bec7e0',
            },
        },
        legend: {
            position: 'right',
            offsetY: 0
        },
        fill: {
            opacity: 1
        },
        grid: {
            row: {
                colors: ['transparent', 'transparent'], // takes an array which will be repeated on columns
                opacity: 0.2
            },
            borderColor: '#f1f3fa'
        }
    }

    var chart = new ApexCharts(
        document.querySelector("#" + Id),
        options

    );

    chart.render();
};

//Send Mail TO Approval for Asset Allocation
function SendAssetAllocateNotification(receiptemail, AssetID, Category, Make, Model, SerialNo, AssetTag, UpdatedBy, AssetImagePath, Remarks) {
    var parm = {
        "ReceiptEmail": receiptemail,
        "AssetID": AssetID,
        "Category": Category,
        "Make": Make,
        "Model": Model,
        "SerialNo": SerialNo,
        "AssetTag": AssetTag,
        "UpdatedBy": UpdatedBy,
        "AssetImagePath": AssetImagePath,
        "Remarks": Remarks
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendAssetAllocateNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        async: false,
        success: function (data) {
            //successnotify(data.status);
            // window.location.href = "/ServiceRequests/RequestApproval";
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

//Send Mail to notify for Asset Status Change
function SendAssetStatusNotification(receiptemail, AssetID, Category, Make, Model, SerialNo, Remarks, Status, userName, location, UpdatedBy) {
    debugger
    var parm = {
        "ReceiptEmail": receiptemail,
        "AssetID": AssetID,
        "Category": Category,
        "Make": Make,
        "Model": Model,
        "SerialNo": SerialNo,
        "Remarks": Remarks,
        "Status": Status,
        "user_name": userName,
        "Location": location,
        "UpdatedBy": UpdatedBy
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendAssetStatusNotification',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: josnstr,
        async: false,
        success: function (data) {
            //successnotify(data.status);
            // window.location.href = "/ServiceRequests/RequestApproval";
            window.location.reload();
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};

function LineChart(Data, Id, dataSeries, Series, Title) {
    var options = {
        chart: {
            animations: {
                enabled: false
            },
            height: 396,
            type: "area",
            stacked: false,
            toolbar: {
                show: false
            },
            zoom: {
                enabled: false
            },
            //////dropShadow: {
            //////    enabled: true,
            //////    top: 0,
            //////    left: 5,
            //////    bottom: 5,
            //////    right: 0,
            //////    blur: 5,
            //////    color: '#45404a2e',
            //////    opacity: 0.35
            //////},
        },
        dataLabels: {
            enabled: false
        },
        series: [{ data: dataSeries }],
        //series: [
        //    {
        //        name: Series,
        //        data: dataSeries
        //    }
        //],
        markers: {
            size: 0
        },
        title: {
            text: Title,
            align: "left"
        },
        fill: {
            type: "gradient",
            gradient: {
                shadeIntensity: 1,
                inverseColors: false,
                opacityFrom: 0.5,
                opacityTo: 0,
                stops: [0, 10, 20, 30, 40, 50, 60, 65, 70, 75, 80, 85, 90, 100]
            }
        },
        ////////yaxis: {
        ////////    min: 0,
        ////////    max: 100,
        ////////    labels: {
        ////////        formatter: function (val) {
        ////////            //
        ////////            return (val).toFixed(0);
        ////////        }
        ////////    },
        ////////    title: {
        ////////        text: "Percentage"
        ////////    }
        ////////},
        xaxis: {
            type: "datetime"
        },
        tooltip: {
            shared: false,
            ////////y: {
            ////////    formatter: function (val) {
            ////////        return (val).toFixed(0);
            ////////    }
            ////////}
        }
    };

    var chart = new ApexCharts(document.querySelector("#" + Id), options);
    //$(window).resize(function () {
    //    chart.render();
    //});
    chart.render();
}

function GetEncryptedValues(id) {
    var EncryptedString = "";
    var parm = {
        "status_id": id
    };
    var josnstr = JSON.stringify(parm);

    $.ajax({
        type: "Post",
        async: false,
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Commonapi/EncryptString',
        success: function (data) {
            if (data.status != '') {
                EncryptedString = data.status;
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });

    return EncryptedString;
}

function GetDeccryptedValues(EncryptedStr) {
    //
    if (typeof EncryptedStr === 'undefined') {

    }
    else {
        var DecryptedValue = 0;
        var param = {
            "status": EncryptedStr
        };
        var josnstr1 = JSON.stringify(param);

        $.ajax({
            type: "Post",
            async: false,
            data: josnstr1,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: apiurl + 'api/Commonapi/DecryptString',
            success: function (data) {
                if (data.status_id != 0) {
                    DecryptedValue = data.status_id;
                }
            },
            error: function (result) {
                alert("Error : data");
            }
        });

        return DecryptedValue;
    }
}

function GetEncryptedValuesName(id) {
    var EncryptedString = "";
    var parm = {
        "subject": id
    };
    var josnstr = JSON.stringify(parm);

    $.ajax({
        type: "Post",
        async: false,
        data: josnstr,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Commonapi/EncryptStringName',
        success: function (data) {
            if (data.status != '') {
                EncryptedString = data.status;
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });

    return EncryptedString;
}

function GetDeccryptedValuesName(EncryptedStr) {
    //
    if (typeof EncryptedStr === 'undefined') {

    }
    else {
        var DecryptedValue = 0;
        var param = {
            "status": EncryptedStr
        };
        var josnstr1 = JSON.stringify(param);

        $.ajax({
            type: "Post",
            async: false,
            data: josnstr1,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: apiurl + 'api/Commonapi/DecryptStringName',
            success: function (data) {
                if (data.status != '') {
                    DecryptedValue = data.status;
                }
            },
            error: function (result) {
                alert("Error : data");
            }
        });

        return DecryptedValue;
    }
}

function DisplayErrorModal(lblID, ModalID, Message) {
    $('#' + lblID).text("");
    $('#' + lblID).text(Message);
    $('#' + lblID).removeClass('Duplicate').addClass('Success');
    $('#' + ModalID).modal('show');
}

function DisplaySuccessModal(lblID, ModalID, Message) {
    $('#' + lblID).text("");
    $('#' + lblID).text(Message);
    $('#' + lblID).removeClass('Success').addClass('Duplicate');
    $('#' + ModalID).modal('show');
}

function HideModal(ModalID) {
    $('#' + ModalID).modal('hide');
}

function UpdateMultiSelectDropDownVal(Val, Id) {
    //
    var dropdownVal = Val.split(",");

    for (var i = 0; i < dropdownVal.length; i++) {
        $("#" + Id).find('option[value="' + dropdownVal[i] + '"]').prop('selected', 'selected').change();
    }

    ////$("#" + Id).multiselect('reload');
};

function ValidateData(SubMenuSection, rowno) {
    var IsValid = true;
    var ErrorMsg = '';

    if (SubMenuSection == 'Compliance') {
        if ($('#txtComplianceName').val().trim() == "" || $('#txtComplianceName').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Compliance Name';
            }
            else {
                ErrorMsg = ErrorMsg + ',Compliance Name';
            }
        }

        //////if ($('#txtComplianceClauseNo').val().trim() == "" || $('#txtComplianceClauseNo').val() == null) {
        //////    if (ErrorMsg == '') {
        //////        ErrorMsg = 'Please select the mentioned fields: Compliance ClauseNo';
        //////    }
        //////    else {
        //////        ErrorMsg = ErrorMsg + ',Compliance ClauseNo';
        //////    }
        //////}

        if ($('#txtObjectiveClause').val().trim() == "" || $('#txtObjectiveClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Objective Clause';
            }
            else {
                ErrorMsg = ErrorMsg + ',Objective Clause';
            }
        }

        if ($('#txtSubClause').val().trim() == "" || $('#txtSubClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Sub Clause';
            }
            else {
                ErrorMsg = ErrorMsg + ',SubcClause';
            }
        }

        if ($('#txtControl').val().trim() == "" || $('#txtControl').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Compliance Control';
            }
            else {
                ErrorMsg = ErrorMsg + ',Compliance Control';
            }
        }

        if ($('#txtComplianceDescription').val().trim() == "" || $('#txtComplianceDescription').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Compliance Description';
            }
            else {
                ErrorMsg = ErrorMsg + ',Compliance Description';
            }
        }
    }

    if (SubMenuSection == 'PCIDSSCompliance') {
        if ($('#txtFields').val().trim() == "" || $('#txtFields').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Fields';
            }
            else {
                ErrorMsg = ErrorMsg + ',Fields';
            }
        }

        if ($('#txtRequirementClause').val().trim() == "" || $('#txtRequirementClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Requirement Clause';
            }
            else {
                ErrorMsg = ErrorMsg + ',Requirement Clause';
            }
        }

        if ($('#txtGuidance').val().trim() == "" || $('#txtGuidance').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Guidance';
            }
            else {
                ErrorMsg = ErrorMsg + ',Guidance';
            }
        }
        ////if ($('#txtTestingProcedures').val().trim() == "" || $('#txtTestingProcedures').val() == null) {
        ////    if (ErrorMsg == '') {
        ////        ErrorMsg = 'Please select the mentioned fields: Testing Procedures';
        ////    }
        ////    else {
        ////        ErrorMsg = ErrorMsg + ',Testing Procedures';
        ////    }
        ////}

    }

    if (SubMenuSection == 'ITCompliance') {
        if ($('#txtCategory').val().trim() == "" || $('#txtCategory').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Category';
            }
            else {
                ErrorMsg = ErrorMsg + ',Category';
            }
        }

        if ($('#txtClause').val().trim() == "" || $('#txtClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Clause';
            }
            else {
                ErrorMsg = ErrorMsg + ',Clause';
            }
        }

        if ($('#txtSubClause').val().trim() == "" || $('#txtSubClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: SubClause';
            }
            else {
                ErrorMsg = ErrorMsg + ',SubClause';
            }
        }
    }

    if (SubMenuSection == 'RBICompliance') {
        if ($('#txtCategory').val().trim() == "" || $('#txtCategory').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Category';
            }
            else {
                ErrorMsg = ErrorMsg + ',Category';
            }
        }

        if ($('#txtClause').val().trim() == "" || $('#txtClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Clause';
            }
            else {
                ErrorMsg = ErrorMsg + ',Clause';
            }
        }

        if ($('#txtSubClause').val().trim() == "" || $('#txtSubClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: SubClause';
            }
            else {
                ErrorMsg = ErrorMsg + ',SubClause';
            }
        }
    }

    if (SubMenuSection == 'HIPPACompliance') {
        if ($('#txtCategory').val().trim() == "" || $('#txtCategory').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Category';
            }
            else {
                ErrorMsg = ErrorMsg + ',Category';
            }
        }

        if ($('#txtClause').val().trim() == "" || $('#txtClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Clause';
            }
            else {
                ErrorMsg = ErrorMsg + ',Clause';
            }
        }

        if ($('#txtSubClause').val().trim() == "" || $('#txtSubClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: SubClause';
            }
            else {
                ErrorMsg = ErrorMsg + ',SubClause';
            }
        }
    }

    if (SubMenuSection == 'GDPRCompliance') {
        if ($('#txtCategory').val().trim() == "" || $('#txtCategory').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Category';
            }
            else {
                ErrorMsg = ErrorMsg + ',Category';
            }
        }

        if ($('#txtClause').val().trim() == "" || $('#txtClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Clause';
            }
            else {
                ErrorMsg = ErrorMsg + ',Clause';
            }
        }

        if ($('#txtSubClause').val().trim() == "" || $('#txtSubClause').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: SubClause';
            }
            else {
                ErrorMsg = ErrorMsg + ',SubClause';
            }
        }
    }

    if (SubMenuSection == 'AssetNotification') {
        if ($("#ddlAssetSrNo option:selected").val() == 0) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Asset Serial No.';
            }
            else {
                ErrorMsg = ErrorMsg + ',Asset Serial No.';
            }
        }

        if ($("#ddlSeverity option:selected").val() == 0) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Severity';
            }
            else {
                ErrorMsg = ErrorMsg + ',Severity';
            }
        }

        if ($("#ddlParameter option:selected").val() == 0) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Parameter';
            }
            else {
                ErrorMsg = ErrorMsg + ',Parameter';
            }
        }

        if ($('#txtThresholdPercentage').val().trim() == "" || $('#txtThresholdPercentage').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Threshold Percentage';
            }
            else {
                ErrorMsg = ErrorMsg + ',Threshold Percentage';
            }
        }

        if ($("#ddlNotifyTo").val() == '') {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Notify To';
            }
            else {
                ErrorMsg = ErrorMsg + ',Notify To';
            }
        }
    }

    if (SubMenuSection == 'AssetGroupDetails') {
        if ($('#txtGroupName').val().trim() == "" || $('#txtGroupName').val() == null) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Group Name';
            }
            else {
                ErrorMsg = ErrorMsg + ',Group Name';
            }
        }
    }

    if (SubMenuSection == 'AssetGroupTaggings') {
        if ($("#ddlAssetGroup option:selected").val() == 0) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Asset Group';
            }
            else {
                ErrorMsg = ErrorMsg + ',Asset Group';
            }
        }

        if ($("#ddlAssetName option:selected").val() == 0) {
            if (ErrorMsg == '') {
                ErrorMsg = 'Please select the mentioned fields: Asset Name';
            }
            else {
                ErrorMsg = ErrorMsg + ',Asset Name';
            }
        }
    }

    if (ErrorMsg != '') {
        IsValid = false;
        $('#lblErrorMessage').text(ErrorMsg);
        $('#ErrorModal').modal('show');
    }

    return IsValid;
}

function BarChartNew(data, id, title, Section) {
    //
    var DataName = [];
    var DataTotal = [];

    data.forEach(function (obj) {
        DataName.push(obj.NAME);
        DataTotal.push(obj.VALUE);
    });
    var options = {
        series: [{
            name: DataName,
            data: DataTotal//[44, 55, 41, 67, 22, 43, 21, 33, 45, 31, 87, 65, 35]
        }],
        //annotations: {
        //    points: [{
        //        x: 'Bananas',
        //        seriesIndex: 0,
        //        label: {
        //            borderColor: '#775DD0',
        //            offsetY: 0,
        //            style: {
        //                color: '#fff',
        //                background: '#775DD0',
        //            },
        //            text: 'Bananas are good',
        //        }
        //    }]
        //},
        chart: {
            height: 350,
            type: 'bar',
            events: {
                dataPointSelection(event, chartContext, config) {
                    ////Click(config.w.config.xaxis.categories[config.dataPointIndex], Section)
                    Click(config.w.config.series[0].name[config.dataPointIndex], Section)
                }
            },
        },
        plotOptions: {
            bar: {
                borderRadius: 10,
                columnWidth: '10%',
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            width: 2
        },
        title: {
            text: title,
            align: 'left',
            style: {
                fontSize: "14px",
                color: '#8997bd'
            }
        },
        grid: {
            row: {
                colors: ['#fff', '#f2f2f2']
            }
        },
        xaxis: {
            labels: {
                rotate: -45,
                rotateAlways: true
            },
            categories: DataName,
            tickPlacement: 'on'
        },
        //yaxis: {
        //    title: {
        //        text: 'Servings',
        //    },
        //},
        tooltip: {
            custom: function ({ series, seriesIndex, dataPointIndex, w }) {
                return series[seriesIndex][dataPointIndex]
            }
        },
        fill: {
            type: 'gradient',
            gradient: {
                shade: 'light',
                type: "horizontal",
                shadeIntensity: 0.25,
                gradientToColors: undefined,
                inverseColors: true,
                opacityFrom: 0.85,
                opacityTo: 0.85,
                stops: [50, 0, 100]
            },
        }
    };

    var chart = new ApexCharts(document.querySelector("#" + id), options);
    chart.render();
};

//Show Progess On Loading
function ShowProgress() {
    $('#Progress_Modal').modal('show');
};

//Hide Progress
function HideProgress() {
    $('#Progress_Modal').modal('hide');
};

//Send Mail TO User For Technician Predefine Reply Status
function SendEmailTicketReplyStatusNew(receiptemail, ticketid, description, cc, downloadpath) {
    debugger;
    var file = $("#Attachment").get(0).files;
    var josnstr = new FormData();
    josnstr.append("UploadedFile", file[0]);
    josnstr.append("receiptemail", receiptemail);
    josnstr.append("ticketid", ticketid);
    josnstr.append("description", description);
    josnstr.append("url", downloadpath);
    josnstr.append("cc", cc);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/Email/SendEmailTicketReplyStatusNew',
        async: false,
        contentType: false,
        processData: false,
        data: josnstr,
        success: function (data) {
        },
        error: function (edata) {
            $(edata).each(function () {
                InsException(this.status, this.statusText, (this.responseJSON).ExceptionMessage, (this.responseJSON).ExceptionType);
            });
            alert("error while Sending mail.");
        }
    });
};


//Approver Email function
function SendMailToApprover(gate_pass_id, ApproverLevel) {
    var parm = {
        'gate_pass_id_pk': gate_pass_id, 'ApproverLevel': ApproverLevel // $.session.get("asset_id_pk");
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/FixedAssets/GetApproverToendEmailForGatePass',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {

            //if (data.approver_id != "Select" && data.approver_id != "Select " && data.approver_id != '' && data.approver_id != undefined && data.approver_id != null) {
            if (data.approver_id.length > 0) {
                SendEmailChangeGatePassStatus(data.approver_id, data.prefix, data.moment_type, data.gate_pass_type, data.reason_for_gate_pass, data.approver_name, ApproverLevel);
            }
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

//Approver Email function
function SendMailToApprover_PO(purchase_order_id, ApproverLevel) {
    var parm = {
        'purchase_order_id_pk': purchase_order_id, 'ApproverLevel': ApproverLevel
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/PurchaseOrder/GetApproverDetails',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.approver_id.length > 0) {
                SendEmailChangeStatus_PO(data.approver_id, data.PO_No, data.PO_Name, data.approver_name, ApproverLevel, purchase_order_id);
            }
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

//Approver Email function
function SendMailToApprover_SR(service_request_id, ApproverLevel) {
    var parm = {
        'service_req_id_pk': service_request_id, 'ApproverLevel': ApproverLevel
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/ServiceRequests/GetServiceRequestAllDetails',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {
            debugger;
            //if (data.approver_id != "Select" && data.approver_id != "Select " && data.approver_id != '' && data.approver_id != undefined && data.approver_id != null) {
            if (data.approver_id_email.length > 0) {
                SendEmailChangeStatus_SR(data.approver_id_email, data.service_req_id_pk, (data.prefix + data.service_req_id_pk), data.subject, data.message, data.CATEGORY, data.SUB_CATEGORY, '', data.approver_name, ApproverLevel, data.approver_comments, data.approver_comments1, data.approver_comments2);
            }
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

//Action Taken on Gatepass Email notifixation to Creator function
function SendMailToGatePassCreator(gate_pass_id, ApproverLevel, ActionTaken) {
    var parm = {
        'gate_pass_id_pk': gate_pass_id, 'ApproverLevel': ApproverLevel // $.session.get("asset_id_pk");
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        url: apiurl + 'api/FixedAssets/GetApproverToendEmailForGatePass',
        contentType: "application/json; charset=utf-8",
        data: josnstr,
        dataType: "json",
        success: function (data) {

            //if (data.approver_id != "Select" && data.approver_id != "Select " && data.approver_id != '' && data.approver_id != undefined && data.approver_id != null) {
            if (data.approver_id.length > 0) {
                SendEmailChangeGatePassActionNotification(data.Created_By_Email, data.prefix, data.Created_By_Name, data.approver_name, ActionTaken);
            }
        },
        error: function (edata) {
            alert("error while feching record.");
        }
    });
};

function timerIncrement() {
    idleTime = idleTime + 1;
    if (idleTime > 14) { // 15 minutes
        //window.location.reload();
        alert("Dear User,\nYou have been inactive for more than 15 minutes. You will be logged out after clicking 'OK'.");
        LogOut();
    }
}

function LogOut() {
    $.ajax({
        type: "Get",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: '/Home/Logout',
        async: false,
        success: function (data) {
            if (data.url == true) {
                $.session.clear();
                window.location.href = '/Home/Index';
            }
        },
        error: function (result) {
            alert("Error : data");
        }
    });
};

