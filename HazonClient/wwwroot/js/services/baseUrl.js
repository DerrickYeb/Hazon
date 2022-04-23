function post(url, data, callBack) {
        $.ajax({
                type: "POST",
                url: url,
                dataType: "application/json",
                data: data,
                cache: true,
                success: function(response) {
                    callBack(response);
                },
                error: function(response) {
                    callBack(response);
                }
            }
    );
        post();
    };
//$(function getByIdAsync(url, data, callBack) {
//        $.ajax({
//            type: "GET",
//            url: url,
//            dataType:"application/json",
//            data: data,
//            success: function(response) {
//                callBack(response);
//            },
//            error: function(response) {
//                callBack(response);
//            }
//        });
//        getByIdAsync();
//    },
//    window.jQuery);
//$(function get(url, callBack) {
//    $.ajax({
//        type: "GET",
//        dataType: "application/json",
//        url: url,
//        success:function(response) {
//            callBack(response);
//        },
//        error:function(response) {
//            callBack(response);
//        }
//    });
//    get();
//},window.jQuery);
