$(function () {

    $(this).on("click", ".clsManageProducts", function () {
        ProductController.ShowProducts();
    });

    $(this).on("click", ".clsRefreshProducts", function () {
        ProductController.RefreshProductDetails();
    });

    $(this).on("click", ".clsManageProduct", function () {
        var ID = $(this).attr("object-id");
        var Mode = $(this).attr("object-mode");
        ProductController.LoadManageProductScreen(ID, Mode);
    });


    $(this).on("click", "#btnManageProduct", function () {
        ProductController.Manage();
    });

    $(this).on("keyup", ".clsProductSearch", function () {
        var searchText = $(".clsProductSearch").val().toLowerCase();
        $(".clsProductFilter tr").hide();
        $(".clsProductFilter tr").filter(function () {
            return !$(this).hasClass("clsNoProductRecords") && $(this).attr("search-field").toLowerCase().indexOf(searchText) >= 0;
        }).show();

        if ($(".clsProductFilter tr:visible").length === 0) {
            $(".clsNoProductRecords").show();
        }
        else {
            $(".clsNoProductRecords").hide();
        }
    });
});