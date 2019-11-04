app.controller('signupController', function ($scope, $location, $timeout, userService) {

    $scope.user = {};

    $scope.savedSuccessfully = false;
    $scope.message = "";
    $scope.disableBtn = false;

    $scope.createUser = function () {
        $scope.message = "";
        $scope.disableBtn = true;


        if ($scope.user.password != $scope.user.confirmation) {
            $scope.message = "Password and confirmation are not the same value.";
            $scope.savedSuccessfully = false;
            $scope.disableBtn = false;
            return;
        }

        userService
            .createUser($scope.user)
            .then(function (response) {

                if (response.data.length != 0) {
                    $scope.savedSuccessfully = false;
                    $scope.message = "Failed to register user due to:\n" + response.data.join(' ');

                    $scope.disableBtn = false;
                }
                else {
                    $scope.savedSuccessfully = true;
                    $scope.message = "User has been registered successfully. You will be redirected to login form.";
                    movetoLogin();
                }
            }, function (response) {
                var errors = [];
                for (var key in response.data.modelState) {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
                $scope.message = "Failed to register user due to:\n" + errors.join(' ');
                $scope.disableBtn = false;
            });
    }

    var movetoLogin = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 3000);
    }

});