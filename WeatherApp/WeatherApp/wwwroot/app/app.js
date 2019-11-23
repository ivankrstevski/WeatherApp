var app = angular.module("weatherApp", ["ngRoute", "LocalStorageModule"]);

app.run(["$rootScope", "$location", "userService", function ($rootScope, $location, userService) {
    userService.getAuthData();

    $rootScope.$on("$routeChangeError", function (rejection) {
        if (rejection == true) {
            $location.path("/");
        }
    });
}]);

app.config(function ($httpProvider, $logProvider) {
    $httpProvider.interceptors.push('authorizationService');
    $logProvider.debugEnabled(false);
});