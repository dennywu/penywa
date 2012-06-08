RECEIVE.ITEM = {}
RECEIVE.ITEM.totalRow = 0;

RECEIVE.ITEM.setupReceiveItem = function () {
    $("#selectRental").click(RECEIVE.ITEM.initRentalList);
}

RECEIVE.ITEM.initRentalList = function () {
    RECEIVE.ITEM.showRentalListDialog();
    RECEIVE.ITEM.getDataRental();
}

RECEIVE.ITEM.showRentalListDialog = function () {
    $("#DialogRentalList").show();
    $("#TblRentalListContent tbody").empty();
}

RECEIVE.ITEM.getDataRental = function () {
    $.ajax({
        type: 'GET',
        url: '/Penerimaan/GetAllRental',
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
                        "<td class='TransactionDate'>" + data[i].TransactionDate.toDefaultFormatDate() + "</td>" +
                        "<td class='Total'>Rp " + data[i].Total.toCurrency() + "</td>" +
                    "</tr>");
    });
    $("#TblRentalListContent tbody tr").click(RECEIVE.ITEM.GetReceiveItemDetail);
}

RECEIVE.ITEM.GetReceiveItemDetail = function () {
    var RentalId = $("#TblRentalListContent tbody tr").attr("id");
    $.ajax({
        type: 'GET',
        url: '/Penerimaan/GetReceiveItemDetail?rentalId=' + RentalId,
        dataType: 'json',
        success: function (data) {
            RECEIVE.ITEM.addReceiveItemToTable(data);
            RECEIVE.ITEM.closeRentalListDialog();
        }
    });
}
RECEIVE.ITEM.addReceiveItemToTable = function (data) {
    RECEIVE.ITEM.totalRow++;
    $("#tblreceiveitem tbody").append("<tr id='" + RECEIVE.ITEM.totalRow + "'><td>" +
                "<input type='hidden' class='receiveItemId' id='receiveItemId_" + RECEIVE.ITEM.totalRow + "' value='"+data.RentalId+"' />" +
                "<div class='rentalNo' id='rentalNo_" + RECEIVE.ITEM.totalRow + "'>" + data.RentalNo + "</div></td>" +
                "<td><div><div class='rentalDateValue' id='rentalDateValue_" + RECEIVE.ITEM.totalRow + "'>" + data.TransactionDate.toDefaultFormatDate() + "</div>" +
                "<input type='hidden' class='rentalDate' id='rentalDate_" + RECEIVE.ITEM.totalRow + "' value='" + data.TransactionDate.toDate() + "' /></div></td>" +
                "<td><div><div class='rentalCcy' id='rentalTotalCcy_" + RECEIVE.ITEM.totalRow + "'>Rp</div>" +
                "<div class='rentalTotalValue' id='rentalTotalValue_" + RECEIVE.ITEM.totalRow + "'>" + data.Total.toCurrency() + "</div>" +
                "<input type='hidden' class='rentalTotal' id='rentalTotal_" + RECEIVE.ITEM.totalRow + "' value='" + data.Total + "' /></div></td>" +
                "<td><div><div class='rentalCcy' id='rentalDendaCcy_" + RECEIVE.ITEM.totalRow + "'>Rp</div>" +
                "<div class='rentalDendaValue' id='rentalDendaValue_" + RECEIVE.ITEM.totalRow + "'>10,000.00</div>" +
                "<input type='hidden' class='rentalDenda' id='rentalDenda_" + RECEIVE.ITEM.totalRow + "' value='10000' /></div></td>" +
                "<td><div><div class='rentalCcy' id='rentalTotalAfterDendaCcy_" + RECEIVE.ITEM.totalRow + "'>Rp</div>" +
                "<div class='rentalTotalAfterDendaValue' id='rentalTotalAfterDendaValue_" + RECEIVE.ITEM.totalRow + "'>110,000.00</div>" +
                "<input type='hidden' class='rentalTotalAfterDenda' id='rentalTotalAfterDenda_" + RECEIVE.ITEM.totalRow + "' value='110000' /></div></td>" +
                "<td><input type='text' class='rentalPayAmount' id='rentalPayAmount_" + RECEIVE.ITEM.totalRow + "'></td>"+
                "<td><span class='rentalRemove' rentalId='" + RECEIVE.ITEM.totalRow + "' id='rentalRemove_" + RECEIVE.ITEM.totalRow + "'>X</span></td></tr>")
}