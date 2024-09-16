function showdatepicker() {
    $(document).ready(function () {
        $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
        $("#datepicker").datetimepicker({
            timepicker: false,
            datetimepicker: true,
            format: 'Y-m-d H:i a',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000            
            lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
            yearOffset: 543 //set Year ให้เป็นภาษาไทย
        });
    });
}