
window.convertTime = function (inputId) {
    var timeInput = document.getElementById(inputId).value;

    // ����� input ��ҧ�������
    if (timeInput.trim() === "") {
        // �����ҧ����˹������ҧ���Ѻ input
        document.getElementById(inputId).value = "";
        return;
    }

    // �������੾�е���Ţ�������§ 4 ����������
    if (!/^\d{4}$/.test(timeInput) && !/^\d{1,2}:\d{2}$/.test(timeInput)) {
        alert("Please enter only 4 numbers or time in HH:mm format.");
        document.getElementById(inputId).value = ""; // ������ Textbox
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
        document.getElementById(inputId).value = ""; // ������ Textbox
        return;
    }

    var formattedHours = hours.padStart(2, '0'); // �����Ţ 0 ��ҧ˹�Ҷ�ҵ���Ţ���¡��� 10
    var formattedMinutes = minutes.padStart(2, '0'); // �����Ţ 0 ��ҧ˹�Ҷ�ҵ���Ţ���¡��� 10
    var convertedTime = formattedHours + ":" + formattedMinutes;
    document.getElementById(inputId).value = convertedTime;

    // �觤�� convertedTime ��ѧ C#
    return convertedTime;
}





window.convertEndTime = function (inputEndId) {
    var timeEndInput = document.getElementById(inputEndId).value;

    // ����� input ��ҧ�������
    if (timeEndInput.trim() === "") {
        // �����ҧ����˹������ҧ���Ѻ input
        document.getElementById(inputEndId).value = "";
        return;
    }

    // �������੾�е���Ţ�������§ 4 ����������
    if (!/^\d{4}$/.test(timeEndInput) && !/^\d{1,2}:\d{2}$/.test(timeEndInput)) {
        alert("Please enter only 4 numbers or time in HH:mm format.");
        document.getElementById(inputEndId).value = ""; // ������ Textbox
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
        document.getElementById(inputEndId).value = ""; // ������ Textbox
        return;
    }

    var formattedEndHours = hoursTimeEnd.padStart(2, '0'); // �����Ţ 0 ��ҧ˹�Ҷ�ҵ���Ţ���¡��� 10
    var formattedEndMinutes = minutesTimeEnd.padStart(2, '0'); // �����Ţ 0 ��ҧ˹�Ҷ�ҵ���Ţ���¡��� 10
    var convertedTimeEnd = formattedEndHours + ":" + formattedEndMinutes;
    document.getElementById(inputEndId).value = convertedTimeEnd;

   
    // �觤�� convertedTime ��ѧ C#
    return convertedTimeEnd;
}
