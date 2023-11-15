var FilteredProducts = {
    settings: {
        ajax: true,
        fetchUrl: false,
        browserPath: false,
    },

    params: {
        jqXHR: false,
    },

    init: function (settings) {
        this.settings = $.extend({}, this.settings, settings);
    },

    getFilteredProducts: function (pageNumber, stockStatus, categoryId) {
        if (this.params.jqXHR && this.params.jqXHR.readyState !== 4) {
            this.params.jqXHR.abort();
        }

        var urlBuilder = createProductsURLBuilder(this.settings.browserPath);
        urlBuilder.addParameter('categoryId', categoryId);
        urlBuilder.addParameter('stockStatus', stockStatus);

        if (pageNumber) {
            urlBuilder.addParameter('pageNumber', pageNumber);
        }

        var beforePayload = {
            urlBuilder: urlBuilder
        };

        $(this).trigger({ type: "before", payload: beforePayload });

        this.setBrowserHistory(urlBuilder.build());

        this.setLoadWaiting(true);

        var self = this;
        this.params.jqXHR = $.ajax({
            cache: false,
            url: urlBuilder.build(),
            type: 'GET',
            success: function (response) {
                $('.products-wrapper').html(response);
                $('html, body').animate({ scrollTop: $('.center-2 .page').offset().top }, 'slow');
                $(self).trigger({ type: "loaded" });
            },
            error: function () {
                $(self).trigger({ type: "error" });
            },
            complete: function () {
                self.setLoadWaiting(false);
            }
        });
    },

    setLoadWaiting: function (enable) {
        var $busyEl = $('.ajax-products-busy');
        if (enable) {
            $busyEl.show();
        } else {
            $busyEl.hide();
        }
    },

    setBrowserHistory: function (url) {
        if (window.history.replaceState) {
            window.history.replaceState({ path: url }, '', url);
        }
    }
};

function createProductsURLBuilder(basePath) {
    return {
        params: {
            basePath: basePath,
            query: {}
        },

        addParameter: function (name, value) {
            this.params.query[name] = value;
            return this;
        },

        build: function () {
            var query = $.param(this.params.query);
            var url = this.params.basePath;
            return url.indexOf('?') !== -1 ? url + '&' + query : url + '?' + query;
        }
    };
}

// Sayfanın içerisinde olan categoryId değişkeni alınıyor
var categoryIdFromPage = typeof categoryId !== 'undefined' ? categoryId : null;

$(document).ready(function () {
    $('#stock-status').change(function () {
        var selectedStockStatus = $(this).val();
        // Sayfa numarası, stok durumu ve kategori ID ile ürünleri getirin
        FilteredProducts.getFilteredProducts(1, selectedStockStatus, categoryIdFromPage);
    });

    FilteredProducts.init({
        ajax: true,
        fetchUrl: '@Url.Action("GetFilteredCategoryProducts", "ProductStock")',
        browserPath: window.location.pathname
    });
});

console.log("------------ custom page worked ------------")
