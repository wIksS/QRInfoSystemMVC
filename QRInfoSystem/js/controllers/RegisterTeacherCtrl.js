/**
 * Created by Виктор on 2.10.2014 г..
 */
app.controller('RegisterTeacherCtrl', ['$scope', '$location', 'auth', 'identity', 'notifier', 'teacherService', 'qrcodeService', 'baseUrl', 'currentTeacher','errorHandler',
    function ($scope, $location, auth, identity, notifier, teacherService, qrcodeService, baseUrl, currentTeacher, errorHandler) {
    $scope.isLogged = identity.isLogged();
    $scope.isAdmin = identity.isAdmin();
    if (!$scope.isLogged) {
        //$location.path('/unauthorized');
    }
    debugger;
    $scope.$on('$routeChangeStart', function (next, current) {
        debugger;
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
    });


    $scope.register = function (teacher) {
        if (!$scope.teacherForm.$valid) {
            notifier.error("Your data is invalid !");
            return;
        }
        var user = identity.getUser();
        if (!user.token) {
            notifier.error('You must be logged in to register teachers');
            return;
        }
        teacher.identity = user.token;
        if (((teacher.Phone | 0) < 0) && teacher.Phone) {
            notifier.error('Phone cannot be negative');
            return;
        }
        teacherService.register(teacher)
            .then(function (data) {
                notifier.success("Successfuly registered teacher");
                $scope.isRegistered = true;
                currentTeacher.setTeacher(data);
                var input = { identity: user.token, id: data.Id };
                qrcodeService.generateQRCode(input);
                $scope.isRegistered = true
            }, function (err) {
                errorHandler.handle(err);
            });
    }

    $scope.generate = function () {
        var teacher = currentTeacher.getTeacher();
        var user = identity.getUser();
        var url = baseUrl + '/#/teachers/' + teacher.Id;
        var input = { identity: user.token, id: teacher.Id };
        qrcodeService.generateQRCode(input)
            .then(function (data) {
                url += '/' + data.Code;
                new QRCode(document.getElementById("qrcode"), url);
            }, function (err) {
                errorHandler.handle(err);
            })
    }

    $scope.isRegistered = false;
}]);