$(document).ready(function () {
    $('#product-table').DataTable({
        processing: false,
        serverSide: true,
        ajax: {
            "url": "Customer/GetProducts",
            "type": "POST",
            "datatype": "JSON",
            "contentType": 'application/json; charset=utf-8',
            "data": function (data) {
                return data = JSON.stringify(data);
            },
            "error": function (xhr, ajaxOptions, thrownError) {
                $('.loading').hide();
            }
        },
        columns: [
            { "title": "Id", "data": "ProductId", "width": "10%" },
            { "title": "Title", "data": "Title" }
        ],
        order: [[0, "asc"]],
        deferRender: true
    });
});