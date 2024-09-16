//function DatePicker() {
//    $(document).ready(function () {
//        $("#setStartDatepicker").datepicker({
//            'format': 'dd/mm/yyyy',
//            'language': 'th-th',
//            'thaiyear': true,
//            'todayBtn': true,
//            'autoclose': true,
//            'todayHighlight': true,
//        });

//        $("#setEndDatepicker").datepicker({
//            'format': 'dd/mm/yyyy',
//            'language': 'th-th',
//            'thaiyear': true,
//            'todayBtn': true,
//            'autoclose': true,
//            'todayHighlight': true,
//        });
//    });
//}


window.InitDatePicker = function (inputElement, dotnetHelper) {
    $(inputElement).datepicker({
        'format': 'dd/mm/yyyy',
        'thaiyear': true,
        'todayBtn': true,
        'autoclose': true,
        'todayHighlight': true,
    }).on('changeDate', function (e) {
        var selectedDate = e.date;
        var day = selectedDate.getDate() < 10 ? '0' + selectedDate.getDate() : selectedDate.getDate();
        var month = (selectedDate.getMonth() + 1) < 10 ? '0' + (selectedDate.getMonth() + 1) : (selectedDate.getMonth() + 1);
        var year = selectedDate.getFullYear();
        var formattedDate = day + '/' + month + '/' + year;

        dotnetHelper.invokeMethodAsync('SetSelectedDate', formattedDate);
    });
};


window.InitDateEndPicker = function (inputElementEnd, dotnetHelperEnd) {
    $(inputElementEnd).datepicker({
        'format': 'dd/mm/yyyy',
        'thaiyear': true,
        'todayBtn': true,
        'autoclose': true,
        'todayHighlight': true,
    }).on('changeDate', function (e) {
        var selectedDateEnd = e.date;
        var dayEnd = selectedDateEnd.getDate() < 10 ? '0' + selectedDateEnd.getDate() : selectedDateEnd.getDate();
        var monthEnd = (selectedDateEnd.getMonth() + 1) < 10 ? '0' + (selectedDateEnd.getMonth() + 1) : (selectedDateEnd.getMonth() + 1);
        var yearEnd = selectedDateEnd.getFullYear();
        var formattedDateEnd = dayEnd + '/' + monthEnd + '/' + yearEnd;

        dotnetHelperEnd.invokeMethodAsync('SetSelectedDateEnd', formattedDateEnd);
    });
};