RENTAL.SELECTCUSTOMER = {};
RENTAL.SELECTCUSTOMER.sessionTimeOutSearchingCust;
RENTAL.SELECTCUSTOMER.setupSelectCustomer = function () {
    $("#inputCustomer").keyup(RENTAL.SELECTCUSTOMER.searchCustomer);
    $("#inputCustomer").focus(RENTAL.SELECTCUSTOMER.showSearchedResult);
    $("#inputCustomer").blur(function () {
        setTimeout(RENTAL.SELECTCUSTOMER.hideSearchedResult, 200);
    });
}
RENTAL.SELECTCUSTOMER.setStatusSelectCust = function () {
    var id = $("#custId").val();
    if (id != "")
        $("#statusSelectCust").text('T').css("color","Green");
    else
        $("#statusSelectCust").text('F').css("color","Red");
}

RENTAL.SELECTCUSTOMER.CustomerChosen = function () {
    var custId = $(this).attr("id");
    var custName = $(this).attr("name");
    $("#inputCustomer").val(custName);
    $("#custId").val(custId);    
}

RENTAL.SELECTCUSTOMER.searchCustomer = function (ev) {
    window.clearTimeout(RENTAL.SELECTCUSTOMER.sessionTimeOutSearchingCust);
    if (ev.keyCode == "13") {
        $("#custId").val('');
        RENTAL.SELECTCUSTOMER.clearSearchedResult();
        RENTAL.SELECTCUSTOMER.showLoading();
        RENTAL.SELECTCUSTOMER.searchingCustomer();
    }
    else if (ev.keyCode == "27") {
        $("#inputCustomer").blur();
        RENTAL.SELECTCUSTOMER.hideSearchedResult();
        RENTAL.SELECTCUSTOMER.setStatusSelectCust();
    }
    else {
        $("#custId").val('');
        RENTAL.SELECTCUSTOMER.clearSearchedResult();
        RENTAL.SELECTCUSTOMER.showLoading();
        RENTAL.SELECTCUSTOMER.sessionTimeOutSearchingCust = window.setTimeout(RENTAL.SELECTCUSTOMER.searchingCustomer, 1000);
    }
}
RENTAL.SELECTCUSTOMER.searchingCustomer = function () 
{
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
    $("#searchCustResult .contain").click(RENTAL.SELECTCUSTOMER.CustomerChosen);
}
RENTAL.SELECTCUSTOMER.createSearchedCustRow = function(cust) {
    var divContain = $("<div>", { 'class': 'contain', 'id': cust.Id, 'name': cust.Name });
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
    RENTAL.SELECTCUSTOMER.setStatusSelectCust();
}
RENTAL.SELECTCUSTOMER.showLoading = function () {
    $("#searchCustResult").append("<div align='center' style='color:#457BD9;'>Harap Tunggu...</div>");
}
RENTAL.SELECTCUSTOMER.showEmptyResult = function () {
    $("#searchCustResult").append("<div align='center' style='color:#457BD9;'>Data Tidak Ditemukan</div>");
}
