var RENTAL = {};
RENTAL.SELECTCUSTOMER = {};
RENTAL.SELECTCUSTOMER.sessionTimeOutSearchingCust;

$(document).ready(function () {
    var selectCust = RENTAL.SELECTCUSTOMER;
    $("#inputCustomer").keyup(selectCust.searchCustomer);
    $("#inputCustomer").blur(selectCust.hideSearchedResult);
    $("#inputCustomer").focus(selectCust.showSearchedResult);
    $("#searchCustResult .contain")
});

RENTAL.SELECTCUSTOMER.searchCustomer = function (ev) {
    window.clearTimeout(RENTAL.SELECTCUSTOMER.sessionTimeOutSearchingCust);
    if (ev.keyCode == "13") {
        RENTAL.SELECTCUSTOMER.clearSearchedResult();
        RENTAL.SELECTCUSTOMER.showLoading();
        RENTAL.SELECTCUSTOMER.searchingCustomer();
    }
    else if (ev.keyCode == "27") {
        $("#inputCustomer").blur();
        RENTAL.SELECTCUSTOMER.hideSearchedResult();
    }
    else {
        RENTAL.SELECTCUSTOMER.clearSearchedResult();
        RENTAL.SELECTCUSTOMER.showLoading();
        RENTAL.SELECTCUSTOMER.sessionTimeOutSearchingCust = window.setTimeout(RENTAL.SELECTCUSTOMER.searchingCustomer, 1000);
    }
}
RENTAL.SELECTCUSTOMER.searchingCustomer = function () {
    
    
    var key = $("#inputCustomer").val();
    if (key == "")
        return RENTAL.SELECTCUSTOMER.clearSearchedResult();
    $.ajax({
        type: 'GET',
        url: '/Customer/SearchCustomerByName?key=' + key,
        dataType: 'json',
        success: RENTAL.SELECTCUSTOMER.searchingCustomerCallBack
    });
}
RENTAL.SELECTCUSTOMER.searchingCustomerCallBack = function (data) {
    RENTAL.SELECTCUSTOMER.clearSearchedResult();
    if (data.length == 0) {
        RENTAL.SELECTCUSTOMER.showEmptyResult();
    }
    else {
        for (var i = 0; i < data.length; i++) {
            $("#searchCustResult").append(RENTAL.SELECTCUSTOMER.createSearchedCustRow(data[i]));
        }
    }
}
RENTAL.SELECTCUSTOMER.createSearchedCustRow = function(cust) {
    var divContain = $("<div>", { 'class': 'contain' });
    var divName = $("<div>", { 'class': 'custName', 'text': cust.Name});
    var divAlamat = $("<div>", { 'class': 'custAlamat', 'text': cust.Alamat });
    var divEmail = $("<div>", { 'class': 'custEmail', 'text': cust.Email });

    divName.appendTo(divContain);
    divAlamat.insertAfter(divName);
    divEmail.insertAfter(divAlamat);
    return divContain;
}
RENTAL.SELECTCUSTOMER.clearSearchedResult = function () {
    $("#searchCustResult").empty();
}
RENTAL.SELECTCUSTOMER.showSearchedResult = function () {
    $("#searchCustResult").show();
}
RENTAL.SELECTCUSTOMER.hideSearchedResult = function () {
    $("#searchCustResult").hide();
}
RENTAL.SELECTCUSTOMER.showLoading = function () {
    $("#searchCustResult").append("<div align='center' style='color:#457BD9;'>Harap Tunggu...</div>");
}
RENTAL.SELECTCUSTOMER.showEmptyResult = function () {
    $("#searchCustResult").append("<div align='center' style='color:#457BD9;'>Data Tidak Ditemukan</div>");
}
