$(document).ready(function () {
    console.log("ready!");
    $('#myTable').DataTable();

    $("#modal-btn").on("click", function () {
        console.log('this is it folks!');
        $(function () {
            $('[data-toggle="datepicker"]').datepicker({
                autoHide: true,
                zIndex: 2048,
            });
        });
    });
});