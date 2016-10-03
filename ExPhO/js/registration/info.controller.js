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
            $state.go("additionalInfo");
        }
    });
})();