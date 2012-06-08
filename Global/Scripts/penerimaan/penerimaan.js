var RECEIVE = {};
$(document).ready(function () {
    var selectCust = RECEIVE.SELECTCUSTOMER;
//    RECEIVE.SELECTCUSTOMER.setupSelectCustomer();
    RECEIVE.setupDatePicker();
    RECEIVE.ITEM.setupReceiveItem();
    $("#btnSave").click(RECEIVE.save);
    $("#CloseBtn").click(RECEIVE.ITEM.closeRentalListDialog);
});

RECEIVE.setupDatePicker = function () {
    var dates = $("#transactiondate").datepicker({ dateFormat: 'yy-mm-dd',
        defaultDate: "+1w",
        changeMonth: true,
        gotoCurrent: true,
        numberOfMonths: 1
    });
}

RECEIVE.save = function () {
    var data = {};
    data.CustomerId = $("#custId").val();
    data.TransactionDate = $("#transactiondate").val();
    data.Items = [];
    $("#tblitem tbody tr").each(function (i) {
        if ($('.inputRentalNo').length != 0) {
            if ($('.inputRentalNo').get(i).value != "") {
                data.Items[i] = {};
                data.Items[i].RentalIdId = $('.rentalId').get(i).value;
                data.Items[i].TransactionDate = $('.transactionDate').get(i).value;
                data.Items[i].Total = $('.total').get(i).value;
                data.Items[i].Denda = $('.denda').get(i).value;
                data.Items[i].PayAmount = $('.payAmount').get(i).value;
            }
        }
    });

    console.log(data);
    $.ajax({
        type: 'POST',
        url: '/Penerimaan/AddPenerimaan',
        data: { 'receive': JSON.stringify(data) },
        dataType: 'json',
        success: function (data) {
            window.location = data.redirectTo;
        }
    });
}