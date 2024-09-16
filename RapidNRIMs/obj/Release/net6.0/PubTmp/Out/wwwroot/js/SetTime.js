
window.convertTime = function (inputId) {
    var timeInput = document.getElementById(inputId).value;

    // เช็คว่า input ว่างหรือไม่
    if (timeInput.trim() === "") {
        // ถ้าว่างให้กำหนดค่าว่างให้กับ input
        document.getElementById(inputId).value = "";
        return;
    }

    // เช็คว่ามีเฉพาะตัวเลขและมีเพียง 4 ตัวหรือไม่
    if (!/^\d{4}$/.test(timeInput) && !/^\d{1,2}:\d{2}$/.test(timeInput)) {
        alert("Please enter only 4 numbers or time in HH:mm format.");
        document.getElementById(inputId).value = ""; // เคลียร์ Textbox
        return;
    }

    var hours;
    var minutes;
    if (/^\d{4}$/.test(timeInput)) {
        hours = timeInput.slice(0, 2);
        minutes = timeInput.slice(2);
    } else {
        var timeParts = timeInput.split(":");
        hours = timeParts[0];
        minutes = timeParts[1];
    }

    if (parseInt(hours) > 23 || parseInt(minutes) > 59) {
        alert("Please fill in the correct time ");
        document.getElementById(inputId).value = ""; // เคลียร์ Textbox
        return;
    }

    var formattedHours = hours.padStart(2, '0'); // เพิ่มเลข 0 ข้างหน้าถ้าตัวเลขน้อยกว่า 10
    var formattedMinutes = minutes.padStart(2, '0'); // เพิ่มเลข 0 ข้างหน้าถ้าตัวเลขน้อยกว่า 10
    var convertedTime = formattedHours + ":" + formattedMinutes;
    document.getElementById(inputId).value = convertedTime;

    // ส่งค่า convertedTime ไปยัง C#
    return convertedTime;
}





window.convertEndTime = function (inputEndId) {
    var timeEndInput = document.getElementById(inputEndId).value;

    // เช็คว่า input ว่างหรือไม่
    if (timeEndInput.trim() === "") {
        // ถ้าว่างให้กำหนดค่าว่างให้กับ input
        document.getElementById(inputEndId).value = "";
        return;
    }

    // เช็คว่ามีเฉพาะตัวเลขและมีเพียง 4 ตัวหรือไม่
    if (!/^\d{4}$/.test(timeEndInput) && !/^\d{1,2}:\d{2}$/.test(timeEndInput)) {
        alert("Please enter only 4 numbers or time in HH:mm format.");
        document.getElementById(inputEndId).value = ""; // เคลียร์ Textbox
        return;
    }

    var hoursTimeEnd;
    var minutesTimeEnd;
    if (/^\d{4}$/.test(timeEndInput)) {
        hoursTimeEnd = timeEndInput.slice(0, 2);
        minutesTimeEnd = timeEndInput.slice(2);
    } else {
        var timeEndParts = timeEndInput.split(":");
        hoursTimeEnd = timeEndParts[0];
        minutesTimeEnd = timeEndParts[1];
    }

    if (parseInt(hoursTimeEnd) > 23 || parseInt(minutesTimeEnd) > 59) {
        alert("Please fill in the correct time(Ex.time 13:00 is 1300) ");
        document.getElementById(inputEndId).value = ""; // เคลียร์ Textbox
        return;
    }

    var formattedEndHours = hoursTimeEnd.padStart(2, '0'); // เพิ่มเลข 0 ข้างหน้าถ้าตัวเลขน้อยกว่า 10
    var formattedEndMinutes = minutesTimeEnd.padStart(2, '0'); // เพิ่มเลข 0 ข้างหน้าถ้าตัวเลขน้อยกว่า 10
    var convertedTimeEnd = formattedEndHours + ":" + formattedEndMinutes;
    document.getElementById(inputEndId).value = convertedTimeEnd;

   
    // ส่งค่า convertedTime ไปยัง C#
    return convertedTimeEnd;
}
