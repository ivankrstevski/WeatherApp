app.controller('indexController', function ($scope, $location, userService) {

    $scope.logOut = function () {
        userService.logOut();
        $location.path('/');
    }

    $scope.isActivePage = function (path) {
        return ($location.path().substr(0, path.length) === path) ? true : false;
    }

    $scope.authentication = userService.authentication;
});