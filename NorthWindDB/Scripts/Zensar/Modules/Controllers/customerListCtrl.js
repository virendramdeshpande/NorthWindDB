(function () {
    function customerListCtrl($scope, customerService) {
        $scope.GetList = function () {

            customerService.GetCustomerList().then(function (data) {

                $scope.List = data;

            });

        }
    };
     customerListCtrl.$inject = ['$scope', 'customerService'];
    angular.module('admin').controller('customerListCtrl', customerListCtrl);
   
   


})();