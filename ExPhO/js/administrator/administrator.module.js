(function () {
    angular.module("AdministratorApp", ["ui.router", 'pascalprecht.translate', 'tmh.dynamicLocale']).
    config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/index');

    }).
    config(function ($translateProvider) {
        $translateProvider.useStaticFilesLoader({
            prefix: "/localization/administrator-",
            suffix: ".json"
        });
        $translateProvider.preferredLanguage("ua");
        $translateProvider.forceAsyncReload(true);
    });
})();