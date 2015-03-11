/**
 * Created by Виктор on 27.9.2014 г..
 */

app.factory('identity', ['auth', function (auth) {
    function getUser(){
        var user = {
            username:sessionStorage.getItem('username'),
            token:sessionStorage.getItem('token')
        };

        return user;
    };

    function setRoles() {
        return auth.getUserRoles(getUser())
            .then(function (data) {
                var roles = {};
                for (var i = 0; i < data.length; i++) {
                    roles[data[i]] = true;
                }

                sessionStorage.setItem('roles', JSON.stringify(roles));
            }, function (err) {
                console.log(err);
            });
    };

    return{
        loginUser: function (user) {
            sessionStorage.setItem('token',user.access_token);
            sessionStorage.setItem('username', user.userName);
            return setRoles();
        },
        getUser:getUser,
        logoutUser:function(){
            sessionStorage.removeItem('token');
            sessionStorage.removeItem('username');
            sessionStorage.removeItem('roles');
        },
        isLogged:function(){
            return !!sessionStorage.getItem('username');
        },
        isInRole: function (roleName) {
            var roles = JSON.parse(sessionStorage.getItem('roles')) || {};
            return roles[roleName];
        },
        isAdmin: function () {
            return this.isInRole('Admin');
        }
    }
}]);