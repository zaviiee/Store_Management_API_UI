var CategoryController = {

    ShowCategories: function () {
        MainController.StartLoading("Loading Categories");
        $.get("Category/ShowAllCategories", function (data) {
            MainController.LoadScreen(data);
        })
            .fail(function () {
                MainController.StopLoading("Error Loading Categories");
            });
    },

    RefreshCategoryDetails: function () {
        $(".clsCategorySearch").val("");
        MainController.ShowLoading();
        $.get("Category/ShowAllCategoryDetails", function (data) {
            $(".clsCategoryDetails").html(data);
            MainController.HideLoading();
        })
            .fail(function () {
                MainController.HideLoading();
            });
    },

    LoadManageCategoryScreen: function (ID, Mode) {
        var categoryRequest = { ID: ID, Mode: Mode };
        MainController.StartLoading("Loading Category Details");
        $.post("Category/ShowManageScreen",
            { categoryRequest: categoryRequest },
            function (data) {
                MainController.LoadScreen(data);
            })
            .fail(function () {
                MainController.StopLoading("Error Loading Category");
            });
    },

    Manage: function () {
        var formData = $("#frmManageCategory").serialize();
        MainController.StartLoading("Loading Category Details");
        $.post("Category/Manage",
            formData,
            function (data) {
                MainController.LoadScreen(data);
            })
            .fail(function () {
                MainController.StopLoading("Error Loading Category");
            });
    }

};