app.factory('qrcodeService', ['$http', '$q', 'baseUrl', 'httpRequester', 'objectToQueryString', 'identity', 'currentTeacher', function ($http, q, baseUrl, httpRequester, objectToQueryString, identity, currentTeacher) {
    var url = baseUrl + '/api';

    var generateQR = function (input) {
        return httpRequester.request({
            method: 'POST',
            url: url + '/QRCode/' + input.id,
            headers: {
                'Authorization': 'Bearer ' + input.identity
            }
        });
    };

    var getQRCode = function (input) {
        return httpRequester.request({
            method: 'GET',
            url: url + '/QRCode/' + input.id,
            headers: {
                'Authorization': 'Bearer ' + input.identity
            }
        });
    }

    return {
        generateQRCodeUI: function () {
            debugger;
            var teacher = currentTeacher.getTeacher();
            var user = identity.getUser();
            var url = baseUrl + '/#/teachers/' + teacher.Id;
            var input = { identity: user.token, id: teacher.Id };
            generateQR(input)
                .then(function (data) {
                    url += '/' + data.Code;
                    new QRCode(document.getElementById("qrcode"), url);
                }, function (err) {
                    notifier.error(err.message);
                })
        },
        generateQRCode: generateQR,
        getQRCode:getQRCode
    }
}]);