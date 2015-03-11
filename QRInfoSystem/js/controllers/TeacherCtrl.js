/**
 * Created by Виктор on 4.10.2014 г..
 */
/**
 * Created by Виктор on 2.10.2014 г..
 */
app.controller('TeacherCtrl', ['$scope', '$location', 'auth', 'identity', 'baseUrl', 'notifier', 'teacherService', 'currentTeacher', 'qrcodeService','errorHandler',
    function ($scope, $location, auth, identity, baseUrl, notifier, teacherService, currentTeacher, qrcodeService, errorHandler) {
    $scope.isLogged = identity.isLogged();
    $scope.isAdmin = identity.isAdmin();

    $scope.$on('$routeChangeStart', function (next, current) {
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
    });

    teacherService.getTeachers()
        .then(function (data) {
            $scope.teachers = data;
        }, function (err) {
            errorHandler.handle(err);
        });

    $scope.showTeacher = function (id) {
        $location.path('/teachers/' + id);
    }
    $scope.isLogged = identity.isLogged();
    $scope.isAdmin = identity.isAdmin();

    $scope.delete = function (id) {
        var user = identity.getUser();
        teacherService.deleteTeacher({ id: id, identity: user.token })
            .then(function (data) {
                window.location.reload();
                notifier.success("Successfuly deleted teacher");
            }, function (err) {
                errorHandler.handle(err);
            });
    }

    $scope.getShedule = function (teacher) {
        var user = identity.getUser();
        teacherService.getTeacherSheduleAdmin({ id: teacher.Id, identity: user.token })
            .then(function (data) {
                currentTeacher.setTeacher(teacher);
                $scope.shedule = [];
                for(var i =0;i<data.length;i++){
                    $scope.shedule.push({
                        start: data[i].StartDate,
                        end: data[i].EndDate,
                        title:"Room : " + data[i].RoomName
                    })
                }
                $('#calendar').fullCalendar({
                    dayClick: function (date, jsEvent, view) {
                        $('#calendar')
                            .fullCalendar('gotoDate', date);
                        $('#calendar')
                            .fullCalendar('changeView', 'agendaDay');
                    },
                    header: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'month,basicWeek, agendaDay',
                        ignoreTimezone: false
                    },
                    events: $scope.shedule,
                    timeFormat: 'H(:mm)'
                });
            }, function (err) {
                errorHandler.handle(err);
            });
    };

    $scope.generate = function (id) {
        var user = identity.getUser();
        var url = baseUrl + '/#/teachers/' + id;
        var input = { identity: user.token, id: id };
        qrcodeService.getQRCode(input)
            .then(function (data) {
                var qrCodeId = "qrcode" + id;
                url += '/' + data.Code;
                var element = document.getElementById(qrCodeId);
                if(element.innerHTML != ""){
                    return;
                }
                new QRCode(element, {
                    text: url,
                    width: 128,
                    height: 128,
                });
            }, function (err) {
                errorHandler.handle(err);
            })
    }
}]);