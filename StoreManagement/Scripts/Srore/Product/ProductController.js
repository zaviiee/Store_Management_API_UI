var ProductController = {

    ShowProducts: function () {
        MainController.StartLoading("Loading Products");
        $.get("Product/ShowAllProducts", function (data) {
            MainController.LoadScreen(data);
        })
            .fail(function () {
                MainController.StopLoading("Error Loading Products");
            });
    },

    RefreshProductDetails: function () {
        MainController.ShowLoading();
        $.get("Product/ShowAllProductDetails", function (data) {
            $(".clsProductDetails").html(data);
            MainController.HideLoading();
        })
            .fail(function () {
                MainController.HideLoading();
            });
    },

    LoadManageProductScreen: function (ID, Mode) {
        var productRequest = { ID: ID, Mode: Mode };
        MainController.StartLoading("Loading Product Details");
        $.post("Product/ShowManageScreen",
            { productRequest: productRequest },
            function (data) {
                MainController.LoadScreen(data);
            })
            .fail(function () {
                MainController.StopLoading("Error Loading Product");
            });
    },

    Manage: function () {
        var formData = $("#frmManageProduct").serialize();
        MainController.StartLoading("Loading Product Details");
        $.post("Product/Manage",
            formData,
            function (data) {
                MainController.LoadScreen(data);
            })
            .fail(function () {
                MainController.StopLoading("Error Loading Product");
            });
    }


};