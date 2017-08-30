angular.module('admin', ['ngRoute']).config(['$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider.when('/Customer/List', { templateUrl: "/Zensar/GetView?ViewName=CustomerList" })
                      .when('/customer/details', { templateUrl: "/Zensar/GetView?ViewName=CustomerDetails" })
                      .when('/customer/new', { templateUrl: "/Zensar/GetView?ViewName=newCustmer" })
                      .when('/customer/edit', { teplateUrl: "/Zensar/GetView?ViewName=EditCustomer" });
}])