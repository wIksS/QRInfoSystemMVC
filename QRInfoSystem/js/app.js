'use strict';

var app = angular.module('QRInfoApp', ['ngRoute'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: 'home/home',
                controller: 'LoginCtrl'
            }).
            when('/teachers/:id', {
                templateUrl: 'teacher/teacherdetails',
                controller: 'TeacherDetailsCtrl'
            }).
            when('/teachers/:id/:qrcode', {
                templateUrl: 'teacher/teacherdetails',
                controller: 'TeacherDetailsCtrl'
            }).
            when('/register', {
                templateUrl: 'user/register',
                controller: 'RegisterCtrl'
            }).
            when('/Admin/QRCodes', {
                templateUrl: 'administration/teachersCodes',
                controller: 'LoginCtrl'
            }).
            when('/Admin', {
                templateUrl: 'administration/adminpanel',
                controller: 'LoginCtrl'
            })
    }])
    .value('toastr', toastr)
    .constant('baseUrl', 'http://qrinfo.apphb.com/');//'http://localhost:6364');//'http://QRInfoSystem.Web.Web.Web.Webserver.apphb.com/');
