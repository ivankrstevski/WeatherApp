app.factory("userService", function ($http, $q, localStorageService) {

    var userServiceFactory = {};
    var baseAdress = 'http://localhost:55929/';

    var _authentication = {
        isAuth: false,
        userName: ""
    };
    
    var createUser = function (data) {
        var deferred = $q.defer();

        $http({
            method: 'POST',
            url: baseAdress + 'api/users',
            data: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(function (result) {
                deferred.resolve(result)
        }, function (error) {
                deferred.reject(error);
        });

        return deferred.promise;
    }

    var loginUser = function (data) {
        var loginData = "grant_type=password&username="
            + data.userName + "&password=" + data.password;

        var deferred = $q.defer();

        $http({
            method: 'POST',
            url: baseAdress + 'token',
            data: loginData,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        }).then(function (response) {
            localStorageService.set('authorizationData',
                {
                    token: response.data.access_token,
                    userName: data.userName
                });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response)
        }, function (error) {
            deferred.reject(error);
        });

        return deferred.promise;
    }

    var getAuthData = function () {
        var authData = localStorageService.get('authorizationData');

        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }
    }

    var _logOut = function () {
        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
    };

    var isAuthenticated = function () {
        return _authentication.isAuth;    
    }

    userServiceFactory.createUser = createUser;
    userServiceFactory.loginUser = loginUser;
    userServiceFactory.getAuthData = getAuthData;
    userServiceFactory.logOut = _logOut;
    userServiceFactory.authentication = _authentication;
    userServiceFactory.isAuthenticated = isAuthenticated;

    return userServiceFactory;
});