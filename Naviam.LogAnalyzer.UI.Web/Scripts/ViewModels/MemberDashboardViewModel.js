function Settings(apiUrl) {
    this.apiUrl = apiUrl;
}

var settings;

function Datasource(serverModel) {
    var self = this;
    var parsedModel = JSON.parse(serverModel);
    self.dataSourceName = parsedModel.DataSourceName;
}

function MemberDashboardViewModel(serverModel) {
    var self = this;
    var parsedModel = JSON.parse(serverModel);
    
    settings = new Settings(parsedModel.ApiUrl);
    
    self.userDatasources = ko.observableArray();

    self.loadDataSources = function() {
        $.get(settings.apiUrl+"datasource", function (data) {
            var datasources = ko.toJS(data);
            self.userDatasources.removeAll();
            $.each(datasources, function (index, value) {
                var ds = new Datasource(value);
                self.userDatasources.unshift(retailer.url);
            });
        });
    };
    self.loadDataSources();
}