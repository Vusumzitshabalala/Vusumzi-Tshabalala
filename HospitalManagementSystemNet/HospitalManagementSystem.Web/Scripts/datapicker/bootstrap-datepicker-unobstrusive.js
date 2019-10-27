$(function () {
    $(document).ready(function () {
        $('.datepicker').each(function (index,item) {
            $(item).datepicker({
                //format: 'YYY-MM-DD'
            });
        });
    });
}(jQuery));