app.factory("weatherService", function ($http, $q) {

    return {
        getWeather: function (data) {
            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: 'http://localhost:55929/api/weather',
                params: data
            }).then(function (result) {
                deferred.resolve(result.data)
            }, function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        }
    }
});