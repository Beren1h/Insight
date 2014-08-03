var app = angular.module('app', [])
    .constant('$constants', $constants)
    .service('$api', $api)
    .controller('ItemsController', ItemsController)
    //.factory('itemFactory', itemFactory)
    //.controller('ItemsController', ItemsController)
    //.factory('ItemResponseHandler', [ItemResponseHandler])
    //.config(['$httpProvider', ItemResponseConfig])
    //.config(['ApiResource'], $apix);