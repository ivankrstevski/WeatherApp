app.controller('loginController', function ($scope, $q, $location, userService) {

    $scope.userData = {};

    $scope.message = "";
    $scope.disableBtn = false;

    $scope.loginUser = function () {
        $scope.message = "";
        $scope.disableBtn = true;

        userService
            .loginUser($scope.userData)
            .then(function (result) {
                $location.path('/weather');
            }, function (error) {
                if (error.error_description == "") {
                    $scope.message = "Some error has occured, please try again.";
                }
                else {
                    $scope.message = error.data.error_description;
                }

                $scope.disableBtn = false;
            });
    }

});