sysModule
    .factory('productService', [
        '$resource', '$http', '$window', '$q', 'configService',
        function ($resource, $http, $window, $q, configService) {
            var hostname = window.location.hostname;
            var port = window.location.port;
            var url = configService.urlApiService;
            var urlService = url + '/api/Product';
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
                    $http.post(urlService + '/PagingRecord', data).then(successCallback);
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
        }
    ]);


var productController = sysModule.controller('productController', ['$scope', '$log', 'productService', '$uibModal', 'sysSerive', '$http',
    '$window', 'configService',
    function ($scope, $log, productService, $uibModal, sysSerive, $http, $window, configService) {

        $scope.config = configService;

        $scope.animationsEnabled = true;

        $scope.paged = angular.copy(configService.pageDefault);

        function loadData() {
            var postData = { page: $scope.paged };
            productService.allData(JSON.stringify(postData),
                function (response) {
                    console.log(response);
                    console.log($scope.paged);
                    if (response.status) {
                        $scope.data = response.data.results;
                        angular.extend($scope.paged, response.data);
                        //debugger;
                        //$scope.paged = response.data;
                        console.log($scope.paged);
                    };
                });
        }

        $scope.add = function () {
            var modalInstance = $uibModal.open({
                backdrop: 'static',
                templateUrl: sysSerive.buildUrl('productViews', 'add'),
                controller: 'productCreateController',
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
                templateUrl: sysSerive.buildUrl('productViews', 'edit'),
                controller: 'productEditController',
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
                templateUrl: sysSerive.buildUrl('productViews', 'detail'),
                controller: 'productDetailController',
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
                controller: 'productDeleteController',
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

        $scope.pageChanged = function () {
            loadData();
        }

    }
]);


sysModule.controller('productCreateController', [
    '$scope', '$log', '$window', 'productService', 'configService', '$uibModalInstance', '$http',
    function ($scope, $log, $window, productService, configService, $uibModalInstance, $http) {
        $scope.target = {};
        $scope.config = configService;



        function uploadProgress(e) {
            if (e.lengthComputable) {
                document.getElementById("pro").setAttribute('value', e.load);
                document.getElementById("pro").setAttribute('max', e.total);
            }
        }

        var formData = new FormData();
        $scope.getTheFiles = function ($files) {
            console.log($files);
            angular.forEach($files, function (value, key) {
                formData.append(key, value);
            });
            console.log(formData);
        }


        function uploadFiles(type) {
            $http({
                method: 'POST',
                url: 'api/HelperApi/UploadFile/' + type,
                data: formData,
                headers: {
                    'Content-Type': undefined
                },
                transformRequest: angular.identity
            }).then(function (response) {
                console.log(response);
            }, function (error) {
                console.log(error);
            });

        }

        $scope.save = function () {
            uploadFiles($scope.target.groupOfProduct);
            productService.postData(JSON.stringify($scope.target), function (response) {
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

sysModule.controller('productEditController', [
    '$scope', '$log', '$window', 'productService', 'configService', '$uibModalInstance', 'targetData',
    function ($scope, $log, $window, productService, configService, $uibModalInstance, targetData) {
        $scope.target = targetData;
        $scope.config = configService;

        console.log($scope.target);

        $scope.save = function () {
            productService.update($scope.target, function (response) {
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

sysModule.controller('productDetailController', [
    '$scope', '$log', '$window', 'productService', 'configService', '$uibModalInstance', 'targetData',
    function ($scope, $log, $window, productService, configService, $uibModalInstance, targetData) {
        console.log(targetData);

        $scope.config = configService;

        $scope.target = targetData;

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }
    }
]);

sysModule.controller('productDeleteController', [
    '$scope', '$log', '$window', 'productService', 'configService', 'targetData', '$uibModalInstance',
    function ($scope, $log, $window, productService, configService, targetData, $uibModalInstance) {
        $scope.target = targetData;
        $scope.config = configService;

        var id = $scope.target.id;

        $scope.remove = function () {
            productService.deleteItem(id, function (response) {
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