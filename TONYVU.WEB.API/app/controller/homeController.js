sysModule.factory('homeService', ['$resource', '$http', '$window', '$q', 'configService',
function ($resource, $http, $window, $q, configService) {
    var url = configService.urlApiService;
    var urlService = url + '/api/Areas/home';
    var sum = function (input, array) {
        var total = 0;
        angular.forEach(array, function (value, index) {
            total += value[input];
            return total;
        });
    };

    var result = {
    
    }

    return result;
}]);

var homeController = sysModule.controller('homeController', ['$scope', '$rootScope', '$log', 'homeService', '$uibModal', 'sysSerive', '$http',
    '$window', 'configService', 'isLogIn',
    function ($scope, $rootScope, $log, homeService, $uibModal, sysSerive, $http, $window, configService, isLogIn) {
        $scope.animationsEnabled = true;
        $scope.config = configService;
        $rootScope.isLogIn = isLogIn;

    }]);

