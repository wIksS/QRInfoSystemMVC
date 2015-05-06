/**
 * Created by Виктор on 2.10.2014 г..
 */
app.controller('TeacherDetailsCtrl', ['$scope', '$location', '$routeParams', 'auth', 'identity', 'notifier', 'teacherService','usersService','errorHandler',
        function ($scope, $location, $routeParams, auth, identity, notifier, teacherService, usersService, errorHandler) {
    $scope.isLogged = identity.isLogged();
    $scope.isAdmin = identity.isAdmin();

    $scope.$on('$routeChangeStart', function (next, current) {
        $scope.isLogged = identity.isLogged();
        $scope.isAdmin = identity.isAdmin();
    });

    teacherService.getTeacherDetails({id:$routeParams.id,qrcode:$routeParams.qrcode})
        .then(function(data){
            console.log(data);
            $scope.teacher = data;
        },function(err){
            errorHandler.handle(err);
        });

    var qrcode = $routeParams.qrcode || 'frompc';
    teacherService.getTeacherShedule({id:$routeParams.id,qrcode:qrcode})
        .then(function (data) {
            $scope.shedule = [];
            for (var i = 0; i < data.length; i++) {
                $scope.shedule.push({
                    start: data[i].StartDate,
                    end: data[i].EndDate,
                    title: "Room : " + data[i].RoomName + " - " + data[i].Message
                })
            }
            $('#calendar').fullCalendar({
                dayClick: function(date, jsEvent, view) {
                    $('#calendar')
                        .fullCalendar('gotoDate',date);
                    $('#calendar')
                        .fullCalendar('changeView','agendaDay');
                },
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,basicWeek, agendaDay',
                    ignoreTimezone: false
                },
                events:$scope.shedule,
                timeFormat: 'H(:mm)'
            });
        },function(err){
            errorHandler.handle(err);
        });

    $scope.subscribe = function (teacherId) {
        var user = identity.getUser();
        usersService.subscribeUser(teacherId, user.token)
            .then(function (data) {
                notifier.success(data);
            },function(err){
                errorHandler.handle(err);
            });
    }

    $scope.$on('$viewContentLoaded', function () {
        moveScrollToContent();
    });
}]);