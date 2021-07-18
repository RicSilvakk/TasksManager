
function btn_tecnhician_click() {
    window.location.href = "TecPage.aspx";
}

function btn_manager_click() {
    window.location.href = "ManPage.aspx";
}
 
function getTecTasks(_type, operation) {

    $.ajax({
        type: "POST",
        //url: "TecPage.aspx/getTecTasks",
        url: "TasksAPI.asmx/getTecTasks",
        data: '{"_type":"' + _type + '", "operation":"' + operation + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            $("#holder_results").html(res.d)
        },
        error: function (res) {
        }
    });
}


function add_task() {
    var modal = document.getElementById("myModal");
    modal.style.display = "block";
}


function btn_addtask_final() {
    var details = $("#ta_details").val();

    if (details == "") {
        alert("Please fill de details of your task!");
        return;
    }

    $.ajax({
        type: "POST",
        //url: "TecPage.aspx/addTask",
        url: "TasksAPI.asmx/addTask",
        data: '{"details":"' + details + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res.d >= 0) {
                alert("Task added sucessfully!");
                $("#myModal").css("display", "none");
                getTecTasks('Tec', 'edit');
            } else {
                alert("There was a problem creating the task. Please contact support.");
                $("#myModal").css("display", "none");
            }
        },
        error: function (res) {
        }
    });


    $("#ta_details").val("");
}

 

function update_task(id_task) {
    var modal = document.getElementById("myModal_edit");
    modal.style.display = "block";
    getTaskDetails(id_task);
    $("#hdf_id_task").val(id_task);
}


function getTaskDetails(id_task) {
    $.ajax({
        type: "POST", 
        url: "TasksAPI.asmx/getTaskDetails",
        data: '{"id_task":"' + id_task + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            $("#ta_details_edit").val(res.d);
        },
        error: function (res) {
        }
    });
}


function btn_edittask_final() {
    var details = $("#ta_details_edit").val();
    var id_task = $("#hdf_id_task").val();

    if (details == "") {
        alert("Please fill de details of your task!");
        return;
    }

    $.ajax({
        type: "POST",
        //url: "TecPage.aspx/addTask",
        url: "TasksAPI.asmx/editTask",
        data: '{"id_task":"' + id_task + '", "details":"' + details + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res.d >= 0) {
                alert("Task updated sucessfully!");
                $("#myModal_edit").css("display", "none");
                getTecTasks('Tec', 'edit');
            } else {
                alert("There was a problem updating the task. Please contact support.");
                $("#myModal_edit").css("display", "none");
            }
        },
        error: function (res) {
        }
    });

    $("#ta_details_edit").val("");
}




function delete_task(id_task) {
   $.ajax({
        type: "POST",
        url: "TasksAPI.asmx/deleteTask",
        data: '{"id_task":"' + id_task + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res.d >= 0) {
                getTecTasks('Man', 'minus');
            } else {
                alert("There was a problem updating the task. Please contact support.");
            }
        },
        error: function (res) {
        }
    });
}

