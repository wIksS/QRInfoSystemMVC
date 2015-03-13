/**
 * Created by Виктор on 2.10.2014 г..
 */
app.factory('usersService', ['$http', '$q', 'baseUrl', 'httpRequester', 'objectToQueryString', 
    function ($http, q, baseUrl, httpRequester, objectToQueryString) {
    var url = baseUrl + '/api';

    return {
        getUsers: function (identity) {
            return httpRequester.request({
                method: 'GET',
                url: url + '/account/Users',
                headers: {
                    'Authorization': 'Bearer ' + identity
                }
            });
        },
        addRole: function (user, roleName,identity) {
            var data = {userName : user.UserName, roleName : roleName};
            return httpRequester.request({
                method: 'POST',
                url: url + '/account/AddRole?' + objectToQueryString.parse(data),
                headers: {
                    'Authorization': 'Bearer ' + identity,
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            });
        },
        deleteRole: function (user, roleName, identity) {
            var data = { userName: user.UserName, roleName: roleName };
            return httpRequester.request({
                method: 'DELETE',
                url: url + '/account/DeleteRole?' + objectToQueryString.parse(data),
                headers: {
                    'Authorization': 'Bearer ' + identity,
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            });
        },
        deleteUser: function (user, identity) {
            var data = { userName: user.UserName};
            return httpRequester.request({
                method: 'DELETE',
                url: url + '/account/DeleteUser?' + objectToQueryString.parse(data),
                headers: {
                    'Authorization': 'Bearer ' + identity,
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            });
        }
    }
}]);