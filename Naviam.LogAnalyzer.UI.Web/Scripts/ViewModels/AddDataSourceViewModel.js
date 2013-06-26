function DataSourceField() {
    var self = this;
    self.fieldName = ko.observable('');
    self.typeId = ko.observable(1);
}

function AddDataSourceViewModel() {
    var self = this;
    self.fieldTypes = [{ typeId: 1, typeName: 'String' }, { typeId: 2, typeName: 'Number' }, { typeId: 3, typeName: 'DateTime' }];
    //observables
    self.dataSourceName = ko.observable('');

    self.fieldsMapping = ko.observableArray();

    self.addFieldMapping = function() {
        self.fieldsMapping.push(new DataSourceField());
    };
    
    self.removeFieldMapping = function (fieldMapping) {
        self.fieldsMapping.remove(fieldMapping);
    }
    
    self.saveDataSource = function() {
        $.post("http://localhost/rdaapi/api/datasource/post", { DataSourceName: self.dataSourceName() }, function (data) {
            alert(data);
        });
    };
}