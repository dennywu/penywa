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
    data.CustomerId = $("#custId").val();
    data.TransactionDate = $("#fromdate").val();
    data.dueDate = $("#todate").val();
    data.Items = [];


    console.log(data);
}