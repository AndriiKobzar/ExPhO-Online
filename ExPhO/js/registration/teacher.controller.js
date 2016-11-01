(function(){
    angular.module("Registration").controller("TeacherRegistration", function (RegistrationService, $state) {
        var self = this;
        self.learners = [];
        self.newLearner = { name: "", surname: "", email: "" };
        self.addLearner = addLearner;
        self.register = register;
        activate();

        function activate() {
            if (RegistrationService.getInfo() == null) {
                $state.go("role");
            }
        }

        function addLearner() {
            self.learners.push(self.newLearner);
            self.newLearner = { name: "", surname: "", email: "" };
        }

        function register() {
            RegistrationService.addInfo(self.registrationInfo);
            RegistrationService.addInfo({ learners: self.learners });
            RegistrationService.register();
        }
    });
})();