function ApiController($scope, $http) {

    $scope.get = function (url) {

        $scope.code = null;
        $scope.response = null;

        $http.get(url).
            success(function (data, status) {
                $scope.status = status;
                $scope.data = angular.fromJson(data);
            }).
            error(function (response, status) {
                $scope.data = data || 'Request failed';
                $scope.status = status;
            });

    };

};
