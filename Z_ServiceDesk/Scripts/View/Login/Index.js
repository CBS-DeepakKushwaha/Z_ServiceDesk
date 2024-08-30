
$(document).ready(function () {   
    $("#btnLogin").click(function () {
        var rtn_val = validatelogin();
        if (rtn_val == true) {
            Login();
        } else {
            return false;
        }
    });

    let enter = document.getElementById('password');

    enter.addEventListener("keyup", function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            var rtn_val = validatelogin();
            if (rtn_val == true) {
                Login();
            } else {
                return false;
            }
        }
    });

    $("#btnApply").click(function () {
        if (validate() == true) {
            LicenseKey();
        } else {
            return false;
        }
    });

    var license = $("#license_info").attr("name");
    const wrapper = document.createElement('div');
    wrapper.innerHTML = '';
    if (license == "-1") {
        swal.fire({
            title: '<strong style="color:red;">Warning</strong>',
            html: 'Application license expired! Contact your administrator.If you have a key click the link below.</br><a href="javascript:void(0);" data-toggle="modal" data-target="#LicenseModal" data-animation="bounce" onclick="swal.close();">Click here!</a>'
        });
    }
    if (license == "-2") {
        swal.fire({
            title: '<strong style="color:red;">Warning</strong>',
            html: 'Application is not registered! Contact your administrator. If you have a key click the link below.</br><a href="javascript:void(0);" data-toggle="modal" data-target="#LicenseModal" data-animation="bounce" onclick="swal.close();">Click here!</a>'
        });
    }
    //$("#btnLogin").click(function () {
    //    var rtn_val = validatelogin();
    //    if (rtn_val == true) {
    //        // Login();
    //    } else {
    //        return false;
    //    }
    //});
});


function logo() {

    $.ajax({
        type: "Get",
        contentType: "application/json; charset=utf-8",
        url: "http://localhost:49708" + '/api/Masters/getlogo',
        dataType: "json",
        success: function (data) {
            debugger;
            $("#logoimg").attr("src", data.logo);
            $('#layoutImage').css("background-image", "url(" + data.background+")");
           
        },

        error: function (edata) {
            alert("error while feching record.");
        }
    });
}
function validatelogin() {
    var return_val = true;
    if ($("#emailaddress").val().trim() == "") {
        return_val = false;
        $("#SpnEmail").show();
    } else {
        $("#SpnEmail").hide();
    }
    if ($("#password").val().trim() == "") {
        return_val = false;
        $("#SpnPassword").show();
    } else {
        $("#SpnPassword").hide();
    }
    return return_val;
}

function Login() {
    
    var param = {
        "email": $("#emailaddress").val().trim(),
        "password": $("#password").val().trim()
    }
    var jsondata = JSON.stringify(param);
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //url: 'http://api.dmishraphysio.com/api/Login/ValidateUser',
        ////url: apiurl + 'api/Login/ValidateUser',
        url: '/Home/Index',
        data: jsondata,
        dataType: "json",
        success: function (data) {
            
            if (data.hasOwnProperty('err1')) {
                $('#MessageAlert').show();
                $('#Message').text('Username or Password is incorrect!');
            } else if (data.hasOwnProperty('err')) {
                $('#MessageAlert').show();
                $('#Message').text(data.err);
            } else if (data.hasOwnProperty('url')) {
                window.location.href = data.url;
            }
        },
        error: function (data) {
            alert("Error");
        }
    });
}

function validate() {
    var return_val = true;
    if ($("#inpLicense").val() == '' || $("#inpLicense").val() == null || $("#inpLicense").val() == undefined) {
        return_val = false;
        $("#SpnLicense").show();
    } else {
        $("#SpnLicense").hide();
    }
    return return_val;
}

function LicenseKey() {
    var parm = {
        "license_key": $("#inpLicense").val()
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        //url: apiurl + 'api/Masters/VerifyKey', change api address for license key verification
        url: apiurl + 'api/Masters/VerifyKey',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data != null) {
                AddLicenseDetails(data);
            } else {
                swal.fire({
                    title: 'Warning',
                    text: 'The license key entered is not valid!',
                    icon: 'warning'
                }).then(function () {
                    $("#closedLicenseModal").click();
                });
            }
        },
        error: function (result) {
            swal.fire({
                title: "Error",
                text: "Error while fetching records.",
                icon: "error"
            });
        }
    });
};

