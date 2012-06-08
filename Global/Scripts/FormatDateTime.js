function getMonth() {
    var month = new Date().getMonth();
    return month;
}
function getYear() {
    var year = new Date().getFullYear();
    return year;
}

Number.prototype.ConvertToMonth = function () {
    var months = new Array("January",
    "February", "March", "April",
    "May", "June", "July",
    "August", "September",
    "October", "November",
    "December");

    return months[this];
}
function getDate() {
    var date = new Date().getDate();
    return date;
}
String.prototype.toDefaultFormatDate = function () {
    var dateFormated = new Date(parseInt(this.replace(/\/Date\((-?\d+)\)\//, '$1')));
    var day = dateFormated.getDate();
    var month = dateFormated.getMonth();
    var year = dateFormated.getFullYear();
    return day + " " + month.ConvertToMonth() + " " + year;
}
String.prototype.toDate = function () {
    return new Date(parseInt(this.replace(/\/Date\((-?\d+)\)\//, '$1')));
}