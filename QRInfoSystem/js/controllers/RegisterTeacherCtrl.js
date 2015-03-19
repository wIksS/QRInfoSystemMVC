/**
 * Created by Виктор on 2.10.2014 г..
 */
app.controller('RegisterTeacherCtrl', ['$scope', '$location', 'auth', 'identity', 'notifier', 'teacherService', 'qrcodeService', 'baseUrl', 'currentTeacher', 'errorHandler',
    function ($scope, $location, auth, identity, notifier, teacherService, qrcodeService, baseUrl, currentTeacher, errorHandler) {
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
        $scope.user = identity.getUser();
        $scope.isTeacher = identity.isInRole('Teacher');
        $scope.isRegistered = false;
        $scope.isUpdate = $location.path().indexOf('Admin') >= 0;

        if (!$scope.isLogged) {
            //$location.path('/unauthorized');
        }
        $scope.$on('$routeChangeStart', function (next, current) {
            $scope.isLogged = identity.isLogged();
            $scope.isAdmin = identity.isAdmin();
            $scope.isTeacher = identity.isInRole('Teacher');
        });

        $scope.uploadImage = function () {
            var f = document.getElementById('file').files[0],
            r = new FileReader();
            r.onloadend = function (e) {
                var teacher = currentTeacher.getTeacher();
                var data = e.target.result;
                teacher.identity = $scope.user.token;

                teacherService.uploadImage({ "file": data }, teacher)
                    .then(function (data) {
                        alert(data);
                    }, function (err) {
                        errorHandler.handle(err);
                    });
                //send you binary data via $http or $resource or do anything else with it
            }

            r.readAsArrayBuffer(f);
        }

        $scope.getTeacherId = function () {
            return currentTeacher.getTeacher().Id;
        }

        $scope.update = function (teacher) {
            if ($scope.teacherForm && !$scope.teacherForm.$valid) {
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

            teacherService.update(teacher)
                .then(function (data) {
                    notifier.success("Successfuly updated teacher");
                    $scope.isRegistered = true;
                    currentTeacher.setTeacher(data);
                    var input = { identity: user.token, id: data.Id };
                    //qrcodeService.generateQRCode(input);
                    $scope.isRegistered = true
                    teacherService.getUserTeacher({ identity: user.token })
                       .then(function (data) {
                           currentTeacher.setSessionTeacher(data);
                       }, function (err) {
                           errorHandler.handle(err);
                       })
                }, function (err) {
                    errorHandler.handle(err);
                });
        }

        $scope.register = function (teacher) {
            if ($scope.teacherForm && !$scope.teacherForm.$valid) {
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

        $scope.setSelectedFile = function (element) {
            $scope.$apply(function ($scope) {
                $scope.selectedFile = element.files[0];
            });
        };
    }]);