sysModule.factory('groupRoleService', ['$resource', '$http', '$window', '$q', 'configService',
function ($resource, $http, $window, $q, configService) {
    var url = configService.urlApiService;
    var urlService = url + '/api/GroupRole';
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

var groupRoleController = sysModule.controller('groupRoleController', ['$scope', '$log', 'groupRoleService', '$uibModal', 'sysSerive', '$http',
    '$window','configService',
    function ($scope, $log, groupRoleService, $uibModal, sysSerive, $http, $window, configService) {

        $scope.config = configService;
        $scope.animationsEnabled = true;

        $scope.paged = angular.copy(configService.pageDefault);

        function loadData() {
            var postData = { page: $scope.paged };
            groupRoleService.allData(JSON.stringify(postData),
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
                templateUrl: sysSerive.buildUrl('groupRole', 'add'),
                controller: 'groupRoleCreateController',
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
                templateUrl: sysSerive.buildUrl('groupRole', 'edit'),
                controller: 'groupRoleEditController',
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
                templateUrl: sysSerive.buildUrl('groupRole', 'detail'),
                controller: 'groupRoleDetailController',
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
                controller: 'groupRoleDeleteController',
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


sysModule.controller('groupRoleCreateController', [
    '$scope', '$log', '$window', 'groupRoleService', 'configService', '$uibModalInstance',
    function ($scope, $log, $window, groupRoleService, configService, $uibModalInstance) {
        $scope.target = {};
        $scope.config = configService;

        $scope.save = function () {
            groupRoleService.postData(JSON.stringify($scope.target), function (response) {
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

sysModule.controller('groupRoleEditController', [
    '$scope', '$log', '$window', 'groupRoleService', 'configService', '$uibModalInstance', 'targetData',
    function ($scope, $log, $window, groupRoleService, configService, $uibModalInstance, targetData) {
        $scope.target = targetData;
        $scope.config = configService;

        console.log($scope.target);

        $scope.save = function () {
            groupRoleService.update($scope.target, function (response) {
                console.log(response);
                if (response.status) {
                    console.log(response);
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

sysModule.controller('groupRoleDetailController', [
    '$scope', '$log', '$window', 'groupRoleService', 'configService', '$uibModalInstance', 'targetData',
    function ($scope, $log, $window, groupRoleService, configService, $uibModalInstance, targetData) {
        console.log(targetData);

        $scope.config = configService;

        $scope.target = targetData;

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
    }
]);

sysModule.controller('groupRoleDeleteController', [
    '$scope', '$log', '$window', 'groupRoleService', 'configService', 'targetData', '$uibModalInstance',
    function ($scope, $log, $window, groupRoleService, configService, targetData, $uibModalInstance) {
        $scope.target = targetData;
        $scope.config = configService;

        var id = $scope.target.id;

        $scope.remove = function () {
            groupRoleService.deleteItem(id, function (response) {
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