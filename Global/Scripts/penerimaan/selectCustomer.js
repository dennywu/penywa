RECEIVE.SELECTCUSTOMER = {};
RECEIVE.SELECTCUSTOMER.sessionTimeOutSearchingCust;
RECEIVE.SELECTCUSTOMER.setupSelectCustomer = function () {
    $("#inputCustomer").keyup(RECEIVE.SELECTCUSTOMER.searchCustomer);
    $("#inputCustomer").focus(RECEIVE.SELECTCUSTOMER.showSearchedResult);
    $("#inputCustomer").blur(function () {
        setTimeout(RECEIVE.SELECTCUSTOMER.hideSearchedResult, 200);
    });
}
RECEIVE.SELECTCUSTOMER.setStatusSelectCust = function () {
    var id = $("#custId").val();
    if (id != "")
        $("#statusSelectCust").text('T').css("color","Green");
    else
        $("#statusSelectCust").text('F').css("color","Red");
}

RECEIVE.SELECTCUSTOMER.CustomerChosen = function () {
    var custId = $(this).attr("id");
    var custName = $(this).attr("name");
    $("#inputCustomer").val(custName);
    $("#custId").val(custId);
}

RECEIVE.SELECTCUSTOMER.searchCustomer = function (ev) {
    window.clearTimeout(RECEIVE.SELECTCUSTOMER.sessionTimeOutSearchingCust);
    if (ev.keyCode == "13") {
        $("#custId").val('');
        RECEIVE.SELECTCUSTOMER.clearSearchedResult();
        RECEIVE.SELECTCUSTOMER.showLoading();
        RECEIVE.SELECTCUSTOMER.searchingCustomer();
    }
    else if (ev.keyCode == "27") {
        $("#inputCustomer").blur();
        RECEIVE.SELECTCUSTOMER.hideSearchedResult();
        RECEIVE.SELECTCUSTOMER.setStatusSelectCust();
    }
    else {
        $("#custId").val('');
        RECEIVE.SELECTCUSTOMER.clearSearchedResult();
        RECEIVE.SELECTCUSTOMER.showLoading();
        RECEIVE.SELECTCUSTOMER.sessionTimeOutSearchingCust = window.setTimeout(RECEIVE.SELECTCUSTOMER.searchingCustomer, 1000);
    }
}
RECEIVE.SELECTCUSTOMER.searchingCustomer = function () 
{
    var key = $("#inputCustomer").val();
    if (key == "")
        return RECEIVE.SELECTCUSTOMER.clearSearchedResult();
    $.ajax({
        type: 'GET',
        url: '/Customer/SearchCustomerByName?key=' + key,
        dataType: 'json',
        success: RECEIVE.SELECTCUSTOMER.searchingCustomerCallBack
    });
}
RECEIVE.SELECTCUSTOMER.searchingCustomerCallBack = function (data) {
    RECEIVE.SELECTCUSTOMER.clearSearchedResult();
    if (data.length == 0) {
        RECEIVE.SELECTCUSTOMER.showEmptyResult();
    }
    else {
        for (var i = 0; i < data.length; i++) {
            $("#searchCustResult").append(RECEIVE.SELECTCUSTOMER.createSearchedCustRow(data[i]));
        }
    }
    $("#searchCustResult .contain").click(RECEIVE.SELECTCUSTOMER.CustomerChosen);
}
RECEIVE.SELECTCUSTOMER.createSearchedCustRow = function(cust) {
    var divContain = $("<div>", { 'class': 'contain', 'id': cust.Id, 'name': cust.Name });
    var divName = $("<div>", { 'class': 'custName', 'text': cust.Name});
    var divAlamat = $("<div>", { 'class': 'custAlamat', 'text': cust.Alamat });
    var divEmail = $("<div>", { 'class': 'custEmail', 'text': cust.Email });

    divName.appendTo(divContain);
    divAlamat.insertAfter(divName);
    divEmail.insertAfter(divAlamat);
    return divContain;
}
RECEIVE.SELECTCUSTOMER.clearSearchedResult = function () {
    $("#searchCustResult").empty();
}
RECEIVE.SELECTCUSTOMER.showSearchedResult = function () {
    $("#searchCustResult").show();
}
RECEIVE.SELECTCUSTOMER.hideSearchedResult = function () {
    $("#searchCustResult").hide();
    RECEIVE.SELECTCUSTOMER.setStatusSelectCust();
}
RECEIVE.SELECTCUSTOMER.showLoading = function () {
    $("#searchCustResult").append("<div align='center' style='color:#457BD9;'>Harap Tunggu...</div>");
}
RECEIVE.SELECTCUSTOMER.showEmptyResult = function () {
    $("#searchCustResult").append("<div align='center' style='color:#457BD9;'>Data Tidak Ditemukan</div>");
}
