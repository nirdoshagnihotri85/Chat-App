/// <reference path="app.js" />
chatApp.factory('UserFactory', function ($http, ApiPath) {
    var factory = {};
    factory.login = function (username) {
        return $http.post(ApiPath + 'api/User?username=' + username)
    }

    factory.getOnlineUsers = function (userId) {
        return $http.get(ApiPath + 'api/User/' + userId)
    }
    return factory;
});

chatApp.factory('MessageFactory', function ($http, ApiPath) {
    var factory = {};
    factory.getLastMessages = function () {
        return $http.get(ApiPath + 'api/Message')
    }

    return factory;
});