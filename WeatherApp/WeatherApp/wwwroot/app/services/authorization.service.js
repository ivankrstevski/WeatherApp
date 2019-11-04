﻿app.factory("authorizationService", function ($q, localStorageService) {

    var authorizationService = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');

        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {

        if (rejection.status === 401) {
            $location.path('/login');
        }
        return $q.reject(rejection);
    }

    authorizationService.request = _request;
    authorizationService.responseError = _responseError;

    return authorizationService;
});