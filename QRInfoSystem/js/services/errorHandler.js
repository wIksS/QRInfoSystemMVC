app.factory('errorHandler', ['notifier', function (notifier) {
    return {
        handle: function (err) {
            console.log(err);
            var modelState = err.ModelState;
            if (modelState) {
                var isNotified = true;
                for (var model in modelState) {
                    for (var i = 0; i < modelState[model].length; i++) {
                        isNotified = false;
                        notifier.error(modelState[model][i]);
                    }
                }

                if (isNotified) {
                    if (err.message) {
                        notifier.error(err.message);
                    }
                    else if (err.Message) {
                        notifier.error(err.Message);
                    }
                    else if (err.error_description) {
                        notifier.error(err.error_description);
                    }
                }
            }
            else {
                if(err.message){
                    notifier.error(err.message);
                }
                else if (err.Message) {
                    notifier.error(err.Message);
                }
                else if (err.error_description) {
                    notifier.error(err.error_description);
                }
            }        
        }
    }
}])