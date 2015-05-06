/**
 * Created by Виктор on 27.9.2014 г..
 */

app.controller('LoginCtrl', ['$scope', '$rootScope','auth', 'identity', 'notifier', '$location', 'teacherService','errorHandler','currentTeacher',
    function ($scope, $rootScope, auth, identity, notifier, $location, teacherService,errorHandler,currentTeacher) {
    var user = identity.getUser();
    $scope.isLogged = identity.isLogged();
    $scope.isAdmin = identity.isAdmin();
    $scope.isTeacher = identity.isInRole('Teacher');
    $scope.user = user || {};
    $scope.username = user.username;

    $scope.$on('$routeChangeStart', function (next, current) {
        user = identity.getUser();

        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
        $scope.isTeacher = identity.isInRole('Teacher');
        $scope.user = $scope.user || {};
        $scope.username = user.username;
    });

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
                    initLinksAnimations();
                });               
            },
            function(err){
                errorHandler.handle(err);
            });
        };

    $scope.logout = function(){
        $location.path('/Login');
        var user = identity.getUser();
        identity.logoutUser();
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
        $scope.user.username = '';
        $scope.user.password = '';
        currentTeacher.deleteSessionTeacher();
        notifier.success('Successful logout');
        initLinksAnimations();
    }

    $scope.goToSearchTeachers = function () {
        var path = $location.path();
        if (path != "/" && path != "/teachers") {
            $location.path("/");
        }

        $rootScope.$broadcast("searchTeacher", { search: search.value });
    }
    $scope.$on('$viewContentLoaded', function () {
        $('ul.nav a').on('click', function () {
            $('ul.nav a').parent().removeClass('active');
            $(this).parent().addClass('active');
        })
    });

    $scope.$on('$viewContentLoaded', function () {
        moveScrollToContent();
    });
}]);