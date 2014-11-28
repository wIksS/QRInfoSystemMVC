app.factory('errorHandler', ['notifier', function (notifier) {
    return {
        handle: function (err) {
            console.log(err);
            var modelState = err.ModelState;
            if (modelState) {
                for (var model in modelState) {
                    for (var i = 0; i < modelState[model].length; i++) {
                        notifier.error(modelState[model][i]);
                    }
                }
            }
            else {
                if(err.message){
                    notifier.error(err.message);
                }
                else if (err.error_description) {
                    notifier.error(err.error_description);
                }
            }        
        }
    }
}])