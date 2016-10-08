(function(){
    angular.module("Registration").controller("LearnerController", function (RegistrationService, $state) {
        activate();

        function activate() {
            if (RegistrationService.getInfo() == null) {
                $state.go("role");
            }
        }
    });
})();