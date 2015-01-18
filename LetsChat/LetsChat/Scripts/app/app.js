/// <reference path="../angular.js" />
var chatApp = angular.module('chatApp', ['ngRoute']);

chatApp.config(function ($routeProvider) {
    $routeProvider.when('/login', {
        controller: 'loginController',
        templateUrl: '/SPAView/login.html'
    }).
    when('/home', {
        controller: 'homeController',
        templateUrl: '/SPAView/home.html'
    }).otherwise({ redirectTo: '/login' });
}).run(function ($rootScope, $location) {
    $rootScope.$on('$routeChangeError', function (event, current, previous, rejection) {
        console.log('Failed to change route\n Error:' + rejection);
    });

    $rootScope.$on('$routeChangeStart', function (event, current, previous, rejection) {
        if (current.originalPath == '/home' && (!$rootScope.username || $rootScope.username == null)) {
            $location.path('/login');
        }
        else if (current.originalPath == '/login' && $rootScope.username && $rootScope.username != null) {
            $location.path('/home');
        }
    })
});


chatApp.value('ApiPath', 'http://localhost:2090/');


