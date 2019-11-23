app.controller('signupController', function ($scope, $location, $timeout, userService) {

    $scope.user = {};

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.createUser = function () {
        $scope.message = "";

        $('#loadingModal').modal({ backdrop: 'static', keyboard: false });

        if ($scope.user.password != $scope.user.confirmation) {
            $scope.message = "Password and confirmation are not the same value.";
            $scope.savedSuccessfully = false;
            return;
        }

        userService
            .createUser($scope.user)
            .then(function (response) {

                if (response.data.length != 0) {
                    $scope.savedSuccessfully = false;
                    $scope.message = "Failed to register user due to:\n" + response.data.join(' ');

                    $('#loadingModal').modal('hide');
                }
                else {
                    $scope.savedSuccessfully = true;
                    $scope.message = "User has been registered successfully." +
                        "You will be redirected to login form.";
                    movetoLogin();
                }
            }, function (response) {
                var errors = [];

                $scope.message = "Failed to register user \n";

                if (response.data != null) {

                    console.log(response);

                    for (var key in response.data.modelState) {
                        for (var i = 0; i < response.data.modelState[key].length; i++) {
                            errors.push(response.data.modelState[key][i]);
                        }
                    }
                }

                if (errors.length != 0) {
                    $scope.message += 'due to:' + errors.join(' ');
                }

                $('#loadingModal').modal('hide');
            });
    }

    var movetoLogin = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 3000);
    }

});