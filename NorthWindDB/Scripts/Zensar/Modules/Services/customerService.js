(function () {
angular.module('admin').service('customerService', customerService)
customerService.$inject = ['$http', '$q'];

function customerService($http, $q) {
    
        this.GetCustomerList = function ()
        {
            var defered = $q.defer();

            $http.get('/api/customerInfo/GetList').then(
               function (response) {
                   debugger;
                   defered.resolve(response.data);
               }, function (error) {
                   defered.reject(error);
               });
            return defered.promise;
        };

        this.GetCustomerDetails = function ()
        {
            var defered = $q.defer();

            $http.get('/api/customerInfo/GetList').then(
                function (response) {
                    defered.resolve(response);
                }, function (error) {
                    defered.reject(error);
                });
            return defered.promise;
        };
        this.SaveCustomerDetails = function ()
        {
            var defered = $q.defer();

        };
        this.DeleteCustomer = function ()
        {
            var defered = $q.defer();
        };

    }

})();