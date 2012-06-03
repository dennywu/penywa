RENTAL.ITEM = {};
RENTAL.ITEM.sessionTimeOutSearchingItem;
RENTAL.ITEM.totalRow = 0;
RENTAL.ITEM.id;

RENTAL.ITEM.setupItem = function () {
    $("#addRow").click(RENTAL.ITEM.addRow);
    RENTAL.ITEM.addRow();
}
RENTAL.ITEM.searchItem = function (ev) {
    RENTAL.ITEM.id = parseInt($(this).attr("id"));
    window.clearTimeout(RENTAL.ITEM.sessionTimeOutSearchingItem);
    if (ev.keyCode == "13") {
        $("#itemId_" + RENTAL.ITEM.id).val('');
        RENTAL.ITEM.clearSearchedResult();
        RENTAL.ITEM.showLoading();
        RENTAL.ITEM.searchingItem();
    }
    else if (ev.keyCode == "27") {
        $(".inputPartName").blur();
        RENTAL.ITEM.hideSearchedResult();
        var id = $(this).attr("id");
        RENTAL.ITEM.validateItemRow(id);
    }
    else {
        $("#itemId_" + RENTAL.ITEM.id).val('');
        RENTAL.ITEM.clearSearchedResult();
        RENTAL.ITEM.showLoading();
        RENTAL.ITEM.sessionTimeOutSearchingItem = window.setTimeout(RENTAL.ITEM.searchingItem, 1000);
    }
}
RENTAL.ITEM.searchingItem = function () {
    var key = $(".inputPartName_"+RENTAL.ITEM.id).val();
    if (key == "")
        return RENTAL.ITEM.clearSearchedResult();
    $.ajax({
        type: 'GET',
        url: '/Item/SearchItemByName?key=' + key,
        dataType: 'json',
        success: RENTAL.ITEM.searchingItemCallBack
    });
}
RENTAL.ITEM.searchingItemCallBack = function (data) {
    RENTAL.ITEM.clearSearchedResult();
    if (data.length == 0) {
        RENTAL.ITEM.showEmptyResult();
    }
    else {
        for (var i = 0; i < data.length; i++) {
            $("#searchItemResult_" + RENTAL.ITEM.id).append(RENTAL.ITEM.createSearchedItemRow(data[i]));
        }
    }
    $("#searchItemResult_" + RENTAL.ITEM.id + " .contain").click(RENTAL.ITEM.ItemChosen);
}
RENTAL.ITEM.ItemChosen = function () {
    var itemId = $(this).attr("id");
    $.ajax({
        type: 'GET',
        url: '/Item/GetItemById?id=' + itemId,
        dataType: 'json',
        success: RENTAL.ITEM.ItemChosenCallBack
    });
    
}
RENTAL.ITEM.ItemChosenCallBack = function (data) {
    $("#itemId_" + RENTAL.ITEM.id).val(data.ItemId);
    $(".inputPartName_" + RENTAL.ITEM.id).val(data.Name);
    $("#inputDeskripsi_" + RENTAL.ITEM.id).val(data.Deskripsi);
    $("#inputQty_" + RENTAL.ITEM.id).val("1");
    $("#inputHarga_" + RENTAL.ITEM.id).val(data.Harga);
    RENTAL.ITEM.validateItemRow(RENTAL.ITEM.id);
    RENTAL.ITEM.calculateTotal(RENTAL.ITEM.id);
}

