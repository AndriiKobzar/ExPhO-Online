﻿(function () {
    angular.module("JuryApp", ["ui.router", 'pascalprecht.translate', 'tmh.dynamicLocale']).
    config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/index');
        
    }).
    config(function ($translateProvider) {
        $translateProvider.useStaticFilesLoader({
            prefix: "/localization/jury-",
            suffix: ".json"
        });
        $translateProvider.preferredLanguage("ua");
        $translateProvider.forceAsyncReload(true);
    });
})();