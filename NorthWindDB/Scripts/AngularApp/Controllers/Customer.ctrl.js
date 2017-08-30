function configer($routeProvider) {
    debugger;
}

configer.$inject = ['$routeProvider'];

angular.module('customer', ['ngRoute']).service("customerService", ['$http', '$q', function ($http, $q) {
    debugger;

    this.getAllCustomers = function () {
        //sss
        var deferred = $q.defer();

        $http.get("/Customer/GetAllCustomers").success(function (response) {
            deferred.resolve(response);
        
        }).error( function (errorinfo) {
            deferred.reject("failed!!!");
        });
        return deferred.promise;
    };

    this.getCustomerByCriteria = function (requestObj) {
        debugger;
        var deferred = $q.defer();
        var url = '/Customer/getCustomerByCriteria';
        $http.post(url, requestObj).success(function (response) {
            deferred.resolve(response);
        }).error(function (errorinfo) {
            deferred.reject("failed!!!");
        });

        return deferred.promise;
    };

    this.getAllCounties = function (requestObj) {
        debugger;
        var deferred = $q.defer();
        var url = '/Customer/getAllCounties';
        $http.post(url, requestObj).success(function (response) {
            deferred.resolve(response);
        }).error(function (errorinfo) {
            deferred.reject("failed!!!");
        });

        return deferred.promise;
    };

    this.getAllCitiesOfTheCity = function (name) {
        debugger;
        var deferred = $q.defer();
        var url = '/Customer/getAllCitiesOfTheCity?name=' + name;
        $http.get(url).success(function (response) {
            deferred.resolve(response);
        }).error(function (errorinfo) {
            deferred.reject("failed!!!");
        });

        return deferred.promise;
    };

    

}]).controller("customerctrl", ['$scope', 'customerService', function ($scope, customerService) {
    customerQuery = {};
    customerQuery.CompanyName = "";
    customerQuery.ContactName = "";
    customerQuery.ContactTitle = "";
    customerQuery = customerQuery;
    $scope.Cities = [];
    
    customerService.getAllCounties().then(function (data) {
        debugger;
        $scope.Coutries = data.list;
        
            
    });

    $scope.OnCountrySelection = function () {
        debugger;
        if ($scope.customerQuery.Country === null)
        {
            $scope.Cities = [];
        }
        else
        {
            customerService.getAllCitiesOfTheCity($scope.customerQuery.Country).then(function (data) {
                debugger;
                $scope.Cities = data.list;
            });
        }
        

    };
    

    $scope.fetchCustomers = function () {
        debugger;
        customerService.getCustomerByCriteria($scope.customerQuery).then(function (data) {
            debugger;
            $scope.customers = data.Customers;           
            
        });
 
        };
    
}]).config(configer);



