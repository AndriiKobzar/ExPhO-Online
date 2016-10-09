(function () {
    angular.module("Registration").directive("commonInfo", function () {
        return {
            templateUrl: "/html/registration/commonInfo.html",
            replace: true,
            require: "^ngModel",
            restrict: "E",
            scope:{
                model:"=ngModel"
            },
            link: function (scope, attrs, ngModel) {
               // scope.model = ngModel.$modelValue;
            }
        };
    });
})();