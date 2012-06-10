var RECEIVE = {};
$(document).ready(function () {
    var selectCust = RECEIVE.SELECTCUSTOMER;
    RECEIVE.SELECTCUSTOMER.setupSelectCustomer();
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
    data.CustId = $("#custId").val();
    data.ReceiveDate = $("#transactiondate").val();
    data.Items = [];
    $("#tblreceiveitem tbody tr").each(function (i) {
        data.Items[i] = {};
        data.Items[i].RentalId = $('.receiveItemId').get(i).value;
        data.Items[i].Total = $('.rentalTotal').get(i).value;
        data.Items[i].TotalDenda = $('.rentalDenda').get(i).value;
        data.Items[i].TotalAfterDenda = $('.rentalTotalAfterDenda').get(i).value;
        data.Items[i].PayAmount = $('.rentalPayAmount').get(i).value;
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