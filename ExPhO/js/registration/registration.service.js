(function () {
    angular.module("Registration").service("RegistrationService", ["$http",function ($http) {
        var info = null;
        function addInfo(newinfo) {
            if (!info) {
                info = {};
            }
            info = angular.merge(info, newinfo);
            console.log("new info:"+JSON.stringify(info));
        }
        function getInfo(){
            return info;
        }
        function register() {
            $http.post("/Account/Register",info);
        }
        function getSchools() {
            $http.get("/api/schools/all").then(function (schools) {
                return schools;
            });
        }
        return {
            addInfo: addInfo,
            register: register,
            getInfo: getInfo,
            getSchools: getSchools
        }
    }])
})();