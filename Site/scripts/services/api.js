var $api = function ($http) {

    return {
        items: {
            get: function () {
                return $http.get('http://insight.org:8001/api/ledger/items/get');
            },
            save: function (post) {
                return $http.post('http://insight.org:8001/api/ledger/items/save', post);
            },
            add: function (add) {
                return $http.post('http://insight.org:8001/api/ledger/items/add', add);
            },
            remove: function (item) {
                return $http.post('http://insight.org:8001/api/ledger/items/delete', item);
            }
        }
    };

};