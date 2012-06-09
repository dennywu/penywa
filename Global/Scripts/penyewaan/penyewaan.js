var RENTAL = {};
$(document).ready(function () {
    var selectCust = RENTAL.SELECTCUSTOMER;
    RENTAL.SELECTCUSTOMER.setupSelectCustomer();
    RENTAL.setupDatePicker();
    RENTAL.ITEM.setupItem();
    $("#btnSave").click(RENTAL.save);
});

RENTAL.setupDatePicker = function () {
    var dates = $("#fromdate, #todate").datepicker({ dateFormat: 'yy-mm-dd',
        defaultDate: "+1w",
        changeMonth: true,
        gotoCurrent: true,
        numberOfMonths: 1,
        onSelect: function (selectedDate) {
            var option = this.id == "fromdate" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker"),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
            dates.not(this).datepicker("option", option, date);
        }
    });
}

RENTAL.save = function () {
    var data = {};
    data.CustId = $("#custId").val();
    data.TransactionDate = $("#fromdate").val();
    data.DueDate = $("#todate").val();
    data.Items = [];
    $("#tblitem tbody tr").each(function (i) {
        if ($('.inputPartName').length != 0) {
            if ($('.inputPartName').get(i).value != "" && $('.itemtotalValue').get(i).value != "") {
                data.Items[i] = {};
                data.Items[i].ItemId = $('.itemId').get(i).value;
                data.Items[i].Deskripsi = $('.deskripsi').get(i).value;
                data.Items[i].Qty = $('.itemqty').get(i).value;
                data.Items[i].Harga = $('.itemharga').get(i).value;
                data.Items[i].Total = $('.total').get(i).value;
            }
        }
    });

    console.log(data);
    $.ajax({
        type: 'POST',
        url: '/Penyewaan/AddPenyewaan',
        data: { 'rental': JSON.stringify(data) },
        dataType: 'json',
        success: function (data) {
            //            alert(data);
            window.location = data.redirectTo;
        }
    });
}