app.controller('loginController', function ($scope, $location, userService) {

    $scope.userData = {};

    $scope.message = "";

    $scope.loginUser = function () {
        $scope.message = "";

        $('#loadingModal').modal({ backdrop: 'static', keyboard: false });

        userService
            .loginUser($scope.userData)
            .then(function (result) {

                userService
                    .getUserData()
                    .then(function () {
                        $location.path('/weather');
                    });

            }, function (error) {

                if (error.data != null) {
                    if (error.error_description == "") {
                        $scope.message = "Some error has occured, please try again.";
                    }
                    else {
                        $scope.message = error.data.error_description;
                    }
                }

                else {
                    $scope.message = "Some error has occured, please try again.";
                }

                $('#loadingModal').modal('hide');
            });
    }
});