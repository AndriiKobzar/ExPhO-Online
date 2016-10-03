(function () {
    angular.module("Registration").controller("InfoController", function (RegistrationService, $state) {
        var self = this;
        self.registerInfo={
            userEmail:"",
            password:"",
            confirmPassword:"",
        };
        self.next=next;

        function next() {
            RegistrationService.addInfo(self.registerInfo);
            switch (RegistrationService.getInfo().role) {
                case 1:
                    $state.go("jury");
                    break;
                case 2:
                    $state.go("teacher");
                    break;
                case 3:
                    $state.go("learner");
                    break;
                default:
                    break;
            }
        }
    });
})();