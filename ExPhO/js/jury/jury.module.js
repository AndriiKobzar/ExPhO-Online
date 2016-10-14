(function () {
    angular.module("Jury", ["ui.router", 'pascalprecht.translate', 'tmh.dynamicLocale']).
    config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/role');
        
    }).
    config(function ($translateProvider) {
        $translateProvider.useStaticFilesLoader({
            prefix: "/localization/registration-",
            suffix: ".json"
        });
        $translateProvider.preferredLanguage("ua");
        $translateProvider.forceAsyncReload(true);
    });
})();