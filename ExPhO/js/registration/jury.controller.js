(function(){
    angular.module("Registration").controller("JuryRegistration", function (RegistrationService, $state) {
        var self = this;
        self.registrationModel = {};

        activate();

        function activate() {
            if (RegistrationService.getInfo() == null) {
                $state.go("role");
            }
        }
        function register() {
            RegistrationService.addInfo(self.registrationModel);
            RegistrationService.register();
        }
    });
})();