/**
 * Created by Виктор on 4.10.2014 г..
 */
app.factory('currentTeacher', function () {
    var teacher = null;

    return {
        getTeacher: function () {
            return teacher;
        },
        setTeacher: function (newTeacher) {
            teacher = newTeacher;
            return teacher;
        },
        setSessionTeacher: function (newTeacher) {
            sessionStorage.setItem('teacher', JSON.stringify(newTeacher));
        },
        getSessionTeacher: function () {
            return JSON.parse(sessionStorage.getItem('teacher'));
        },
        deleteSessionTeacher: function () {
            sessionStorage.removeItem('teacher');
        }
    }
});
