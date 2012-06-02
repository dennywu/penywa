//var RENTAL = {};
RENTAL.ITEM = {};

RENTAL.ITEM.addRow = function () {
    $("#tblitem tbody").append("<tr><td><input type='text' name='itemname'/></td><td><textarea></textarea></td>" +
                        "<td><input type='number' name='qty' class='itemqty' min='1'/></td>" +
                        "<td><input type='text' name='harga' class='itemharga'/></td>" +
                        "<td><div><div class='itemtotalCcy'>Rp</div><div class='itemtotalValue'>...</div></div></td>"+
                        "<td><span id='itemRemove'>X</span></td></tr>");
}
RENTAL.ITEM.showRemoveButton = function () {
    $("#itemRemove").show();
}
RENTAL.ITEM.hideRemoveButton = function () {
    $("#itemRemove").hide();
}