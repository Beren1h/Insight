var insightApp = angular.module('insightApp', []);

insightApp.controller('ajaxController', function ($scope, $http) {

    $scope.add = {};

    $scope.frequencies = [
        { code:'-1', name: 'default' },
        { code: '0', name: 'per pay' },
        { code: '1', name: 'monthly' },
        { code: '2', name: 'bi-weekly' },
        { code: '3', name: 'bi-monthly' }
    ];

    $scope.get = function (url) {

        $scope.code = null;
        $scope.response = null;
        
        $http.get(url).
            success(function (data, status) {
                $scope.status = status;
                $scope.data = angular.fromJson(data);

                for (index in $scope.data) {
                    for (var i = 0; i < $scope.frequencies.length; i++) {
                        if ($scope.data[index].Frequency == $scope.frequencies[i].code) {
                            $scope.data[index].FrequencyObject = angular.copy($scope.frequencies[i]);
                        };
                    };
                };
            }).
            error(function (response, status) {
                $scope.data = data || 'Request failed';
                $scope.status = status;
            });

    };

    $scope.updateItem = function (url, post) {

        for (index in post) {
            post[index]['Frequency'] = post[index]['FrequencyObject'].code;
        }

        $http.post(url, post).
            success(function (response) {
                console.log(response);
            }).
            error(function (response) {
                console.log(response);
            });
    };

    $scope.post = function (url, post) {
        $scope.code = null;
        $scope.response = null;

        post['Frequency'] = post['FrequencyObject'].code;

        $http.post(url, post).
        success(function (response) {
            console.log(response)
        });
    };

});
