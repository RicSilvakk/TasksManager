<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TecPage.aspx.cs" Inherits="TecPage.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Technician</title>
    <link href="~/Content/Site.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/Site.js"></script>
</head>
<body onload="getTecTasks('Tec', 'edit')">
    <form id="form1" runat="server">
       
        <div class="container">
            <h1>Technician Tasks</h1>
            <div class="row">

                <div class="col-md-12">
                    <h4 style="display:inline-block;">Tasks</h4>
                    <div onclick='add_task();' class='btn btn-primary btn-xs btn_addtask' data-title='Add' data-toggle='modal' data-target='#add' >
                        <span class='glyphicon glyphicon-plus'></span>
                    </div>

                    <div class="table-responsive">
                        <div id="holder_results">Loading Tasks...</div>

                        <div class="clearfix"></div>
                        <ul class="pagination pull-right">
                            <li class="disabled"><a href="#"><span class="glyphicon glyphicon-chevron-left"></span></a></li>
                            <li class="active"><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li><a href="#"><span class="glyphicon glyphicon-chevron-right"></span></a></li>
                        </ul>

                    </div>

                </div>
            </div>
        </div>



    <div id="myModal" class="modal">
        <div class="modal-content">
            <span class="close">&times;</span>
            <p>Details of your task:</p>
            <textarea id="ta_details"></textarea>
            <div class="btn-group small">
                <div class="btn_inline popup" id="btn_create_task" onclick="btn_addtask_final();">Create</div>
            </div>
        </div>
    </div>

    <div id="myModal_edit" class="modal modaledit">
        <div class="modal-content">
            <span class="close">&times;</span>
            <p>Edit the details of your task:</p>
            <textarea id="ta_details_edit"></textarea>
            <div class="btn-group small">
                <div class="btn_inline popup" id="btn_edit_task" onclick="btn_edittask_final();">Edit</div>
            </div>
        </div>
    </div>


    <span id="hdf_id_task" style="display:none;"></span>

    </form>
</body>
<script>
    var modal = document.getElementById("myModal");
     
    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];
     
    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

     //When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

</script>
</html>
