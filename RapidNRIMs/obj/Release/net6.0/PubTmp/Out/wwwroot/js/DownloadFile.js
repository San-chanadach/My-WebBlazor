//code download file ด้วย base64
//function downloadFile(mimeType, base64String, fileName) {
//    $(document).ready(function () {

//        var fileDataUrl = "data:" + mimeType + ";base64," + base64String;
//        fetch(fileDataUrl)
//            .then(respose => respose.blob())
//            .then(blob => {

//                var link = window.document.createElement("a");
//                link.href = window.URL.createObjectURL(blob, { type: mimeType });
//                link.download = fileName;


//                document.body.appendChild(link);
//                link.click();
//                document.body.removeChild(link);

//            })
//    });
//}

// code download file ด้วย bytes file name ในไฟล์ JavaScript (ตั้งชื่อเป็น downloadFile.js) 
function downloadFile(fileName, fileBytes) {
    // แปลงไบต์เป็น Blob
    var blob = new Blob([fileBytes], { type: 'application/pdf' });

    // สร้าง URL สำหรับ Blob
    var url = URL.createObjectURL(blob);

    // สร้างลิงก์สำหรับดาวน์โหลดไฟล์
    var link = document.createElement('a');
    link.href = url;
    link.download = fileName;

    // คลิกลิงก์เพื่อเริ่มดาวน์โหลดไฟล์
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

    // ล้าง URL หลังจากดาวน์โหลดเสร็จสิ้น
    URL.revokeObjectURL(url);
}