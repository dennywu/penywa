$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '/penyewaan/HistoryReceive?id=' + $("#rentalId").val(),
        dataType: 'json',
        success: function (data) {
            if (data.length == 0) {
                $("#historyReceive tbody").append("<tr><td align='center' colspan='3'><span style='color:Red;font-weight:bold;'>Tidak Ada Riwayat Penerimaan</span></td></tr>");
            }
            else {
                for (var i = 0; i < data.length; i++) {
                    $("#historyReceive tbody").append("<tr><td><strong>" + data[i].ReceiveNo + "</strong></td><td>" + data[i].ReceiveDate.toDefaultFormatDate() + "</td><td align='right'>Rp " + data[i].PayAmount.toCurrency(2) + "</td></tr>");
                }
            }
        }
    });
});