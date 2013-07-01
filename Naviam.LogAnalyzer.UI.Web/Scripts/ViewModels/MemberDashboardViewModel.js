function Settings(apiUrl) {
    this.apiUrl = apiUrl;
}

var settings;

function Datasource(parsedModel) {
    var self = this;
    self.dataSourceName = parsedModel.Name;
}

function MemberDashboardViewModel(serverModel) {
    var self = this;
    var parsedModel = JSON.parse(serverModel);
    
    settings = new Settings(parsedModel.ApiUrl);
    
    self.userDatasources = ko.observableArray();

    self.loadDataSources = function() {
        $.get(settings.apiUrl+"datasource", function (data) {
            self.userDatasources.removeAll();
            $.each(data.DataSources, function (index, value) {
                var ds = new Datasource(value);
                self.userDatasources.unshift(ds);
            });
        });
    };
    self.loadDataSources();
}