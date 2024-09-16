
function showValuePassword() {
    $(document).ready(function () {
        $(".eye-event").hide();
        $(".toggle-password").click(function () {
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

function getInputValuePassword() {
    $(document).ready(function () {
        // Selecting the input element and get its value 
        $(".eye-event").hide();
        var inputVal = document.getElementById("password").value;
        // Displaying the value
        if (inputVal !== "") {
            $(".eye-event").show();
        } else {
            $(".eye-event").hide();
        }
    });
}
