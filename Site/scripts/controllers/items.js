var ItemsController = function ($scope, $api, $constants) {

    $scope.frequencies = $constants.frequencies;
    $scope.add = {};

    $scope.GetItems = function () {
        $api.items.get().then(function (response) {
            $scope.data = TransformFrequency(response.data);
        },
        function (response) {
            //error handler ?
        });
    };

    //initialize
    $scope.GetItems();

    $scope.SaveItems = function (saves) {

        for (index in saves) {
            saves[index][$constants.rawFrequency] = saves[index][$constants.selectedFrequency].code;
        }

        $api.items.save(saves).then(function (response) {

            if (response.data == 'true') {
                $api.items.get().then(function (response) {
                    $scope.data = TransformFrequency(response.data);
                },
                function (response) {
                    //error handler ?
                });
            }
           
        },
        function (response) {
            //error handler ?
        });
    }

    $scope.AddItem = function (add) {

        add[$constants.rawFrequency] = add[$constants.selectedFrequency].code;

        $api.items.add(add).then(function (response) {

            if (response.data == 'true') {
                $api.items.get().then(function (response) {
                    $scope.data = TransformFrequency(response.data);
                    $scope.addForm.$setPristine(true);
                    $scope.add = {};
                },
                function (response) {
                    //error handler ?
                });
            }

        },
        function (response) {
            //error handler ?
        });

    }

    $scope.DeleteItem = function (item) {

        $api.items.remove(item).then(function (response) {

            if (response.data == 'true') {
                $api.items.get().then(function (response) {
                    $scope.data = TransformFrequency(response.data);
                },
                function (response) {
                    //error handler ?
                });
            }

        },
        function (response) {
            //error handler ?
        });

    }










    function TransformFrequency(data) {
        for (index in data) {
            for (var i = 0; i < $constants.frequencies.length; i++) {
                if (data[index].Frequency == $constants.frequencies[i].code) {
                    data[index].FrequencyObject = angular.copy($constants.frequencies[i]);
                };
            };
        };

        return data;
    }



}


//var ItemsController = function ($scope, itemFactory, $constants) {

//    var x = itemFactory.$api;
//    console.log(x);

//};

    //$scope.frequencies = $constants.frequencies;

    //$scope.GetItems = function () {

    //    //console.log($api.GetItems());
    //    $scope.data = $api.$api.GetItems();

    //    console.log($scope.data);
    //    //for (index in json) {
    //    //    for (var i = 0; i < $scope.frequencies.length; i++) {
    //    //        if (json[index].Frequency == $scope.frequencies[i].code) {
    //    //            json[index].FrequencyObject = angular.copy($scope.frequencies[i]);
    //    //        };
    //    //    };
    //    //};
        
    //}
    
    //console.log($scope.data);

//};
