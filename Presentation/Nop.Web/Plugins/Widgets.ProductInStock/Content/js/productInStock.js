$(document).ready(function () {
    $('#stock-status').change(function () {
        var selectedStockStatus = $(this).val();

    $.ajax({
        url: '/ProductStock/GetFilteredCategoryProducts',
        type: 'GET',
        data: {
            categoryId: categoryId,
            stockStatus: selectedStockStatus
        },
        success: function (data) {
            console.log(data);
            $('.product-grid .item-grid').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Rafet Failed to retrieve products: ' + thrownError);
        }
    });
});
});
