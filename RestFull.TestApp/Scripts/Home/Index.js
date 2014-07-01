

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

        alert("Update calls 1");
        return $.ajax(userServiceApiUrl, { contentType:"application/json", type: "PUT", data: JSON.stringify(user) });
    };

    return {

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

    var clearEdit = function () {

        $("userEditOutput").empty();
    }

    var saveUser = function () {

        var user = {
            Id: $("#id").val(),
            Name: $("#name").val(),
            Age: $("#age").val()
        };

        usersServer.updateUser(user).done(refreshUsers, clearEdit);
    }

    var wireEvents = function () {

        $(document).on("click", ".editUser", editUser);
        $(document).on("click", "#saveUser", saveUser);
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
