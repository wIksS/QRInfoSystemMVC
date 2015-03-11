/**
 * Created by Виктор on 27.9.2014 г..
 */

app.controller('LoginCtrl', ['$scope', 'auth', 'identity', 'notifier', '$location', 'teacherService','errorHandler',
    function ($scope, auth, identity, notifier, $location, teacherService,errorHandler) {
    var user = identity.getUser();
    $scope.isLogged = identity.isLogged();
    $scope.isAdmin = identity.isAdmin();
    $scope.pesho = 'gosho';
    $scope.user = $scope.user || {};
    $scope.username = user.username;

    $scope.$on('$routeChangeStart', function(next, current) { 
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
    });

    teacherService.getTeachers()
        .then(function (data) {
            $scope.teachers = data;
        }, function (err) {
            errorHandler.handle(err);
        });

    $scope.showTeacher = function(id){
        $location.path('/teachers/' + id);
    };

    $scope.login = function(user){
        auth.login(user)
            .then(function(data){
                identity.loginUser(data)
                .then(function (data) {
                    debugger;
                    $scope.isLogged = identity.isLogged();
                    $scope.pesho = 'pesho';
                    var user = identity.getUser();
                    $scope.username = user.username;
                    $scope.isAdmin = identity.isAdmin();
                    notifier.success('Successful login !');
                    $location.path('/Admin')
                });               
            },
            function(err){
                errorHandler.handle(err);
            });
        };

    $scope.logout = function(){
        $location.path('/');
        var user = identity.getUser();
        identity.logoutUser();
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
        $scope.user.username = '';
        $scope.user.password = '';
        notifier.success('Successful logout');
    }
}]);