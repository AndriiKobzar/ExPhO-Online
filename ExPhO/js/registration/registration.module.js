(function () {
    angular.module("Registration", ["ui.router", 'pascalprecht.translate', 'tmh.dynamicLocale']).
    config(
    function config($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/role');
        $stateProvider.
            state('role', {
                url: '/role',
                templateUrl: '/html/registration/role.html',
                controller: 'RoleController as ctrl'
            }).
            state('info', {
                url: '/info',
                templateUrl: '/html/registration/generalInfo.html',
                controller: 'InfoController'
            }).
            state('additionalInfo', {
                url: '/additionalInfo',
                templateUrl: '/html/registration/additionalInfo.html',
                controller: 'AdditionalInfoController as ctrl'
            });
    }).
    config(function ($translateProvider) {
        $translateProvider.useStaticFilesLoader({
            prefix: "/localization/registration-",
            suffix:".json"
        });
        $translateProvider.preferredLanguage("ua");
        $translateProvider.forceAsyncReload(true);
    });
})();