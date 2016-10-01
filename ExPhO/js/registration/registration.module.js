(function () {
    angular.module("Registration", ["ui.router"]).
    config(config);
    function config ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/role');
        $stateProvider.
            state('role', {
                url: '/role',
                templateUrl: '/html/registration/role.html',
                controller: 'RoleController as ctrl'
            }).
            state('info', {
                url: '/info',
                templateUrl: '/html/registration/info.html',
                controller: 'InfoController'
            });
    };
})();