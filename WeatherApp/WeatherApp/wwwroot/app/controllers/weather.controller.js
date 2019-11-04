app.controller('weatherController', function ($scope, $q, weatherService) {

    $scope.weatherReq = {};
    $scope.disableBtn = false;
    $scope.message = "";

    $scope.getWeather = function () {
        $scope.message = "";

        if ($scope.weatherReq.start > $scope.weatherReq.end) {
            $scope.message = "'From date' cannot be lesser that 'To date'.";
            return;
        }

        $scope.disableBtn = true;

        var deferred = $q.defer();

        weatherService
            .getWeather($scope.weatherReq)
            .then(function (result) {
                deferred.resolve(result)

                if (result.errorMessage != "") {
                    var json = JSON.parse(result.errorMessage);
                    $scope.message = json.message;
                }
                else {
                    $scope.weatherResp = result.data;
                }

                $scope.disableBtn = false;
            }, function (error) {
                $scope.disableBtn = false;
            });
    }
});