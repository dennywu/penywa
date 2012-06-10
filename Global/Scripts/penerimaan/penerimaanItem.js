RECEIVE.ITEM = {}
RECEIVE.ITEM.totalRow = 0;

RECEIVE.ITEM.setupReceiveItem = function () {
    $("#selectRental").click(RECEIVE.ITEM.initRentalList);
}

RECEIVE.ITEM.initRentalList = function () {
    var custId = $("#custId").val();
    if (custId != "") {
        RECEIVE.ITEM.showRentalListDialog();
        RECEIVE.ITEM.getDataRental(custId);
    }
    else {
        alert("Silakan memilih pelanggan terlebih dahulu");
    }
}

RECEIVE.ITEM.showRentalListDialog = function () {
    $("#DialogRentalList").show();
    $("#TblRentalListContent tbody").empty();
}

RECEIVE.ITEM.getDataRental = function (custId) {
    $.ajax({
        type: 'GET',
        url: '/Penerimaan/GetAllRental?custId=' + custId,
        dataType: 'json',
        success: RECEIVE.ITEM.renderDataToList
    });
}

RECEIVE.ITEM.closeRentalListDialog = function () {
    $("#DialogRentalList").hide();
}

RECEIVE.ITEM.renderDataToList = function (data) {
    $.each(data, function (i) {
        $("#TblRentalListContent tbody").append("<tr id='" + data[i].RentalId + "'>" +
                        "<td class='RentalNo'>" + data[i].RentalNo + "</td>" +
                        "<td class='Customer'>" + data[i].CustomerName + "</td>" +
                        "<td class='TransactionDate center'>" + data[i].TransactionDate.toDefaultFormatDate() + "</td>" +
                        "<td class='Total right'>Rp " + data[i].Total.toCurrency() + "</td>" +
                        "<td class='Outstanding right'>Rp " + data[i].OutStanding.toCurrency() + "</td>" +
                    "</tr>");
    });
    $("#TblRentalListContent tbody tr").click(RECEIVE.ITEM.GetReceiveItemDetail);
}

RECEIVE.ITEM.GetReceiveItemDetail = function () {
    var RentalId = $(this).attr("id");
    $.ajax({
        type: 'GET',
        url: '/Penerimaan/GetReceiveItemDetail?rentalId=' + RentalId,
        dataType: 'json',
        success: function (data) {
            RECEIVE.ITEM.addReceiveItemToTable(data);
            RECEIVE.ITEM.closeRentalListDialog();
            RECEIVE.ITEM.calculateSubTotal();
        }
    });
}
RECEIVE.ITEM.addReceiveItemToTable = function (data) {
    RECEIVE.ITEM.totalRow++;
    $("#tblreceiveitem tbody").append("<tr id='" + RECEIVE.ITEM.totalRow + "'><td>" +
                "<input type='hidden' class='receiveItemId' id='receiveItemId_" + RECEIVE.ITEM.totalRow + "' value='" + data.RentalId + "' />" +
                "<div class='rentalNo' id='rentalNo_" + RECEIVE.ITEM.totalRow + "'>" + data.RentalNo + "</div></td>" +
                "<td><div><div class='rentalDateValue' id='rentalDateValue_" + RECEIVE.ITEM.totalRow + "'>" + data.TransactionDate.toDefaultFormatDate() + "</div>" +
                "<input type='hidden' class='rentalDate' id='rentalDate_" + RECEIVE.ITEM.totalRow + "' value='" + data.TransactionDate.toDate() + "' /></div></td>" +
                "<td><div><div class='rentalCcy' id='rentalTotalCcy_" + RECEIVE.ITEM.totalRow + "'>Rp &nbsp;</div>" +
                "<div class='rentalTotalValue rentalNumericValue' id='rentalTotalValue_" + RECEIVE.ITEM.totalRow + "'>" + data.Total.toCurrency() + "</div>" +
                "<input type='hidden' class='rentalTotal' id='rentalTotal_" + RECEIVE.ITEM.totalRow + "' value='" + data.Total + "' /></div></td>" +
                "<td><div><div class='rentalCcy' id='rentalDendaCcy_" + RECEIVE.ITEM.totalRow + "'>Rp &nbsp;</div>" +
                "<div class='rentalDendaValue rentalNumericValue' id='rentalDendaValue_" + RECEIVE.ITEM.totalRow + "'>" + data.TotalDenda.toCurrency() + "</div>" +
                "<input type='hidden' class='rentalDenda' id='rentalDenda_" + RECEIVE.ITEM.totalRow + "' value='" + data.TotalDenda + "' /></div></td>" +
                "<td><div><div class='rentalCcy' id='rentalTotalAfterDendaCcy_" + RECEIVE.ITEM.totalRow + "'>Rp &nbsp;</div>" +
                "<div class='rentalTotalAfterDendaValue rentalNumericValue' id='rentalTotalAfterDendaValue_" + RECEIVE.ITEM.totalRow + "'>" + data.TotalAfterDenda.toCurrency() + "</div>" +
                "<input type='hidden' class='rentalTotalAfterDenda' id='rentalTotalAfterDenda_" + RECEIVE.ITEM.totalRow + "' value='" + data.TotalAfterDenda + "' /></div></td>" +
                "<td><div><div class='rentalCcy' id='rentalBalanceDueCcy_" + RECEIVE.ITEM.totalRow + "'>Rp &nbsp;</div>" +
                "<div class='rentalBalanceDueValue rentalNumericValue' id='rentalBalanceDueValue_" + RECEIVE.ITEM.totalRow + "'>" + data.Outstanding.toCurrency() + "</div>" +
                "<input type='hidden' class='rentalBalanceDue' id='rentalBalanceDue_" + RECEIVE.ITEM.totalRow + "' value='" + data.Outstanding + "' /></div></td>" +
                "<td><input type='text' class='rentalPayAmount' id='rentalPayAmount_" + RECEIVE.ITEM.totalRow + "' value='" + data.Outstanding + "' /></td>" +
                "<td><span class='rentalRemove' rentalId='" + RECEIVE.ITEM.totalRow + "' id='rentalRemove_" + RECEIVE.ITEM.totalRow + "'>X</span></td></tr>");
    $("#tblreceiveitem tbody tr").hover(RECEIVE.ITEM.showRemoveButton, RECEIVE.ITEM.hideRemoveButton);
    $(".rentalRemove").click(RECEIVE.ITEM.removeRowReceiveItem);
    $(".rentalPayAmount").change(RECEIVE.ITEM.calculateSubTotal);
}
RECEIVE.ITEM.showRemoveButton = function () {
    var id = $(this).attr("id");
    $("#rentalRemove_" + id).show();
}
RECEIVE.ITEM.hideRemoveButton = function () {
    var id = $(this).attr("id");
    $("#rentalRemove_" + id).hide();
}
RECEIVE.ITEM.removeRowReceiveItem = function () {
    var id = parseInt($(this).attr("rentalId"));
    $("#tblreceiveitem tbody tr#" + id).remove();
    RECEIVE.ITEM.calculateSubTotal();
}
RECEIVE.ITEM.calculateSubTotal = function () {
    var subTotal = 0;
    for (var i = 0; i < $(".rentalPayAmount").length; i++) {
        subTotal += parseInt($(".rentalPayAmount")[i].value);
    }
    if (subTotal != 0) {
        $("#totalakhir").text(subTotal.toCurrency(2));
        $(".summary").show();
    }
    else {
        $(".summary").hide();
    }
}