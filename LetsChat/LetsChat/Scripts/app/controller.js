/// <reference path="app.js" />
var controllers = {};

controllers.loginController = function ($scope, $rootScope, $location, UserFactory) {
    $rootScope.login = function () {
        if (!$scope.username) {
            alert('Please enter name.');
            return;
        }

        UserFactory.login($scope.username).success(function (data) {
            $rootScope.username = $scope.username;
            $rootScope.userid = data;
            $location.path('/home');
        }).error(function (data) {
            if (data && data.Message) {
                alert(data.Message);
            }
            else {
                alert('Sorry, error in application. Please try again.');
            }
        });
    };
};

controllers.homeController = function ($scope, MessageFactory, UserFactory, $rootScope, $location) {

    $scope.messagelist = [];
    $scope.message = '';
    $scope.messagefocus = false;
    $scope.users = [];
    var chat = $.connection.groupChat;

    function fillLastMessage() {
        MessageFactory.getLastMessages().success(function (data) {
            angular.forEach(data, function (item) {
                $scope.messagelist.push({ name: item.name, message: item.message });
            });
        }).error(function (data) { });
    }


    function fillUsers() {
        UserFactory.getOnlineUsers($scope.userid).success(function (data) {
            angular.forEach(data, function (user) {
                $scope.users.push(user);
            });
        }).error(function (data) {
        });
    }

    function initialize() {

        chat.client.getMessage = function (name, message) {
            $scope.$apply(function () {
                $scope.messagelist.push({ name: name, message: message });
            });
        };

        chat.client.userLeft = function (name) {
            var removeIndex = getUserIndex(name);

            if (removeIndex != -1) {
                $scope.$apply(function () {
                    $scope.users.splice(removeIndex, 1);
                });
            }
        };

        chat.client.userAdded = function (name) {
            if ($rootScope.username == name) {
                return;
            }

            var userIndex = getUserIndex(name);

            if (userIndex == -1) {
                $scope.$apply(function () {
                    $scope.users.push(name);
                });
            }
        };

        $.connection.hub.start().done(function () {
            chat.server.login($scope.username);
        });

        fillLastMessage();
        fillUsers();
    }

    initialize();

    $scope.checkKeyDown = function (event) {
        if (event.keyCode == 13 && event.shiftKey == 0) {
            chat.server.sendMessage($scope.userid, $scope.username, $scope.message);
            $scope.messagefocus = true;
            $scope.message = '';

            event.preventDefault();
        }
    };

    $scope.logout = function () {
        chat.server.logOut($scope.username, $scope.userid);
        $rootScope.username = null;
        $rootScope.userid = null;
        $location.path('/login');
    };

    function getUserIndex(name) {
        var removeIndex = -1;

        angular.forEach($scope.users, function (item, index) {
            if (item == name) {
                removeIndex = index;
            }
        });

        return removeIndex;
    }
};

chatApp.controller(controllers);