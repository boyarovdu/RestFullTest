//$(document).ready(updateUsers);


//function updateUsers() {

//    $("#editCreate").hide();
//    $("#usersList").show();

//    $("tbody").empty();

//    var options = { url: "/api/UserService" };

//    var response = $.ajax(options);

//    response.done(function (data) {

//        for (var i = 0; i < data.length; i++) {

//            $("tbody").append(
//                "<tr><td><input/ name='reservation' type='radio' value=" + data[i].Id + "></td><td>" + data[i].Name + "</td>" + "<td>" + data[i].Age + "</td></tr>"
//            );
//        }
//    });
//}

//function editUser() {
//    $("#usersList").hide();


//}


//function createUser() {
//    $("#usersList").hide();

//    var options = { url: "/api/UserService", type: "POST", data: { Id: 0, Name: $("input[name='Name']").val(), Age: $("input[name='Age']").val() } };

//    $.ajax(options).done(function () {

//        alert("Created");
//    });

//    updateUsers();
//}

//function deleteUser() {

//    var options = { url: "/api/UserService/" + $("#usersList input:checked").attr("value"), type: "DELETE" };

//    $.ajax(options).done(function () {

//        alert("Deleted");
//    });

//    $("tr:has(:checked)").remove();

//    return false;
//}
