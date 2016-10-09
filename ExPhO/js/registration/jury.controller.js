(function(){
    angular.module("Registration").controller("JuryRegistration", function (RegistrationService, $state) {
        var self = this;
        self.registrationInfo = {
            name: "",
            surname: "",
            phone: "",
            institution:""
        };
        self.register = register;
        activate();

        function activate() {
            if (RegistrationService.getInfo() == null) {
                $state.go("role");
            }
        }
        function register() {
            RegistrationService.addInfo(self.registrationInfo);
            RegistrationService.register();
        }
    });
})();