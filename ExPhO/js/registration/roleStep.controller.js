(function (){
    angular.module("Registration").controller("RoleController", function (RegistrationService, $state) {
        var self = this;
        self.roles = [
            {
                id:1,
                name: 'ROLES.JURY'
            },
            {
                id:2,
                name: 'ROLES.TEACHER'
            },
            {
                id:3,
                name: 'ROLES.LEARNER'
            }
        ]
        self.userRole = self.roles[0];
        self.nextStep = nextStep;

        function nextStep(){
            RegistrationService.addInfo({ role: self.userRole.id });
            $state.go("info");
        }
    });
})();