$(function () {

    $(this).on("click", ".clsManageCategories", function () {
        CategoryController.ShowCategories();
    });

    $(this).on("click", ".clsRefreshCategories", function () {
        CategoryController.RefreshCategoryDetails();
    });

    $(this).on("click", ".clsManageCategory", function () {
        var ID = $(this).attr("object-id");
        var Mode = $(this).attr("object-mode");
        CategoryController.LoadManageCategoryScreen(ID, Mode);
    });

    $(this).on("click", "#btnManageCategory", function () {
        CategoryController.Manage();
    });

    $(this).on("keyup", ".clsCategorySearch", function () {
        var searchText = $(".clsCategorySearch").val().toLowerCase();
        $(".clsCategoryFilter tr").hide();
        $(".clsCategoryFilter tr").filter(function () {
            return !$(this).hasClass("clsNoCategoryRecords") && $(this).attr("search-field").toLowerCase().indexOf(searchText) >= 0;
        }).show();

        if ($(".clsCategoryFilter tr:visible").length === 0) {
            $(".clsNoCategoryRecords").show();
        }
        else {
            $(".clsNoCategoryRecords").hide();
        }
    });
});