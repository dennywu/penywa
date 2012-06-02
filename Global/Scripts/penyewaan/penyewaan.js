var RENTAL = {};
RENTAL.SELECTCUSTOMER = {};
RENTAL.SELECTCUSTOMER.sessionTimeOutSearchingCust;

$(document).ready(function () {
    var selectCust = RENTAL.SELECTCUSTOMER;
    $("#inputCustomer").keyup(selectCust.searchCustomer);
    $("#inputCustomer").focus(selectCust.showSearchedResult);
    $("#inputCustomer").blur(function () {
        setTimeout(selectCust.hideSearchedResult, 200);
    });
    RENTAL.setupDatePicker();
    $("#addRow").click(RENTAL.ITEM.addRow);
    $("#tblitem tbody tr").hover(RENTAL.ITEM.showRemoveButton);
    $("#tblitem tbody tr").mouseleave(RENTAL.ITEM.hideRemoveButton);
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
