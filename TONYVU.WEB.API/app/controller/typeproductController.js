sysModule.factory('typeProductService', ['$resource', '$http', '$window', '$q', 'configService',
function ($resource, $http, $window, $q, configService) {

    var url = configService.urlApiService;
    var urlService = url + '/api/typeProduct';
    var sum = function (input, array) {
        var total = 0;
        angular.forEach(array, function (value, index) {
            total += value[input];
            return total;
        });
    }

    var result = {
        calculator: sum,
        allData: function (data, successCallback) {
            $http.post(urlService + '/PagingRecord').then(successCallback);
        },
        postData: function (data, successCallback) {
            $http.post(urlService + '/Post', data).then(successCallback);
        },
        update: function (params, successCallback) {
            $http.put(urlService + '/Put/' + params.id, params).then(successCallback);
        },
        deleteItem: function (id, successCallback) {
            $http.delete(urlService + '/Delete/' + id).then(successCallback);
        }
    };
    return result;
}]);

var typeProductController = sysModule.controller('typeProductController', ['$scope', '$log', 'typeProductService', '$uibModal', 'sysSerive', '$http',
    '$window', 'configService',
    function ($scope, $log, typeProductService, $uibModal, sysSerive, $http, $window, configService) {
        $scope.animationsEnabled = true;

        $scope.config = configService;

        $scope.paged = angular.copy(configService.pageDefault);

        function loadData() {
            var postData = { page: $scope.paged };
            typeProductService.allData(JSON.stringify(postData),
                function (response) {
                    console.log(response);
                    console.log($scope.paged);
                    if (response.status) {
                        $scope.data = response.data.results;
                        angular.extend($scope.paged, response.data);
                        console.log($scope.paged);
                    };
                });
        }

        $scope.add = function () {
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                templateUrl: sysSerive.buildUrl('typeProduct', 'add'),
                controller: 'typeProductCreateController',
                size: 'lg'
            });
            modalInstance.result.then(function (selectedItem) {
                loadData();
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }

        $scope.edit = function (item) {
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                templateUrl: sysSerive.buildUrl('typeProduct', 'edit'),
                controller: 'typeProductEditController',
                size: 'lg',
                resolve: {
                    targetData: function () {
                        return item;
                    }
                }
            });
            modalInstance.result.then(function (seletedItem) {
                loadData();
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }

        $scope.detail = function (item) {
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                templateUrl: sysSerive.buildUrl('typeProduct', 'detail'),
                controller: 'typeProductDetailController',
                size: 'lg',
                resolve: {
                    targetData: function () {
                        return item;
                    }
                }
            });
            modalInstance.result.catch(function (error) {
                console.log("error" + error);
            });
        }

        $scope.delete = function (item) {
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                templateUrl: sysSerive.buildUrl('shared', 'delete'),
                controller: 'typeProductDeleteController',
                size: 'lg',
                resolve: {
                    targetData: function () {
                        return item;
                    }
                }
            });
            modalInstance.result.then(function (updateData) {
                loadData();
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };

        loadData();
    }]);


sysModule.controller('typeProductCreateController', [
    '$scope', '$log', '$window', 'typeProductService', 'configService', '$uibModalInstance',
    function ($scope, $log, $window, typeProductService, configService, $uibModalInstance) {
        $scope.target = {};
        $scope.config = configService;


        $scope.save = function () {
            typeProductService.postData(JSON.stringify($scope.target), function (response) {
                if (response.status) {
                    console.log("Successful!!!");
                    $uibModalInstance.close($scope.target);
                }
            });
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
    }
]);

sysModule.controller('typeProductEditController', [
    '$scope', '$log', '$window', 'typeProductService', 'configService', '$uibModalInstance', 'targetData',
    function ($scope, $log, $window, typeProductService, configService, $uibModalInstance, targetData) {
        $scope.target = targetData;
        $scope.config = configService;

        console.log($scope.target);

        $scope.save = function () {
            typeProductService.update($scope.target, function (response) {
                console.log(response);
                if (response.status) {
                    console.log(response);
                    //$scope.target.clear();
                    console.log("Successful!!!");
                    $uibModalInstance.close($scope.target);
                }
            });
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
    }
]);

sysModule.controller('typeProductDetailController', [
    '$scope', '$log', '$window', 'typeProductService', 'configService', '$uibModalInstance', 'targetData',
    function ($scope, $log, $window, typeProductService, configService, $uibModalInstance, targetData) {
        console.log(targetData);

        $scope.config = configService;

        $scope.target = targetData;

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
    }
]);

sysModule.controller('typeProductDeleteController', [
    '$scope', '$log', '$window', 'typeProductService', 'configService', 'targetData', '$uibModalInstance',
    function ($scope, $log, $window, typeProductService, configService, targetData, $uibModalInstance) {
        $scope.target = targetData;
        $scope.config = configService;

        var id = $scope.target.id;

        $scope.remove = function () {
            typeProductService.deleteItem(id, function (response) {
                if (response.status) {
                    console.log(response);
                    $uibModalInstance.close();
                };
            });
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
    }
]);