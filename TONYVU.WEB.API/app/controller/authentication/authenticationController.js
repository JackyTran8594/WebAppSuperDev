var authenticationService = authenticationModule.factory('authenticationService', ['$http', '$window', 'configService', '$q', 'localStorageService', function ($http, $window, configService, $q, localStorageService) {

    var serviceAuthentication = configService.urlApiService;

    var authServiceFactory = {};

    var authentication = {
        isAuth: false,
        userName: ""
    }

    var logOut = function () {

        localStorageService.remove('authorizationData');
        authentication.isAuth = false;
        authentication.userName = "";
    }

    var saveRegistration = function (registration) {
        logOut();
        return $http.post(serviceAuthentication + '/...', registration).then(function (response) {
            return response;
        });
    }


    var login = function (userData) {
        var data = "grant_type=password&username=" + userData.userName + "&password=" + userData.password;
        console.log(data);
        var deferred = $q.defer();

        $http.post(serviceAuthentication + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {
            console.log(response);
            localStorageService.set('authorizationData', { token: response.access_token, username: userData.userName });
            authentication.isAuth = true;
            authentication.userName = userData.userName;
            deferred.resolve(response);
        }, function (error) {
            console.log();
            logOut();
            deferred.reject(error);
        });

        return deferred.promise;
    }


    var fillAuthData = function () {
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            authentication.isAuth = true;
            authentication.userName = authData.userName;
        }
        return authData;
    }


    authServiceFactory.savaRegistration = saveRegistration;
    authServiceFactory.login = login;
    authServiceFactory.logOut = logOut;
    authServiceFactory.fillAuthData = fillAuthData;
    authServiceFactory.authentication = authentication;

    return authServiceFactory;
}]);

var authenticationController = authenticationModule.controller('authenticationController', []);

var signUpController = authenticationModule.controller('signUpController', [
    '$scope', '$location', 'configService', '$timeout', 'authenticationService', function ($scope, $location, configService, $timeout, authenticationService) {

        $scope.saveSuccessfull = false;
        $scope.message = "";

        $scope.registration =
        {
            userName: "",
            passWord: "",
            confirmPass: ""
        }

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/login');
            }, 2000);
        }

        $scope.signUp = function () {
            authenticationService.savaRegistration($scope.registration).then(function (response) {
                $scope.saveSuccessfull = true;
                $scope.message = "User has been registered successfully, you will be redirected to login page in 2 seconds";
                startTimer();
            }, function (error) {
                var errors = [];
                angular.forEach(response.data.modelState, function (value, key) {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
                );
                $scope.message = "Failed to register user due to" + errors.join('');
            });
        }
    }
]);

var logInController = authenticationModule.controller('logInController', [
    '$scope', '$rootScope', '$state', '$http', '$location', 'configService', '$timeout', 'authenticationService', 'localStorageService', 'isLogIn', function ($scope, $rootScope, $state, $http, $location, configService, $timeout, authenticationService, localStorageService, isLogIn) {

        $scope.userData = {
            userName: "",
            password: ""
        }
        $scope.message = "";
        //var tokenInfo = localStorageService.get('authorizationData');
        var tokenInfo = authenticationService.fillAuthData();
        //console.log(tokenInfo);
        //console.log($rootScope);
        //console.log(isLogIn);
        $rootScope.isLogIn = isLogIn;
        $scope.login = function () {
            authenticationService.login($scope.userData).then(function (response) {

                $state.go('home');
                console.log("successful!!!");
            }, function (error) {
                $scope.message = error.error_description;
                console.log($scope.message);
            });
        }

    }
]);