function AddLicenseDetails(data) {
    var parm = {
        "product_code": data.product_code,
        "license_key": data.license_key,
        "license_type": data.license_type,
        "start_date": data.start_date,
        "end_date": data.end_date,
        "base_platform": data.base_platform,
        "admin_license": data.admin_license,
        "asset_admin_license": data.asset_admin_license,
        "standard_technician_license": data.standard_technician_license,
        "enterprise_technician_license": data.enterprise_technician_license,
        "full_suite": data.full_suite,
        "lifecycle_mgmt": data.lifecycle_mgmt,
        "support_type": data.support_type
    };
    var josnstr = JSON.stringify(parm);
    $.ajax({
        type: "Post",
        contentType: "application/json; charset=utf-8",
        url: apiurl + 'api/Masters/RegisterKey',
        data: josnstr,
        dataType: "json",
        success: function (data) {
            if (data.status_id == 1) {
                swal.fire({
                    title: 'Success',
                    text: data.status,
                    icon: 'success'
                }).then(function () {
                    $("#closedLicenseModal").click();
                    window.location.href = '/Home/Index';
                });

            } else {
                swal.fire({
                    title: 'Warning',
                    text: data.status,
                    icon: 'warning'
                }).then(function () {
                    $("#closedLicenseModal").click();
                });
            }
        },
        error: function (result) {
            swal.fire({
                title: "Error",
                text: "Error while registering license key.",
                icon: "error"
            });
        }
    });
};


var OAUTHURL = 'https://accounts.google.com/o/oauth2/auth?';
var VALIDURL = 'https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=';
var SCOPE = 'https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email';
//var CLIENTID = '198482888858-t2crgu2j9j2cj9mjo8eup9o46e714dg9.apps.googleusercontent.com';
var REDIRECT = 'https://poc.zservicedesk.com/api/api/Home/Index';
var LOGOUT = 'https://poc.zservicedesk.com/api/api/Home/Index';

//For production
var CLIENTID = '384315610026-oj4r990pslt32eu7tjumqdoinmrnq0ob.apps.googleusercontent.com';
//var REDIRECT = 'https://amsadmin-rea-india.zservicedesk.com/Home/Index';
//var LOGOUT = 'https://amsadmin-rea-india.zservicedesk.com/Home/Index';
var TYPE = 'token';
var _url = OAUTHURL + 'scope=' + SCOPE + '&client_id=' + CLIENTID + '&redirect_uri=' + REDIRECT + '&response_type=' + TYPE;
var acToken;
var tokenType;
var expiresIn;
var user;
var loggedIn = false;

function GoogleLogin() {
    var win = window.open(_url, "windowname1", 'width=800, height=600');
    var pollTimer = window.setInterval(function () {
        try {
            console.log(win.document.URL);
            if (win.document.URL.indexOf(REDIRECT) != -1) {
                window.clearInterval(pollTimer);
                var url = win.document.URL;
                acToken = gup(url, 'access_token');
                tokenType = gup(url, 'token_type');
                expiresIn = gup(url, 'expires_in');

                win.close();
                
                validateToken(acToken);
            }
        }
        catch (e) {

        }
    }, 500);
};

function gup(url, name) {
    namename = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\#&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(url);
    if (results == null)
        return "";
    else
        return results[1];
}

function validateToken(token) {
    getUserInfo();
    $.ajax({
        url: VALIDURL + token,
        data: null,
        success: function (responseText) { }
    });
};

function getUserInfo() {
    $.ajax({
        url: 'https://www.googleapis.com/oauth2/v1/userinfo?access_token=' + acToken,
        data: null,
        success: function (resp) {
            //
            user = resp;
            console.log(user);
            $('#uname').html('Welcome ' + user.name);
            $('#uemail').html('Email: ' + user.email)
            $('#imgHolder').attr('src', user.picture);
            if (user.name != null || user.name != undefined || user.name != "") {
                RedirectValid(user);
                $('#MessageAlert').hide();
                $('#Message').text('');
            } else {
                $('#MessageAlert').show();
                $('#Message').text('Username or Password is incorrect!');
            }
        },
    });
};

function externalLogout() {
    var url, params;
    url = "https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout";
    params = {
        next: LOGOUT
    }
    performCallLogout(url, params);
}

function performCallLogout(url, params) {
    window.location.href = url + "?continue=" + params.next;
}

function RedirectValid(user) {
    $.ajax({
        url: '/Home/GoogleLogin/',
        type: 'POST',
        data: {
            email: user.email,
            name: user.name,
            gender: user.gender,
            lastname: user.lastname,
            location: user.location
        },
        success: function (data) {
            if (data.hasOwnProperty('err1')) {
                $('#MessageAlert').show();
                $('#Message').text(data.err1);
            } else if (data.hasOwnProperty('err')) {
                $('#MessageAlert').show();
                $('#Message').text(data.err);
            } else if (data.hasOwnProperty('url')) {
                $('#MessageAlert').hide();
                $('#Message').text("");
                window.location.href = data.url;
            }
        }
        //dataType: "jsonp"
    });
}; 