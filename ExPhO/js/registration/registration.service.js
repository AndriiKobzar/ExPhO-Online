(function () {
    angular.module("Registration").service("RegistrationService", ["$http",function ($http) {
        var info = {};
        function addInfo(newinfo) {
            info = angular.merge(info, newinfo);
        }
        function register() {
            $http.post();
        }
        return {
            addInfo: addInfo,
            register: register
        }
    }])
})();