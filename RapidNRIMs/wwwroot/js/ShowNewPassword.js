
function showValueNewPassword() {
    $(document).ready(function () {
        $(".eye-event-newpassword").hide();
        $(".toggle-newpassword").click(function () {
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

function getInputValueNewPassword() {
    $(document).ready(function () {
        // Selecting the input element and get its value 
        $(".eye-event-newpassword").hide();
        var inputVal = document.getElementById("newpassword").value;
        // Displaying the value
        if (inputVal !== "") {
            $(".eye-event-newpassword").show();
        } else {
            $(".eye-event-newpassword").hide();
        }
    });
}
