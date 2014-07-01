

var usersServer = (function () {

    var userServiceApiUrl = '/api/UserService';

    $(document).ajaxError(function myfunction(event, xhr) {

        alert(xhr.status + " : " + xhr.statusText);
    })

    var getUsers = function () {

        return $.ajax(userServiceApiUrl);
    }

    var getUser = function (id) {

        return $.ajax(userServiceApiUrl + "/" + id);
    };

    var updateUser = function (user) {

        return $.ajax(userServiceApiUrl, { contentType: "application/json", type: "PUT", data: JSON.stringify(user) });
    };

    var addUser = function (user) {

        return $.ajax(userServiceApiUrl, { type: "POST", contentType: "application/json", data: JSON.stringify(user) });
    }

    var deleteUser = function (id) {

        return $.ajax(userServiceApiUrl + "/" + id, { type: "DELETE" });
    }

    return {
        deleteUser: deleteUser,
        addUser: addUser,
        updateUser: updateUser,
        getUsers: getUsers,
        getUser: getUser
    };

}());

(function () {

    var templates = {};

    var compileTemplates = function () {

        templates.userTable = Handlebars.compile($("#userTable").html());
        templates.userEdit = Handlebars.compile($("#userEdit").html());
    };

    var showAllUsers = function (data) {

        var output = templates.userTable({ user: data });
        $("#userTableOutput").html(output);
    }

    var showUserForEdit = function (user) {

        var output = templates.userEdit(user);
        $("#userEditOutput").html(output);
    }

    var refreshUsers = function () {

        usersServer.getUsers().done(showAllUsers);
    }

    var editUser = function () {

        var id = getId(this);
        usersServer.getUser(id).done(showUserForEdit);
    }

    var createUser = function () {

        var user = { Id: 0, Name: "", Age: "" };
        showUserForEdit(user);
    }

    var deleteUser = function () {
        var id = getId(this);
        usersServer.deleteUser(id).done(refreshUsers);
    }

    var clearEdit = function () {

        $("userEditOutput").empty();
    }

    var saveUser = function () {

        var user = {
            Id: $("#id").val(),
            Name: $("#name").val(),
            Age: $("#age").val()
        };

        //usersServer.updateUser(user).done(refreshUsers, clearEdit);

        var operation;

        if (user.Id != 0) {
            operation = usersServer.updateUser(user);
        }
        else {
            operation = usersServer.addUser(user);
        }

        operation.done(refreshUsers, clearEdit);

        return false;
    }

    var wireEvents = function () {

        $(document).on("click", ".editUser", editUser);
        $(document).on("click", "#saveUser", saveUser);
        $(document).on("click", "#createUser", createUser);
        $(document).on("click", ".deleteUser", deleteUser);
    }

    var getId = function (element) {

        return $(element).parents("tr").attr("data-id");
    };

    $(function () {

        wireEvents();
        compileTemplates();
        refreshUsers();
    });
})();
