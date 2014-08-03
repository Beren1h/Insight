//.config(['$httpProvider', function ($httpProvider) {
//    $httpProvider.interceptors.push('handler');
//}]);

var ItemResponseConfig = function ($httpProvider) {
    $httpProvider.interceptors.push('ItemResponseHandler');
};