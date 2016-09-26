(function () {
    angular.module("Registration", ["ui.router"]).
    config(function($stateProvider, $urlRouteProvider){
        $urlRouterProvider.otherwise('/role');
        $stateProvider.
            state('role', {
                url:'/role',
                templateUrl:'/html/registration/role.html',
                controller:'roleController'
            }).
            state('info', {
                url:'/info',
                templateUrl:'/html/registration/info.html',
                controller: 'infoController'
            })
    }).
    run();
})();