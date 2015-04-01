app.directive('search', function() {
    return {
        template: '<div class="input-group" id="search-container">'+
                '<input type="text" id="search" ng-change="goToSearchTeachers()" class="form-control" ng-model="search" placeholder="Search" name="q">' +
                '<div class="input-group-btn">' +
                    '<button class="btn btn-default"><i class="glyphicon glyphicon-search"></i></button>' +
                '</div>' +
            '</div>'
    };
});