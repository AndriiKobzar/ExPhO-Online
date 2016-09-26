(function (){
    angular.module("Registration").controller("RoleController", function () {
        var self = this;
        self.roles = {
            JURY: 'Jury',
            TEACHER: 'Teacher',
            LEARNER:'Learner'
        }
        self.userRole = null;
        self.name = null;
        self.surname = null;

        self.nextStep = nextStep;

        function nextStep(){
            
        }
    });
})();