RENTAL.ITEM.createSearchedItemRow = function (item) {
    var divContain = $("<div>", { 'class': 'contain', 'id': item.ItemId});
    var divName = $("<div>", { 'class': 'itemName', 'text': item.Name });
    var divDeskripsi = $("<div>", { 'class': 'itemAlamat', 'text': item.Deskripsi });

    divName.appendTo(divContain);
    divDeskripsi.insertAfter(divName);
    return divContain;
}
RENTAL.ITEM.clearSearchedResult = function () {
    $("#searchItemResult_" + RENTAL.ITEM.id).empty();
}
RENTAL.ITEM.showSearchedResult = function () {
    $("#searchItemResult_" + RENTAL.ITEM.id).show();
}
RENTAL.ITEM.hideSearchedResult = function () {
    $("#searchItemResult_" + RENTAL.ITEM.id).hide();
}
RENTAL.ITEM.showLoading = function () {
    $("#searchItemResult_" + RENTAL.ITEM.id).append("<div align='center' style='color:#457BD9;'>Harap Tunggu...</div>");
}
RENTAL.ITEM.showEmptyResult = function () {
    $("#searchItemResult_" + RENTAL.ITEM.id).append("<div align='center' style='color:#457BD9;'>Data Tidak Ditemukan</div>");
}
RENTAL.ITEM.removeRowItem = function () {
    var id = parseInt($(this).attr("itemId"));
    $("#tblitem tbody tr#" + id).remove();
    RENTAL.ITEM.calculateSubTotal();
}
RENTAL.ITEM.addRow = function () {
    RENTAL.ITEM.totalRow++;
    $("#tblitem tbody").append("<tr id='" + RENTAL.ITEM.totalRow + "'><td>" +
                        "<input type='hidden' id='itemId_" + RENTAL.ITEM.totalRow + "' />" +
                        "<input type='text' name='itemname' class='inputPartName inputPartName_" + RENTAL.ITEM.totalRow + "' id='" + RENTAL.ITEM.totalRow + "' placeholder='Ketik Nama Barang'/>" +
                        "<div class='itemSearchResult' id='searchItemResult_" + RENTAL.ITEM.totalRow + "'></div></td>" +
                        "<td><textarea id='inputDeskripsi_" + RENTAL.ITEM.totalRow + "'></textarea></td>" +
                        "<td><input type='number' name='qty' class='itemqty' itemid='" + RENTAL.ITEM.totalRow + "' id='inputQty_" + RENTAL.ITEM.totalRow + "' min='1'/></td>" +
                        "<td><input type='text' name='harga' class='itemharga' itemid='" + RENTAL.ITEM.totalRow + "' id='inputHarga_" + RENTAL.ITEM.totalRow + "'/></td>" +
                        "<td><div><div class='itemtotalCcy' id='itemtotalCcy_" + RENTAL.ITEM.totalRow + "'>Rp</div>" +
                        "<div class='itemtotalValue' id='itemtotalValue_" + RENTAL.ITEM.totalRow + "'></div>" +
                        "<input type='hidden' class='total' id='total_" + RENTAL.ITEM.totalRow + "'/>" +
                        "</div></td>" +
                        "<td><span class='itemRemove' itemId='" + RENTAL.ITEM.totalRow + "' id='itemRemove_" + RENTAL.ITEM.totalRow + "'>X</span></td></tr>");

    $("#tblitem tbody tr").hover(RENTAL.ITEM.showRemoveButton, RENTAL.ITEM.hideRemoveButton);
    $(".itemRemove").click(RENTAL.ITEM.removeRowItem);
    $(".inputPartName").keyup(RENTAL.ITEM.searchItem);
    $(".inputPartName").focus(function () {
        RENTAL.ITEM.id = parseInt($(this).attr("id"));
        RENTAL.ITEM.showSearchedResult();
    });
    $(".inputPartName").blur(function () {
        var id = $(this).attr("id");
        RENTAL.ITEM.validateItemRow(id);
        setTimeout(RENTAL.ITEM.hideSearchedResult, 200);
    });
    $(".itemqty").change(function () {
        var id = $(this).attr("itemId");
        RENTAL.ITEM.calculateTotal(id);
    });
    $(".itemharga").change(function () {
        var id = $(this).attr("itemId");
        RENTAL.ITEM.calculateTotal(id);
    });
}
RENTAL.ITEM.showRemoveButton = function () {
    var id = $(this).attr("id");
    $("#itemRemove_" + id).show();
}
RENTAL.ITEM.hideRemoveButton = function () {
    var id = $(this).attr("id");
    $("#itemRemove_" + id).hide();
}
RENTAL.ITEM.validateItemRow = function (id) {
    var itemId = $("#itemId_" + id).val();
    if (itemId == "" && $(".inputPartName_"+id).val() != "") {
        $("#tblitem tbody tr#" + id + " td").css('background-color', '#f7b2b2');
    }
    else {
        $("#tblitem tbody tr#" + id + " td").css('background-color', '');
    }
    RENTAL.ITEM.calculateSubTotal
}
RENTAL.ITEM.calculateTotal = function (id) {
    var qty = $("#inputQty_" + id).val();
    var price = $("#inputHarga_" + id).val();
    var total = qty * price;
    $("#itemtotalValue_" + id).text(total.toCurrency(2));
    $("#total_" + id).val(total);
    $("#itemtotalCcy_" + id).show();
    RENTAL.ITEM.calculateSubTotal();
}
RENTAL.ITEM.calculateSubTotal = function () {
    var subtotal = 0;
    for (var i = 0; i < $(".total").length; i++) {
        subtotal += parseInt($(".total")[i].value);
    }
    if (subtotal != NaN || subtotal != 0) {
        $("#totalakhir").text(subtotal.toCurrency(2));
        $(".summary").show();
    }
}