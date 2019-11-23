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

    var getUserData = function () {
        var locaStorage = localStorageService.get('authorizationData');

        var userName = locaStorage['userName'];

        var address = baseAdress + 'api/users?userName=' + userName;

        var deferred = $q.defer();

        $http({
            method: 'GET',
            url: address,
        }).then(function (response) {
            var data = response.data.data;

            var fullName = data.name + ' ' + data.surname;

            localStorageService.set('authorizationData',
                {
                    token: locaStorage['token'],
                    userName: locaStorage['userName'],
                    fullName: fullName
                });

            _authentication.fullName = fullName;

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
            _authentication.fullName = authData.fullName;
        }
    }

    var _logOut = function () {
        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
        _authentication.fullName = "";
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
    userServiceFactory.getUserData = getUserData;

    return userServiceFactory;
});