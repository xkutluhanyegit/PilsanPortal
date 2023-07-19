$(document).ready(function () {
    $(function () {
        $("#hr-table").DataTable({
            "responsive": true,
            "lengthChange": false,
            "autoWidth": false,
            "scrollY": '57vh',
            "scrollCollapse": true,
            "paging": false,
            "buttons": ["excel", "pdf", "print", "colvis"]
        }).buttons().container().appendTo('#hr-table_wrapper .col-md-6:eq(0)');
    });

    $(function () {
        $("#departments-table").DataTable({
            "responsive": true,
            "lengthChange": false,
            "autoWidth": false,
            "scrollY": '57vh',
            "scrollCollapse": true,
            "paging": false,
            "buttons": ["excel", "pdf", "print", "colvis"]
        }).buttons().container().appendTo('#departments-table_wrapper .col-md-6:eq(0)');
    });

    $(function () {
        $("#departments-add-table").DataTable({
            "responsive": true,
            "lengthChange": false,
            "autoWidth": false,
            "scrollY": '57vh',
            "scrollCollapse": true,
            "paging": false
        }).buttons().container().appendTo('#departments-table_wrapper .col-md-6:eq(0)');
    });

    $('#datepicker').datepicker({
        format: "d.mm.yyyy",
        language: "tr",
        changeMonth: true,
        autoclose: true,
        todayHighlight: true
    });

    $(function () {
        $("#datepicker").change(function () {

            $('#overtime-form-button').click();
        });
    });

    $('#overtimeadd_datepicker').datepicker({
        format: "d.mm.yyyy",
        language: "tr",
        changeMonth: true,
        autoclose: true,
        todayHighlight: true
    });

    $(function () {
        $("#overtimeadd_datepicker").change(function () {
            var val = $("#overtimeadd_datepicker").val();
            var x = $("#overtimeadd_datepicker2").val(val);
            $('#overtimeadd-form-button').click();
        });
    });

    $('#overtimeupdate_datepicker').datepicker({
        format: "d.mm.yyyy",
        language: "tr",
        changeMonth: true,
        autoclose: true,
        todayHighlight: true
    });

    $(function () {
        $("#overtimeupdate_datepicker").change(function () {

            var val = $("#overtimeupdate_datepicker").val();
            var x = $("#overtimeupdate_datepicker2").val(val);
            $('#overtimeupdate-form-button').click();
        });
    });

    $('#overtimedelete_datepicker').datepicker({
        format: "d.mm.yyyy",
        language: "tr",
        changeMonth: true,
        autoclose: true,
        todayHighlight: true
    });

    $(function () {
        $("#overtimedelete_datepicker").change(function () {

            var val = $("#overtimedelete_datepicker").val();
            var x = $("#overtimedelete_datepicker2").val(val);
            $('#overtimedelete-form-button').click();

        });
    });

    $(function () {
        $("#station-table").DataTable({
            "responsive": true,
            "lengthChange": false,
            "autoWidth": false,
            "scrollY": '57vh',
            "scrollCollapse": true,
            "paging": false,
            "buttons": ["excel", "pdf", "print", "colvis"]
        }).buttons().container().appendTo('#station-table_wrapper .col-md-6:eq(0)');
    });

    $('.accordian-body').on('show.bs.collapse', function () {
        $(this).closest("table-station")
            .find(".collapse.in")
            .not(this)
        //.collapse('toggle')
    })
});