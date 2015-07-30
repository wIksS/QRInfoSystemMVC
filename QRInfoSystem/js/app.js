'use strict';

var app = angular.module('QRInfoApp', ['ngRoute'])
    .config(['$routeProvider', function ($routeProvider)
    {
        $routeProvider.
            when('/', {
                templateUrl: 'home/home',
                controller: 'LoginCtrl'
            }).
            when('/Content/Login', {
                templateUrl: 'home/home',
                controller: 'LoginCtrl'
            }).
            when('/Content/teacher/update', {
                templateUrl: 'teacher/TeacherRegister',
                controller: 'RegisterTeacherCtrl'
            }).
            when('/Content/teacher/schedule', {
                templateUrl: 'teacher/schedule',
                controller: 'SheduleCtrl'
            }).
            when('/teachers', {
                templateUrl: 'home/home',
                controller: 'LoginCtrl'
            }).
            when('/Content/teachers/:id', {
                templateUrl: 'teacher/teacherdetails',
                controller: 'TeacherDetailsCtrl'
            }).
            when('/Content/teachers/:id/:qrcode', {
                templateUrl: 'teacher/teacherdetails',
                controller: 'TeacherDetailsCtrl'
            }).
            when('/Content/register', {
                templateUrl: 'user/register',
                controller: 'RegisterCtrl'
            }).
            when('/Content/Admin/QRCodes', {
                templateUrl: 'administration/teachersCodes',
                controller: 'LoginCtrl'
            }).
            when('/Content/Admin/Users', {
                templateUrl: 'administration/users',
                controller: 'UsersCtrl'
            }).
            when('/Content/Admin', {
                templateUrl: 'administration/adminpanel',
                controller: 'LoginCtrl'
            }).
            when('/Content/Excel/:id', {
                templateUrl: 'Excel',
                controller: 'SheduleCtrl'
            }).
            when('/Content/UploadImage/:id', {
                templateUrl: 'Teacher/uploadImage',
                controller: 'RegisterTeacherCtrl'
            })
    }])
    .value('toastr', toastr)
    .constant('baseUrl', 'http://qrinformation.apphb.com/');//'http://qrinformation.apphb.com');//http://qrinfo.apphb.com');//'http://localhost:1763');//'http://localhost:6364');//'http://QRInfoSystem.Web.Web.Web.Webserver.apphb.com/');
