/**
 * Created by Виктор on 27.9.2014 г..
 */

app.controller('LoginCtrl', ['$scope', 'auth', 'identity', 'notifier', '$location', 'teacherService','errorHandler','currentTeacher',
    function ($scope, auth, identity, notifier, $location, teacherService,errorHandler,currentTeacher) {
    var user = identity.getUser();
    $scope.isLogged = identity.isLogged();
    $scope.isAdmin = identity.isAdmin();
    $scope.isTeacher = identity.isInRole('Teacher');
    $scope.user = $scope.user || {};
    $scope.username = user.username;

    $scope.$on('$routeChangeStart', function(next, current) { 
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
        $scope.isTeacher = identity.isInRole('Teacher');
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
                    $scope.isLogged = identity.isLogged();
                    var user = identity.getUser();
                    $scope.username = user.username;
                    $scope.isAdmin = identity.isAdmin();
                    $scope.isTeacher = identity.isInRole('Teacher');
                    if ($scope.isTeacher) {
                        teacherService.getUserTeacher({ identity: user.token })
                            .then(function (data) {
                                currentTeacher.setSessionTeacher(data);
                                currentTeacher.setTeacher(data);
                            }, function (err) {
                                errorHandler.handle(err);
                            })
                    }

                    notifier.success('Successful login !');
                    $location.path('/teachers');
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
        currentTeacher.deleteSessionTeacher();
        notifier.success('Successful logout');
    }
}]);