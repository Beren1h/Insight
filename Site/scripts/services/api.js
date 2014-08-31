var $api = function ($http) {

    return {
        items: {
            get: function () {
                return $http.get('http://insight.org:8001/api/items/get');
            },
            save: function (post) {
                return $http.post('http://insight.org:8001/api/items/save', post);
            },
            add: function (add) {
                return $http.post('http://insight.org:8001/api/items/add', add);
            },
            remove: function (item) {
                return $http.post('http://insight.org:8001/api/items/delete', item);
            }
        },
        ledger: {
            init: function (start) {
                return $http.post('http://insight.org:8001/api/ledger/init', start);
            },
            save: function (earning) {
                return $http.post('http://insight.org:8001/api/ledger/save', earning);
            },
            create: function (earning) {
                return $http.post('http://insight.org:8001/api/ledger/create', earning);
            },
            edit: function (earning) {
                return $http.post('http://insight.org:8001/api/ledger/edit', earning);
            },
            sum: function (sum) {
                return $http.post('http://insight.org:8001/api/ledger/sum', sum);
            }

        }
    };

};