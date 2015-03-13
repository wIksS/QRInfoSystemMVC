app.controller('UsersCtrl', ['$scope', '$location', 'auth', 'identity', 'baseUrl', 'notifier', 'errorHandler','usersService',
    function ($scope, $location, auth, identity, baseUrl, notifier, errorHandler,usersService) {
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
        var user = identity.getUser();
        usersService.getUsers(user.token)
            .then(function (data) {
                $scope.users = data;
                for (var i = 0; i < data.length; i++) {
                    data[i].isAdmin = data[i].Roles.indexOf('Admin') >= 0;
                    data[i].isTeacher = data[i].Roles.indexOf('Teacher') >= 0;
                }
            }, function (err) {
                errorHandler.handle(err);
            }
        );

        $scope.addRole = function(currentUser,roleName){
            usersService.addRole(currentUser, roleName, user.token)
                .then(function (data) {
                    notifier.success(data);
                    if (roleName == 'Admin') {
                        currentUser.isAdmin = true;
                    }
                    if (roleName == 'Teacher') {
                        currentUser.isTeacher = true;
                    }
                }, function (err) {
                    errorHandler.handle(err);
                });
        }

        $scope.deleteRole = function (currentUser, roleName) {
            usersService.deleteRole(currentUser, roleName, user.token)
                .then(function (data) {
                    notifier.success(data);
                    if (roleName == 'Admin') {
                        currentUser.isAdmin = false;
                    }
                    if (roleName == 'Teacher') {
                        currentUser.isTeacher = false;
                    }
                }, function (err) {
                    errorHandler.handle(err);
                }
            );
        }

        $scope.deleteUser = function (currentUser) {
            usersService.deleteUser(currentUser, user.token)
                .then(function (data) {
                    notifier.success(data);
                    var index = $scope.users.indexOf(currentUser);
                    if (index > -1) {
                        $scope.users.splice(index, 1);
                    }
                }, function (err) {
                    errorHandler.handle(err);
                }
            );
        }
    }
]);