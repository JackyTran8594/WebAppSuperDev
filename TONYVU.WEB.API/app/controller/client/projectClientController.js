clientModule.factory('projectClientService', ['$resource', '$http', '$window', '$q', 'configService',
function ($resource, $http, $window, $q, configService) {
    var url = configService.urlApiService;
    var urlService = url + '/api/projectClients';
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

var projectClientController = clientModule.controller('projectClientController', ['$scope', '$log', 'projectClientService', '$uibModal', 'clientSerive', '$http',
    '$window','configService',
    function ($scope, $log, projectClientService, $uibModal, clientSerive, $http, $window, configService) {

        $scope.config = configService;
        $scope.animationsEnabled = true;

        function loadData() {
            $scope.filtered = '';
            projectClientService.allData(JSON.stringify($scope.filtered),
                function (response) {
                    console.log(response);
                    if (response.status) {
                        $scope.data = response.data;
                        console.log($scope.data);
                    };
                });
        }

        $scope.add = function () {
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                templateUrl: clientSerive.buildUrl('projectClient', 'add'),
                controller: 'projectClientCreateController',
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
                templateUrl: clientSerive.buildUrl('projectClient', 'edit'),
                controller: 'projectClientEditController',
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
                templateUrl: clientSerive.buildUrl('projectClient', 'detail'),
                controller: 'projectClientDetailController',
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
                templateUrl: clientSerive.buildUrl('shared', 'delete'),
                controller: 'projectClientDeleteController',
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


clientModule.controller('projectClientCreateController', [
    '$scope', '$log', '$window', 'projectClientService', 'configService', '$uibModalInstance',
    function ($scope, $log, $window, projectClientService, configService, $uibModalInstance) {
        $scope.target = {};
        $scope.config = configService;

        $scope.save = function () {
            $scope.target.contents = CKEDITOR.instances.ckeditor.getData();
            projectClientService.postData(JSON.stringify($scope.target), function (response) {
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

clientModule.controller('projectClientEditController', [
    '$scope', '$log', '$window', 'projectClientService', 'configService', '$uibModalInstance', 'targetData',
    function ($scope, $log, $window, projectClientService, configService, $uibModalInstance, targetData) {
        $scope.target = targetData;
        $scope.config = configService;

        console.log($scope.target);

        $scope.save = function () {
            $scope.target.contents = CKEDITOR.instances.ckeditor.getData();
            projectClientService.update($scope.target, function (response) {
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

clientModule.controller('projectClientDetailController', [
    '$scope', '$log', '$window', 'projectClientService', 'configService', '$uibModalInstance', 'targetData',
    function ($scope, $log, $window, projectClientService, configService, $uibModalInstance, targetData) {
        console.log(targetData);

        $scope.config = configService;

        $scope.target = targetData;

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
    }
]);

clientModule.controller('projectClientDeleteController', [
    '$scope', '$log', '$window', 'projectClientService', 'configService', 'targetData', '$uibModalInstance',
    function ($scope, $log, $window, projectClientService, configService, targetData, $uibModalInstance) {
        $scope.target = targetData;
        $scope.config = configService;

        var id = $scope.target.id;

        $scope.remove = function () {
            projectClientService.deleteItem(id, function (response) {
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