(function(){
    angular.module("Registration").controller("TeacherRegistration", function (RegistrationService, $state) {
        var self = this;
        activate();

        function activate() {
            if (RegistrationService.getInfo() == null) {
                $state.go("role");
            }
        }
    });
})();