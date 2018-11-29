

var clientModule = angular.module('clientModule', [
    'ui.router',
    'ui.bootstrap'
    , 'ui.bootstrap.tpls'
    , 'ui.bootstrap.modal'

]);

// angular.module('clientModule')
clientModule.config(['$windowProvider', '$stateProvider', '$urlRouterProvider', '$httpProvider', '$resourceProvider',
function ($windowProvider, $stateProvider, $urlRouterProvider, $httpProvider, $resourceProvider) {
    var window = $windowProvider.$get('$window');
    //routing
    var hostname = window.location.hostname;
    var port = window.location.port;
    var rootUrl = 'http://' + hostname + ':' + port;

    $stateProvider.state('elevator',
    {
        
        url: '/client/elevators',
        templateUrl: rootUrl + '/app/views/client/elevator.html',
        controller: 'elevatorController'
    });

    $stateProvider.state('airCondition',
    {
        url: '/client/airConditions',
        templateUrl: rootUrl + '/app/views/client/airCondition.html',
        controller: 'airConditionController'
    });

    $stateProvider.state('projectClient',
      {
          url: '/client/projectClients',
          templateUrl: rootUrl + '/app/views/client/projectClient.html',
          controller: 'projectClientController'
      });

    $stateProvider.state('contact',
      {
          url: '/client/contact',
          templateUrl: rootUrl + '/app/views/client/contact.html',
          controller: 'contactController'
      });

    $stateProvider.state('newClient',
    {
        url: '/client/newClients',
        templateUrl: rootUrl + '/app/views/client/newClient.html',
        controller: 'newClientController'
    });

    $stateProvider.state('service',
    {
        url: '/client/services',
        templateUrl: rootUrl + '/app/views/client/service.html',
        controller: 'serviceController'
    });

}]);


clientModule.factory('clientSerive', [
   '$resource', '$http', '$window', '$cacheFactory', function ($resource, $http, $window, $cacheFactory) {

       var hostname = window.location.hostname;
       var port = window.location.port;
       var rootUrl = 'http://' + hostname + ':' + port;

       var result = {

       };

       result.buildUrl = function (module, action) {
           return rootUrl + '/app/views/' + module + '/' + action + '.html';
       }

       //var cacheData = $cacheFactory('tempData');
       
       
       //function inItData() {
       //    cacheData.put('typeProductList', function() {
       //        return $resource(rootUrl + '/api/TypeProduct/GetAll', {
       //            query: {
       //                method: 'GET',
       //                isArray: true
       //            }
       //        });
       //    });
       //}

       //inItData();

       //result.cacheData = cacheData;
       //console.log(cacheData);
       return result;

   }
]);



clientModule.factory('clientServiceHelper', ['$http', '$window', function ($http, $window) {
    return function (input) {
        var output = input + getData.Today().toString();
        return output;
    };
}]);
