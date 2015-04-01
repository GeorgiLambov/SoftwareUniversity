app.factory('Utils', function ($q) {
    return {
        isImage: function (src) {

            var deferred = $q.defer();

            var image = new Image();
            image.onerror = function () {
                deferred.resolve(false);
            };
            image.onload = function () {
                deferred.resolve(true);
            };
            image.src = src;

            return deferred.promise;
        }
    };
});
app.directive('validateImageUrl', function ($http, Utils) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {

            scope.test = function () {
                Utils.isImage(scope.imageUrl).then(function (result) {
                    if (result) {
                        ngModel.$setValidity('validateImageUrl', true);
                    } else {
                        ngModel.$setValidity('validateImageUrl', false);
                    }
                });
            };

            scope.$watch(attrs.ngModel, function () {
                if (scope.imageUrl) {
                    scope.test();
                }
            });
        }
    };
})