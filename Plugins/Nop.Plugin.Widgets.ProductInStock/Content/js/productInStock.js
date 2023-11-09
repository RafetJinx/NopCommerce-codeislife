function updateProductList(stockStatus) {
    var productList;

    switch (stockStatus) {
        case 'all':
            productList = allProducts;
            break;
        case 'inStock':
            productList = inStockProducts;
            break;
        case 'outOfStock':
            productList = outOfStockProducts;
            break;
    }
    console.log(productList);
    CatalogProducts.setProducts(productList);
    
    CatalogProducts.getProducts();
    console.log("------------------");
}

$(document).ready(function () {
    updateProductList('all');

    $('#stockStatus').change(function () {
        updateProductList($(this).val());
    });
});