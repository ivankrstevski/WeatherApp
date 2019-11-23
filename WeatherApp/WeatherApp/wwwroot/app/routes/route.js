app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "../../app/views/welcome/welcome.html"
        })
        .when("/login", {
            templateUrl: "../../app/views/users/login.html",
            controller: "loginController",
            resolve: {
                access: ["userService", "$q", function (userService, $q) {
                    if (userService.isAuthenticated()) {
                        return $q.reject(true);
                    }
                }],
            }
        })
        .when("/signup", {
            templateUrl: "../../app/views/users/signup.html",
            controller: "signupController",
            resolve: {
                access: ["userService", "$q", function (userService, $q) {
                    if (userService.isAuthenticated()) {
                        return $q.reject(true);
                    }
                }],
            }
        })
        .when("/weather", {
            templateUrl: "../../app/views/weather/weather.html",
            controller: "weatherController",
            resolve: {
                access: ["userService", "$q", function (userService, $q) {
                    if (!userService.isAuthenticated())
                    {
                        return $q.reject(true);
                    }
                }],
            }
        })
});