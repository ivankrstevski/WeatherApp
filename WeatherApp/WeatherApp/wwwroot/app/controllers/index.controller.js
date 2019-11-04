app.controller('indexController', function ($scope, $location, userService) {

    $scope.logOut = function () {
        userService.logOut();
        $location.path('/');
    }

    $scope.authentication = userService.authentication;
});