(function (){
    angular.module("Registration").controller("RoleController", function () {
        var self = this;
        self.roles = [
            'Jury',
            'Teacher',
            'Learner'
        ]
        self.userRole = self.roles[0];
        self.name = null;
        self.surname = null;

        self.nextStep = nextStep;

        function nextStep(){
            alert('nigga');
        }
    });
})();