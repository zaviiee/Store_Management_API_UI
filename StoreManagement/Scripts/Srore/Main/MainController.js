var MainController = {

    ClearScreen: function () {

        $("#clsMainDiv").empty();
    },

    LoadScreen: function (htmlData) {
        $("#clsMainDiv").html(htmlData);
        this.HideLoading();
    },

    ShowLoading: function () {
        $("#dvLoading").show();
    },

    HideLoading: function () {
        $("#dvLoading").hide();
    },

    StartLoading: function (loadingMessage) {
        this.ShowLoading();
        this.ClearScreen();
        $("#clsMainDiv").html(this.GetLoadingMessage(loadingMessage));
    },
    
    StopLoading: function (loadedMessage) {
        if (loadedMessage !== undefined && loadedMessage !== null && loadedMessage !== '') {
            $("#clsMainDiv").html(this.GetLoadingMessage(loadedMessage));
        }
        this.HideLoading();
    },

    GetLoadingMessage: function (loadingMessage){
        return '<div style="text-align:center;width:100%;">' + loadingMessage + '</div>';
    }
};