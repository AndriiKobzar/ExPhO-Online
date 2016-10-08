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
                controller: 'InfoController as ctrl'
            }).
            state('jury', {
                url: '/jury',
                templateUrl: '/html/registration/juryRegistration.html',
                controller: 'JuryRegistration as ctrl'
            }).
            state('teacher', {
                url: '/teacher',
                templateUrl: '/html/registration/teacherRegistration.html',
                controller: 'TeacherRegistration as ctrl'
            }).
            state('learner', {
                url: '/learner',
                templateUrl: '/html/registration/learnerRegistration.html',
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