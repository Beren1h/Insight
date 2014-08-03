var ItemResponseHandler = function () {
    var handler = {
        response: function (response) {
            console.log("interceptor = " + response);
            return response;
        }
    };
    return handler;
};



//.factory('ItemResponseHandler', [function ($rootScope) {
//    var handler = {
//        response: function (response) {
//            console.log("interceptor = " + response);
//            console.log(response);
//            $rootScope.$broadcast;
//            return response;
//        }
//    };
//    return handler;
//}])
