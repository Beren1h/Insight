var LedgerController = function ($scope, $api, $constants, $log) {

    $scope.items = {};

    $scope.add = {};

    $scope.earning = {
        Date: moment().format('YYYY-MM-DD'),
        Next: moment().format('YYYY-MM-DD'),
        Amount: 2298.59,
        Onuses: []
    };

    $scope.total = 0;

    $scope.GetItems = function () {
        $api.items.get().then(function (response) {
            $scope.items = response.data;
        });
    };

    $scope.GetItems();

    $scope.EditEarning = function (earning) {
        $api.ledger.edit(earning).then(function (response){ 
            if (response.status == 200) {
                SetEarning(response.data);
            }
        },
        function (response) {
            //error handler ?
        });
    };

    $scope.Save = function (earning) {
        $api.ledger.save(earning).then(function (response) {
            if (response.status == 200) {
                $scope.earning = {};
            }
        },
        function (response) {
            //error handler ?
        });

    };

    $scope.RemoveOnus = function (Onus) {
        $scope.earning.Onuses.forEach(function (onus, index) {
            if (onus.ItemId == Onus.ItemId && onus.Date == Onus.Date) {
                $scope.earning.Onuses.splice(index, 1);
            }
        });
    }

    $scope.AddOnus = function (add) {
        $scope.earning.Onuses.push(add);
        $scope.add = {};
    }


    $scope.CreateEarning = function (earning) {

        $api.ledger.create(earning).then(function (response) {
            if (response.status == 200) {
                SetEarning(response.data);
            }
        },
        function (response) {
            //error handler ?
        });

    };

    function SetEarning(data) {

        $scope.earning = data;
        $scope.earning.Date = moment($scope.earning.Date).format('YYYY-MM-DD');
        $scope.earning.Next = moment($scope.earning.Next).format('YYYY-MM-DD');

        $scope.earning.Onuses.forEach(function (onus) {
            onus.Date = moment(onus.Date).format('YYYY-MM-DD')
        });

    }

    var watch = function ($scope) {
        return ($scope.earning.Onuses.map(function (onus) {
            return onus.Amount;
        }));
    };

    $scope.$watch(watch, function (newAmounts) {

        var onusTotal = 0;

        newAmounts.forEach(function (amount) {
            onusTotal += amount;
        });

        $scope.total = ($scope.earning.Amount + onusTotal).toFixed(2);

    }, true);

}