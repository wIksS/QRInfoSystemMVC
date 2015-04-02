'use strict';

var app = angular.module('QRInfoApp', ['ngRoute'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: 'home/home',
                controller: 'LoginCtrl'
            }).
            when('/Login', {
                templateUrl: 'home/home',
                controller: 'LoginCtrl'
            }).
            when('/teacher/update', {
                templateUrl: 'teacher/TeacherRegister',
                controller: 'RegisterTeacherCtrl'
            }).
            when('/teacher/schedule', {
                templateUrl: 'teacher/schedule',
                controller: 'SheduleCtrl'
            }).
            when('/teachers', {
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
            when('/Admin/Users', {
                templateUrl: 'administration/users',
                controller: 'UsersCtrl'
            }).
            when('/Admin', {
                templateUrl: 'administration/adminpanel',
                controller: 'LoginCtrl'
            }).
            when('/Excel/:id', {
                templateUrl: 'Excel',
                controller: 'SheduleCtrl'
            }).
            when('/UploadImage/:id', {
                templateUrl: 'Teacher/uploadImage',
                controller: 'RegisterTeacherCtrl'
            })
    }])
    .value('toastr', toastr)
    .constant('baseUrl', 'http://qrinfo.apphb.com');//http://qrinfo.apphb.com');//'http://localhost:1763');//'http://localhost:6364');//'http://QRInfoSystem.Web.Web.Web.Webserver.apphb.com/');
