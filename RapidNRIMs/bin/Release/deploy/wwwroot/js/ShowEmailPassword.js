
function showEmailValuePassword() {
    $(document).ready(function () {
        $(".eye-event-email").hide();
        $(".toggle-password-email").click(function () {
            $(this).toggleClass("fa-eye fa-eye-slash");
            var input = $($(this).attr("toggle"));
            if (input.attr("type") == "password") {
                input.attr("type", "text");
            } else {
                input.attr("type", "password");
            }
        });
    });
}

function getInputEmailValuePassword() {
    $(document).ready(function () {
        // Selecting the input element and get its value 
        $(".eye-event-email").hide();
        var inputVal = document.getElementById("passwordemail").value;
        // Displaying the value
        if (inputVal !== "") {
            $(".eye-event-email").show();
        } else {
            $(".eye-event-email").hide();
        }
    });
}
