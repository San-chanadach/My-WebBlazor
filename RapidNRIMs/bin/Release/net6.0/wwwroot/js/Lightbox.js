// wwwroot/js/lightbox.js
function initLightbox() {
    $(document).ready(function () {
        // ตั้งค่า Lightbox
        lightbox.option({
            'resizeDuration': 200,
            'wrapAround': true
        });

        // เรียกใช้ Lightbox
        $('[data-lightbox="gallery"]').lightbox();
    });
}