/**
 * Created by Виктор on 2.10.2014 г..
 */
app.controller('SheduleCtrl', ['$scope', '$location', '$routeParams', 'auth', 'identity', 'notifier', 'teacherService', 'currentTeacher','errorHandler',
    function ($scope, $location, $routeParams, auth, identity, notifier, teacherService, currentTeacher,errorHandler) {
    $scope.isLogged = identity.isLogged();
    $scope.isAdmin = identity.isAdmin();
    $scope.isTeacher = identity.isInRole('Teacher');
    $scope.id = $routeParams.id;

    if (!$scope.isLogged) {
        //$location.path('/unauthorized');
    }
    var from;
    var to;

    $('#from-hour-picker').timepicker();
    $('#from-hour-picker').change(function () {
        from = this.value;
    });

    $('#to-hour-picker').timepicker();
    $('#to-hour-picker').change(function () {
        to = this.value;
    });
    $scope.updateShedule = function (shedule) {
        if (!$scope.sheduleForm.$valid) {
            notifier.error("Your data is invalid !");
            return;
        }

        if (!$scope.year) {
            notifier.error('You must select day');
            return;
        }
        var user = identity.getUser();
        if (!user.token) {
            notifier.error('You must be logged in to register teachers');
            return;
        }
        shedule.identity = user.token;
        shedule.StartDate = $scope.year + ' ' + from;
        shedule.EndDate = $scope.year + ' ' + to;
        var teacher = currentTeacher.getTeacher();
        if (!teacher || teacher == {}) {
            shedule.TeacherId = $routeParams.id;
            if (!shedule.TeacherId) {
                notifier.error('You must select a teacher');
                return;
            }
        }
        else {
            shedule.TeacherId = teacher.Id;
        }
        teacherService.updateShedule(shedule)
            .then(function (data) {
                notifier.success('Successfuly updated shedule');
            }, function (err) {
                errorHandler.handle(err);
            });
    }

    $scope.makeDatepicker = function (selector) {
        $(selector).glDatePicker({
            onClick: function (target, cell, date, data) {
                var year = date.getFullYear() + '-' +
                    ((date.getMonth() | 0) + 1) + '-' +
                    date.getDate();
                $scope.year = year;
                target[0].value = year;
                $scope.$apply();
            },
            cssName: 'flatwhite'
        });
    }

    $scope.makeDatepicker('#mydate');
}]);