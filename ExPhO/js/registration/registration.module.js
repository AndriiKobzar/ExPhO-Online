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
            state('jury', {
                url: '/jury',
                templateUrl: '/html/register/juryRegistration.html',
                controller: 'JuryRegistration as ctrl'
            }).
            state('teacher', {
                url: '/teacher',
                templateUrl: '/html/register/teacherRegistration.html',
                controller: 'TeacherRegistration as ctrl'
            }).
            state('learner', {
                url: '/learner',
                templateUrl: '/html/register/learnerRegistration.html',
                controller: 'LearnerRegistration as ctrl'
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